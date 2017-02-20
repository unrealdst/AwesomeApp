using System.Collections.Generic;
using AwesomeApp.Models.Categories;

namespace AwesomeApp.Models.AddProducts
{
    public class AddProductViewModel
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public List<CategoryViewModel> Categories { get; set; }
    }
}