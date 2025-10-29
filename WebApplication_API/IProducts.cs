using WebApplication_API.Controllers;

namespace WebApplication_API;

public interface IProducts
{
    IEnumerable<Controllers.Product> GetAll();
}
