using WebApplication_API.Controllers;

namespace WebApplication_API;

public class ProductService : IProducts
{
    public IEnumerable<Controllers.Product> GetAll()
    {
        return new List<Controllers.Product>()
        {
            new Controllers.Product{Id=1,Name="prova",Cat="prod"},
            new Controllers.Product{Id=2,Name="test",Cat="" },
        };
    }
}
