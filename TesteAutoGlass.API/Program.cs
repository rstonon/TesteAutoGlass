using Microsoft.EntityFrameworkCore;
using TesteAutoGlass.Application.Commands.CreateProduct;
using TesteAutoGlass.Core.Repositories;
using TesteAutoGlass.Infrastructure.Persistence;
using TesteAutoGlass.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("conn");
builder.Services.AddDbContext<AutoGlassDbContext>(p => p.UseSqlServer(connectionString));
//builder.Services.AddDbContext<AutoGlassDbContext>(options => options.UseInMemoryDatabase("conn"));

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers();

//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Product)));

builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateProductCommand).Assembly); });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
