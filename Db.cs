namespace TodoStore.DB;
using System.Collections.Generic;


public record Todo
{
    public int Id { get; set; }
    public required string? Title { get; set; }
    public bool Done { get; set; }
}

public class TodoDB
{
    private static List<Todo> _todos = new List<Todo>()
    {
       new Todo{ Id=1, Title="Make small api in dotnet core api", Done=false },
       new Todo{ Id=2, Title="Make small api in Java SpringBoot", Done=false },
       new Todo{ Id=3, Title="Done this part", Done=true }
    };

    public static List<Todo> GetTodos()
    {
        return _todos;
    }

    public static Todo? GetTodo(int id)
    {
        return _todos.SingleOrDefault(todo => todo.Id == id);
    }

    public static Todo CreateTodo(Todo todo)
    {
        bool check = _todos.Contains(todo);
        if (check)
        {
            throw new InvalidDataException("Todo already exist");
        }

        _todos.Add(todo);
        return todo;
    }

    public static Todo UpdateTodo(Todo update)
    {
        _todos = _todos.Select(todo =>
        {
            if (todo.Id == update.Id)
            {
                todo.Title = update.Title;
                todo.Done = update.Done;
            }
            return todo;
        }).ToList();
        return update;
    }

    public static void RemoveTodo(int id)
    {
        Todo todoItem = _todos.Single(todo => todo.Id == id);
        _todos.Remove(todoItem);
    }
}
