using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;

namespace BackEnd
{
    public class BackEnd : IBackEnd
    {
        private List<CategoryDomainModel> Categories { get; set; }
        private List<ProductDomainModel> Products { get; set; } 

        public BackEnd()
        {
            Categories = new List<CategoryDomainModel>()
            {
                new CategoryDomainModel()
                {
                    Id = 1,
                    Name = "A"
                },
                new CategoryDomainModel()
                {
                    Id = 2,
                    Name = "B"
                },
                new CategoryDomainModel()
                {
                    Id = 3,
                    Name = "C"
                }
            };

            Products = new List<ProductDomainModel>();

            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int randValue = rand.Next(1, Categories.Count);

                Products.Add(new ProductDomainModel()
                {
                    Id = i,
                    Category = Categories.FirstOrDefault(x => x.Id == randValue),
                    Name = $"Awesome name number {rand.Next(10000)}",
                    Price = rand.NextDouble() * 1000
                });

                if (Products.Last().Category == null)
                {
                    throw new Exception($"{i} -> {randValue}");
                }
            }
        }

        public void Add(ProductDomainModel product)
        {
            int lastId = Products.Max(x => x.Id);
            product.Id = lastId + 1;

            Products.Add(product);
        }

        public ProductDomainModel Get(int productId)
        {
            var product = Products.FirstOrDefault(x => x.Id == productId);

            return product;
        }

        public IEnumerable<ProductDomainModel> Get()
        {
            return Products.AsEnumerable();
        }

        public bool Update(ProductDomainModel model)
        {
            var oldProduct = Products.FirstOrDefault(x => x.Id == model.Id);
            if (oldProduct != null)
            {
                oldProduct.Category = model.Category;
                oldProduct.Name = model.Name;
                oldProduct.Price = model.Price;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var productToDelete = Products.FirstOrDefault(x => x.Id == id);
            if (productToDelete != null)
            {
                Products.Remove(productToDelete);
                return true;
            }
            return false;
        }
    }
}