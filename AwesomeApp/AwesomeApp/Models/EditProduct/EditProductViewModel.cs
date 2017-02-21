using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AwesomeApp.Models.Categories;

namespace AwesomeApp.Models.EditProduct
{
    public class EditProductViewModel : EditProductFormModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}