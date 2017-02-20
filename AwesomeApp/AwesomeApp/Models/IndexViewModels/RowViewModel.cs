using AwesomeApp.Models.Categories;

namespace AwesomeApp.Models.IndexViewModels
{
    public class RowViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public CategoryViewModel Category { get; set; }
    }
}