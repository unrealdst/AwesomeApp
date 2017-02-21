using System.Collections.Generic;
using AwesomeApp.Models.Categories;

namespace AwesomeApp.Models.AddProducts
{
    public class AddProductViewModel : AddProductFormModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }

    }
}