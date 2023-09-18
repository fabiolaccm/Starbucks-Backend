using AutoMapper;
using Starbucks.Ecommerce.Application.DTO;
using Starbucks.Ecommerce.Domain.Entity;
using Starbucks.Ecommerce.Infraestructure.Data.DataModels;

namespace Starbucks.Ecommerce.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<UserDataModel, User>().ReverseMap();
            CreateMap<User, UserResponseDto>().ReverseMap();
            CreateMap<RoleDataModel, Role>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<UpdateUserDto, User>().ReverseMap();
            CreateMap<ProvinceDataModel, Province>().ReverseMap();
            CreateMap<Province, ProvinceDto>().ReverseMap();
            CreateMap<ProductDataModel, Product>().ReverseMap();
            CreateMap<ProductItemDataModel, ProductItem>().ReverseMap();
            CreateMap<IngredientDataModel, Ingredient>().ReverseMap();

            CreateMap<Product, ProductResponseDto>().ReverseMap();
            CreateMap<ProductItem, ProductItemResponseDto>().ReverseMap();
            CreateMap<Ingredient, IngredientResponseDto>().ReverseMap();

            CreateMap<UpdateIngredientDto, Ingredient>().ReverseMap();

            CreateMap<OrderDataModel, Order>().ReverseMap();
            CreateMap<OrderDetailDataModel, OrderDetail>().ReverseMap();

            CreateMap<CreateOrderRequestDto, Order>().ReverseMap();
            CreateMap<OrderDetailRequest, OrderDetail>().ReverseMap();
            CreateMap<Order, OrderResponseDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailResponseDto>().ReverseMap();

            



        }
    }
}
