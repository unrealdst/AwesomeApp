using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AwesomeApp.Models.Categories;

namespace AwesomeApp.Models.AddProducts
{
    public class AddProductViewModel
    {
        [Required]
        [MinLength(6)]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}