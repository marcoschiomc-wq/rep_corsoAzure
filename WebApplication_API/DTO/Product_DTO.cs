namespace WebApplication_API.DTO
{
    public class Product_DTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Category { get; set; } = "";
    }
}
