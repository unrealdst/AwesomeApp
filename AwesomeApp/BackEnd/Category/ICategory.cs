using System.Collections.Generic;
using BackEnd.Models;

namespace BackEnd.Category
{
    public interface ICategory
    {
        IEnumerable<CategoryDomainModel> Get();
    }
}