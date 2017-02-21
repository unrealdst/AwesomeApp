using System.Collections.Generic;
using System.Linq;
using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.Category
{
    public class Category : ICategory
    {
        public IEnumerable<CategoryDomainModel> Get()
        {
            return Date.Categories.AsEnumerable();
        }
    }
}