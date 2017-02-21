using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AwesomeApp.Models.Categories;

namespace AwesomeApp.Models.EditProduct
{
    public class EditProductFormModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [MinLength(6)]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}