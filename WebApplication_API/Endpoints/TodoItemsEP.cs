using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_API.Endpoints;

public static class TodoItemsEP
{

    private static async Task<IResult> GetAll(ITodoItems service)
    {
        return Results.Ok(await service.GetAllItems());
    }

    public static void RegisterEP(this WebApplication app)
    {
        var group = app.MapGroup("/todoItems");

        group.MapGet("/", GetAll);

        group.MapGet("/{id}", async (int id, ITodoItems service) =>
        {
            var item = await service.GetItem(id);
            if (item == null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(item);
            }
        });

        group.MapPost("/", async (CreateTodoItem newItem, ITodoItems service) =>
        {
            if (newItem.Title == null) return Results.BadRequest();
            if (newItem.Cat == null) return Results.BadRequest();
            var todo = await service.CreateItem(newItem);
            return Results.Created($"/todoitems/{todo.Id}", todo);
        });

        group.MapPut("{id}", async (int id, TodoItem item, ITodoItems service) =>
        {
            if (id != item.Id) return Results.BadRequest();
            await service.UpdateItem(item);
            return Results.NoContent();
        });

        group.MapPatch("{id}", async (int id, TodoItem item, ITodoItems service) =>
        {
            if (id != item.Id) return Results.BadRequest();
            await service.UpdateItem(item);
            return Results.NoContent();
        });

        group.MapDelete("{id}", async (int id, ITodoItems service) =>
        {
            await service.DeleteItem(id);
            return Results.NoContent();

        });

        app.MapGet("/BOOM", () =>
        {
            throw new InvalidProgramException("Scoppia tutto zi BOOOOOOOOOM");
        });

        //risultati da db
        app.MapGet("/product", async (tempdbContext context) =>
        {
            var data = await context.Products.Select
            (p => new Product_DTO
            {
                Id = p.ProductId,
                Name = p.ProductName,
                Category = p.Category.CategoryName
            }).ToListAsync();
            return Results.Ok(data);

        });

    }
}
