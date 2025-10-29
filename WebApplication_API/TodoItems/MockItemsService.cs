namespace WebApplication_API.TodoItems;

class MockItems : ITodoItems
{

    private static List<TodoItem> todoItems = new List<TodoItem>() {
    new TodoItem(1,"1",false,"Sport"),
    new TodoItem(2,"2",true,"Cronaca"),
    new TodoItem(3,"3",true,"Altro"),
};
    public async Task<List<TodoItem>> GetAllItems()
    {
        await Task.Delay(1000);
        return todoItems;
    }

    public async Task<TodoItem?> GetItem(int Id)
    {
        await Task.Delay(1000);
        var item = todoItems.FirstOrDefault(x => x.Id == Id);
        return item;
    }

    public async Task<TodoItem> CreateItem(CreateTodoItem newItem)
    {
        await Task.Delay(1000);
        var newID = 0;
        if (todoItems.Count == 0)
            newID = 1;
        else
            newID = todoItems.Max(i => i.Id) + 1;
        var item = new TodoItem(newID, newItem.Title, false, newItem.Cat);
        todoItems.Add(item);
        return item;
    }

    public async Task UpdateItem(TodoItem modItem)
    {
        await Task.Delay(1000);
        var item = todoItems.FirstOrDefault(x => x.Id == modItem.Id);
        if (item != null)
        {
            var newItem = item with
            {
                Title = modItem.Title,
                Cat = modItem.Cat,
                IsDone = modItem.IsDone,
            };
            todoItems.Remove(item);
            todoItems.Add(newItem);
        }
    }

    public async Task DeleteItem(int id)
    {
        await Task.Delay(1000);
        var item = todoItems.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            todoItems.Remove(item);
        }
    }
}
