using StockProject.Database_Context;
using StockProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSqlServer<DataBaseContext>("Data Source=NICOLAS-PC;Initial Catalog=SalesDataBase;user id=sa;password=12345678;TrustServerCertificate=True;");
builder.Services.AddSqlServer<DataBaseContext>(builder.Configuration.GetConnectionString("DatabaseConection"));
builder.Services.AddScoped<IProviderService, ProviderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddLogging(logging =>
{
    logging.ClearProviders(); // Limpiar cualquier proveedor de registro predeterminado
    logging.AddConsole();     // Agregar el proveedor de registro de la consola
});

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
