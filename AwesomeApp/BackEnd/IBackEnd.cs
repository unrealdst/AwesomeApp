using System.Collections.Generic;
using BackEnd.Models;

namespace BackEnd
{
    public interface IBackEnd
    {
        void Set(ProductDomainModel product);

        ProductDomainModel Get(int productId);

        IEnumerable<ProductDomainModel> Get(); 

        bool Update(ProductDomainModel model);

        bool Delete(int id);
    }
}