using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;

namespace BackEnd.Data
{
    public static class Date
    {
        public static List<CategoryDomainModel> Categories { get; set; }

        public static List<ProductDomainModel> Products { get; set; }

        static Date()
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
            }
        }
    }
}