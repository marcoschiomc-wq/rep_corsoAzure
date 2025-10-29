namespace WebApplication_API.TodoItems;

public record TodoItem(int Id, string Title, bool IsDone, string Cat);
public record CreateTodoItem(string Title, string Cat);
interface ITodoItems
{
    Task<List<TodoItem>> GetAllItems();
    Task<TodoItem?> GetItem(int Id);
    Task<TodoItem> CreateItem(CreateTodoItem newItem);
    Task UpdateItem(TodoItem modItem);
    Task DeleteItem(int id);
}

public interface GenericCrud<T, U>
{
    Task<List<T>> GetAllItems();
    Task<T?> GetItem(U Id);
    Task<T> CreateItem(CreateTodoItem newItem);
    Task UpdateItem(T modItem);
    Task DeleteItem(U id);
}
