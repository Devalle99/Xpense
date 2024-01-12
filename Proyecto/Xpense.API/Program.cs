using Xpense.application.Categories;
using Xpense.application.Categories.Interfaces;
using Xpense.application.Expenses;
using Xpense.application.Expenses.Interfaces;
using Xpense.infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add application layer
builder.Services.AddTransient<IExpenseService, ExpenseService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

// Add infrastructure layer
builder.Services.AddInfraestructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
