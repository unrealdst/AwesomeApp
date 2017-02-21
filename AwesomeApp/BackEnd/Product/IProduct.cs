using System.Collections.Generic;
using BackEnd.Models;

namespace BackEnd.Product
{
    public interface IProduct
    {
        void Add(ProductDomainModel product);

        ProductDomainModel Get(int productId);

        IEnumerable<ProductDomainModel> Get(); 

        bool Update(ProductDomainModel model);

        bool Delete(int id);
    }
}