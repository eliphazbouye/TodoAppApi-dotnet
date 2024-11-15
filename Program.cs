using Microsoft.OpenApi.Models;
using TodoStore.DB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
                       new OpenApiInfo
                       {
                           Title = "Todo API",
                           Description = "Keep track of your tasks",
                           Version = "v1"
                       });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
    });
}

app.MapGet("/", () => "Hello World!");
app.MapGet("/todos", () => TodoDB.GetTodos());
app.MapGet("/todos/{id:int}", (int id) => TodoDB.GetTodo(id));
app.MapPost("/todos", (Todo todo) => TodoDB.CreateTodo(todo));
app.MapPut("/todos", (Todo todo) => TodoDB.UpdateTodo(todo));
app.MapDelete("/todos/{id:int}", (int id) => TodoDB.RemoveTodo(id));

app.Run();
