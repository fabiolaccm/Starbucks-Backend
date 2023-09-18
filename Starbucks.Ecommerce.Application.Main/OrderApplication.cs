using AutoMapper;
using Starbucks.Ecommerce.Application.DTO;
using Starbucks.Ecommerce.Application.Interface;
using Starbucks.Ecommerce.Domain.Entity;
using Starbucks.Ecommerce.Domain.Interface;
using Starbucks.Ecommerce.Infraestructure.Interface;
using Starbucks.Ecommerce.Transversal.Common;

namespace Starbucks.Ecommerce.Application.Main
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IOrderDomain _orderDomain;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderApplication(IOrderDomain orderDomain, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _orderDomain = orderDomain;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<OrderResponseDto>> CreateOrder(CreateOrderRequestDto createOrderRequest)
        {

            var user = await _unitOfWork.Users.FindById(createOrderRequest.UserId);
            if (user == null)
            {
                return Response<OrderResponseDto>.Fail("Usuario no válido");
            }

            if (createOrderRequest.OrderDetails == null || createOrderRequest.OrderDetails.Count == 0)
            {
                return Response<OrderResponseDto>.Fail("La orden debe tener al menos un detalle de pedido");
            }

            var productsInOrder = new List<Product>();
            foreach (var detail in createOrderRequest.OrderDetails)
            {
                var product = await _unitOfWork.Products.FindById(detail.ProductId);
                if (product == null)
                {
                    return Response<OrderResponseDto>.Fail($"Elemento de menú con ID {detail.ProductId} no válido");
                }
                productsInOrder.Add(product);
            };

            foreach (var productInOrder in productsInOrder)
            {
                var orderDetail = createOrderRequest.OrderDetails.FirstOrDefault(s => s.ProductId == productInOrder.Id);

                var ingredientsInOrder = productInOrder.ProductItems
                    .GroupBy(item => item.Ingredient.Id)
                    .Select(group => new
                    {
                        IngredientId = group.Key,
                        TotalQuantity = group.Sum(item => item.Quantity) * orderDetail.Quantity
                    });

                // Validar si el ítem está disponible en stock
                foreach (var ingredientInOrder in ingredientsInOrder)
                {
                    var iii = ingredientInOrder.IngredientId.ToString();
                    var ingredient = await _unitOfWork.Ingredients.FindById(ingredientInOrder.IngredientId);
                    if (ingredient == null || ingredient.QuantityAvailable < ingredientInOrder.TotalQuantity)
                    {
                        return Response<OrderResponseDto>.Fail($"No hay suficiente stock disponible para el menú");
                    }
                    ingredient.QuantityAvailable = ingredient.QuantityAvailable - ingredientInOrder.TotalQuantity;
                    await _unitOfWork.Ingredients.Update(ingredient);
                }
            };

            var price = createOrderRequest.OrderDetails.Sum(p => p.Quantity * productsInOrder.Where(pro => p.ProductId == pro.Id).FirstOrDefault().Price);

            var subTotalOrder = productsInOrder.Sum(p => p.Price);
            var totalIgv = user.Province.Igv;
            var totalOrder = price + ((price * totalIgv) / 100);
            
            var order = _mapper.Map<Order>(createOrderRequest);
            order.Id = Guid.NewGuid();
            order.User = user;
            order.CreationDate = DateTime.Now;
            order.Status = OrderState.Received;
            order.TotalPrice = Math.Round(totalOrder, 2);
            order.OrderDetails = createOrderRequest.OrderDetails.Select(o =>
            {
                return new OrderDetail
                {
                    Id = Guid.NewGuid(),
                    ProductId = o.ProductId,
                    OrderId = order.Id,
                    Quantity = o.Quantity
                };
            }).ToList();
            var created = await _orderDomain.Create(order);

            if (created)
            {
                var response = await this.GetOrderById(order.Id);
                return response;

            }
            return Response<OrderResponseDto>.Fail("Problems create order");
        }

        public async Task<Response<bool>> DeleteOrder(Guid orderId)
        {
            var order = await _orderDomain.FindById(orderId);
            if (order == null)
            {
                return Response<bool>.Fail("Order Not exists");
            }
            
            var deleted = await _orderDomain.Delete(order);

            if (deleted) { 
                return Response<bool>.Ok(true);
            }
            return Response<bool>.Fail("Problem delete order");
        }

        public async Task<Response<bool>> ExecuteOrder(Guid orderId)
        {
            var order = await _orderDomain.FindById(orderId);
            if (order == null)
            {
                return Response<bool>.Fail("Order Not exists");
            }

            order.Status = OrderState.InProgress;
            order.ExecutionDate = DateTime.Now;
            var updated = await _orderDomain.Update(order);

            if (updated)
            {
                return Response<bool>.Ok(true);
            }
            return Response<bool>.Fail("Problem execute order");
        }

        public async Task<Response<IEnumerable<OrderResponseDto>>> GetAllOrders()
        {
            var orders = await _orderDomain.GetAll();

            foreach (var order in orders) {
                var orderCompleted = false;
                var status = order.Status;
                if (order.ExecutionDate.HasValue && status != OrderState.Finished && status != OrderState.Invoiced)
                {
                    TimeSpan difference = DateTime.Now.Subtract(order.ExecutionDate.Value);
                    int minutesDifference = (int)difference.TotalMinutes;
                    int orderTime = order.OrderDetails.Sum(s => s.Product.PreparationTime);
                    orderCompleted = minutesDifference >= orderTime;
                    status = orderCompleted ? OrderState.Finished : status;

                    if (orderCompleted)
                    {
                        order.Status = status;
                        await _orderDomain.Update(order);
                    }
                }
            }

            var data = _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
            return Response<IEnumerable<OrderResponseDto>>.Ok(data);
        }

        public async Task<Response<OrderResponseDto>> GetOrderById(Guid id)
        {
            var order = await _orderDomain.FindById(id);
            if (order == null)
            {
                return Response<OrderResponseDto>.Fail("Order Not exists");
            }
            var data = _mapper.Map<OrderResponseDto>(order);
            return Response<OrderResponseDto>.Ok(data);
        }

        public async Task<Response<bool>> InvoiceOrder(Guid orderId)
        {
            var order = await _orderDomain.FindById(orderId);
            if (order == null)
            {
                return Response<bool>.Fail("Order Not exists");
            }

            order.Status = OrderState.Invoiced;
            var updated = await _orderDomain.Update(order);

            if (updated)
            {
                return Response<bool>.Ok(true);
            }
            return Response<bool>.Fail("Problem invoiced order");
        }
    }
}
