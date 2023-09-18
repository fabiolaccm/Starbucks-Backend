using Starbucks.Ecommerce.Infraestructure.Data.DataModels;

namespace Starbucks.Ecommerce.Infraestructure.Data
{
    public class DbInitializer
    {
        public static void Initialize(StarbucksDatabaseContext context)
        {
            context.Database.EnsureCreated();

            var ingredientCafe = new IngredientDataModel
            {
                Id = Guid.NewGuid(),
                Name = "Café",
                QuantityAvailable = 20
            };

            var ingredientMilk = new IngredientDataModel
            {
                Id = Guid.NewGuid(),
                Name = "Leche",
                QuantityAvailable = 20
            };

            var ingredientBread = new IngredientDataModel
            {
                Id = Guid.NewGuid(),
                Name = "Pan",
                QuantityAvailable = 20
            };

            var ingredientEgg = new IngredientDataModel
            {
                Id = Guid.NewGuid(),
                Name = "Huevo",
                QuantityAvailable = 20
            };

            var ingredientChickenBreast = new IngredientDataModel
            {
                Id = Guid.NewGuid(),
                Name = "Pechuga de Pollo",
                QuantityAvailable = 20
            };

            var ingredientCheese = new IngredientDataModel
            {
                Id = Guid.NewGuid(),
                Name = "Queso",
                QuantityAvailable = 20
            };

            var ingredientLettuce = new IngredientDataModel
            {
                Id = Guid.NewGuid(),
                Name = "Lechuga",
                QuantityAvailable = 20
            };

            var ingredientTomato = new IngredientDataModel
            {
                Id = Guid.NewGuid(),
                Name = "Tomate",
                QuantityAvailable = 20
            };

            
            var products = new List<ProductDataModel>
            {
                new ProductDataModel {
                    Id = Guid.Parse("5da45f34-ab0f-4181-ac8a-94aa37e980d6"),
                    Name = "Café Latte",
                    Price = 4.99m,
                    Description = "Café caliente con leche",
                    PreparationTime = 1,
                    ProductItems = new [] {
                        new ProductItemDataModel {
                            ProductItemId = Guid.NewGuid(),
                            IngredientId = ingredientCafe.Id,
                            Quantity = 2
                        },
                        new ProductItemDataModel {
                            ProductItemId = Guid.NewGuid(),
                            IngredientId = ingredientMilk.Id,
                            Quantity = 1
                        }
                    }
                },

                new ProductDataModel {
                    Id = Guid.Parse("f73634e6-1949-4ab5-a4d7-aa41b339f897"),
                    Name = "Café Mocha",
                    Price = 5.49m,
                    Description = "Café caliente Mocha con leche",
                    PreparationTime = 1,
                    ProductItems = new [] {
                        new ProductItemDataModel {
                            ProductItemId = Guid.NewGuid(),
                            IngredientId = ingredientCafe.Id,
                            Quantity = 2
                        },
                        new ProductItemDataModel {
                            ProductItemId = Guid.NewGuid(),
                            IngredientId = ingredientMilk.Id,
                            Quantity = 1
                        }
                    }
                },

                new ProductDataModel {
                    Name = "Pan con pollo",
                    Price = 10.49m,
                    Description = "Incluye pan, pechuga de pollo, lechuga",
                    PreparationTime = 10,
                    ProductItems = new [] {
                        new ProductItemDataModel {
                            ProductItemId = Guid.NewGuid(),
                            IngredientId = ingredientBread.Id,
                            Quantity = 1
                        },
                        new ProductItemDataModel {
                            ProductItemId = Guid.NewGuid(),
                            IngredientId = ingredientChickenBreast.Id,
                            Quantity = 1
                        },
                        new ProductItemDataModel {
                            ProductItemId = Guid.NewGuid(),
                            IngredientId = ingredientLettuce.Id,
                            Quantity = 1
                        }
                    }
                },

                new ProductDataModel {
                    Name = "Pan Mixto",
                    Price = 5.49m,
                    Description = "Incluye pan, pechuga de pollo, huevo, lechuga, tomate",
                    PreparationTime = 10,
                    ProductItems = new [] {
                        new ProductItemDataModel {
                            ProductItemId = Guid.NewGuid(),
                            IngredientId = ingredientBread.Id,
                            Quantity = 1
                        },
                        new ProductItemDataModel {
                            ProductItemId = Guid.NewGuid(),
                            IngredientId = ingredientChickenBreast.Id,
                            Quantity = 1
                        },
                        new ProductItemDataModel {
                            ProductItemId = Guid.NewGuid(),
                            IngredientId = ingredientEgg.Id,
                            Quantity = 2
                        },
                        new ProductItemDataModel {
                            ProductItemId = Guid.NewGuid(),
                            IngredientId = ingredientLettuce.Id,
                            Quantity = 1
                        },
                        new ProductItemDataModel {
                            ProductItemId = Guid.NewGuid(),
                            IngredientId = ingredientTomato.Id,
                            Quantity = 1
                        }
                    }
                },
            };

            var roles = getRoles();
            var provinces = getProvinces();
            var users = getUsers(roles, provinces);
            context.Ingredients.AddRange(new[] { ingredientCafe, ingredientMilk, ingredientBread, ingredientCafe, ingredientCheese, ingredientChickenBreast, ingredientEgg, ingredientLettuce, ingredientTomato });
            context.Products.AddRange(products);
            context.Provinces.AddRange(provinces);
            context.Roles.AddRange(roles);
            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static RoleDataModel[] getRoles()
        {
            var roleUser = new RoleDataModel
            {
                Id = Guid.NewGuid(),
                Name = "Usuario"
            };

            var roleEmployee = new RoleDataModel
            {
                Id = Guid.NewGuid(),
                Name = "Empleado"
            };

            var roleSupervisor = new RoleDataModel
            {
                Id = Guid.NewGuid(),
                Name = "Supervisor"
            };

            var roleAdministrator = new RoleDataModel
            {
                Id = Guid.NewGuid(),
                Name = "Administrador"
            };

            return new[] { roleUser, roleEmployee, roleSupervisor, roleAdministrator };
        }

        private static UserDataModel[] getUsers(RoleDataModel[] roleDataModels, ProvinceDataModel[] provinces)
        {
            var userWithRoleUser1 = new UserDataModel
            {
                Id = Guid.Parse("76b80386-43d1-4552-a355-a742296f0bc1"),
                Email = "user1@gmail.com",
                Password = "123",
                Name = "First user",
                RoleId = roleDataModels[0].Id,
                ProvinceId = provinces[0].Id
            };

            var userWithRoleUser2 = new UserDataModel
            {
                Id = Guid.Parse("76b80386-43d1-4552-a355-a742296f0bc2"),
                Email = "user2@gmail.com",
                Password = "123",
                Name = "Second user",
                RoleId = roleDataModels[0].Id,
                ProvinceId = provinces[0].Id
            };

            var userWithRoleEmployee = new UserDataModel
            {
                Id = Guid.Parse("76b80386-43d1-4552-a355-a742296f0bc3"),
                Email = "user3@gmail.com",
                Password = "123",
                Name = "Flav employee",
                RoleId = roleDataModels[1].Id,
                ProvinceId = provinces[0].Id
            };

            var userWithRoleSupervisor = new UserDataModel
            {
                Id = Guid.Parse("76b80386-43d1-4552-a355-a742296f0bc4"),
                Email = "user4@gmail.com",
                Password = "123",
                Name = "Flav supervisor",
                RoleId = roleDataModels[2].Id,
                ProvinceId = provinces[0].Id
            };

            var userWithRoleAdministrator = new UserDataModel
            {
                Id = Guid.Parse("76b80386-43d1-4552-a355-a742296f0bc5"),
                Email = "user5@gmail.com",
                Password = "123",
                RoleId = roleDataModels[3].Id,
                Name = "Flav administrator",
                ProvinceId = provinces[0].Id
            };

            return new[] { userWithRoleUser1, userWithRoleUser2, userWithRoleEmployee, userWithRoleSupervisor, userWithRoleAdministrator };
        }

        private static ProvinceDataModel[] getProvinces()
        {

            ProvinceDataModel provinceLima = new ProvinceDataModel
            {
                Id = 1,
                Name = "Lima",
                Igv = 18
            };

            ProvinceDataModel provinceArequipa = new ProvinceDataModel
            {
                Id = 2,
                Name = "Arequipa",
                Igv = 19
            };

            ProvinceDataModel provinceCuzco = new ProvinceDataModel
            {
                Id = 3,
                Name = "Cuzco",
                Igv = 10
            };

            return new[] { provinceLima, provinceArequipa, provinceCuzco };
        }

    }
}
