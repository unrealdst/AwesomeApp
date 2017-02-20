namespace BackEnd.Models
{
    public class ProductDomainModel
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public double Price { get; set; }

        public CategoryDomainModel Category { get; set; }
    }
}