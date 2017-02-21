using System.Collections.Generic;
using System.Linq;
using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.Product
{
    public class Product : IProduct
    {
        public void Add(ProductDomainModel product)
        {
            int lastId = -1;
            if (Data.Date.Products.Any())
            {
                lastId = Date.Products.Max(x => x.Id);
            }
            product.Id = lastId + 1;
            product.Category = Date.Categories.FirstOrDefault(x => x.Id == product.CategoryId);

            Date.Products.Add(product);
        }

        public ProductDomainModel Get(int productId)
        {
            ProductDomainModel product = Date.Products.FirstOrDefault(x => x.Id == productId);

            return product;
        }

        public IEnumerable<ProductDomainModel> Get()
        {
            return Date.Products.AsEnumerable();
        }

        public bool Update(ProductDomainModel model)
        {
            ProductDomainModel oldProduct = Date.Products.FirstOrDefault(x => x.Id == model.Id);
            if (oldProduct != null)
            {
                CategoryDomainModel category = Data.Date.Categories.FirstOrDefault(x => x.Id == model.CategoryId);
                if (category == null)
                {
                    return false;
                }
                oldProduct.Category = category;
                oldProduct.Name = model.Name;
                oldProduct.Price = model.Price;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            ProductDomainModel productToDelete = Date.Products.FirstOrDefault(x => x.Id == id);
            if (productToDelete != null)
            {
                Date.Products.Remove(productToDelete);
                return true;
            }
            return false;
        }
    }
}