using System.ComponentModel.DataAnnotations;

namespace AwesomeApp.Models.AddProducts
{
    public class AddProductFormModel
    {
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