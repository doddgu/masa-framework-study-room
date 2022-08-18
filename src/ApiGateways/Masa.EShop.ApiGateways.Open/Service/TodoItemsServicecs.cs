using Microsoft.EntityFrameworkCore;

namespace Masa.EShop.ApiGateways.Open.Service
{
    public class TodoItemsServicecs : ServiceBase
    {
        public TodoItemsServicecs(IServiceCollection services) : base(services)
        {
            App.MapGet("/todoitems", async (TodoDb db) =>
    await db.Todos.ToListAsync());

            App.MapGet("/todoitems/complete", async (TodoDb db) =>
                await db.Todos.Where(t => t.IsComplete).ToListAsync());

            App.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
                await db.Todos.FindAsync(id)
                    is Todo todo
                        ? Results.Ok(todo)
                        : Results.NotFound());

            App.MapPost("/todoitems", async (Todo todo, TodoDb db) =>
            {
                db.Todos.Add(todo);
                await db.SaveChangesAsync();

                return Results.Created($"/todoitems/{todo.Id}", todo);
            });

            App.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoDb db) =>
            {
                var todo = await db.Todos.FindAsync(id);

                if (todo is null) return Results.NotFound();

                todo.Name = inputTodo.Name;
                todo.IsComplete = inputTodo.IsComplete;

                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            App.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
            {
                if (await db.Todos.FindAsync(id) is Todo todo)
                {
                    db.Todos.Remove(todo);
                    await db.SaveChangesAsync();
                    return Results.Ok(todo);
                }

                return Results.NotFound();
            });
        }
    }
}
