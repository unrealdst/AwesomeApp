using System.ComponentModel.DataAnnotations;

namespace AwesomeApp.Models.AddProducts
{
    public class AddProductInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}