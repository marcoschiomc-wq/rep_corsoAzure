namespace WebApplication_API.Controllers;

public class Product
{
    //public OggettoComplesso Id { get; set; } = new();
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Cat { get; set; } = string.Empty;
}

public class OggettoComplesso
{
    public int Id1 { get; set; }
    public int Id2 { get; set; }
    public int Id3 { get; set; }

}

