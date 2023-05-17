using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TasksContext>(p => p.UseInMemoryDatabase("TasksDB"));
builder.Services.AddSqlServer<TasksContext>("Data Source=DESKTOP-K21Q9MA\\MSSQLSERVER01; initial Catalog=TasksDb; Trusted_Connection=True; Integrated Security=True; TrustServerCertificate=True");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconnection", async ([FromServices] TasksContext dbContext) => {
    dbContext.Database.EnsureCreated();
    return Results.Ok("Databes in memory: " + dbContext.Database.IsInMemory());
});

app.Run();
