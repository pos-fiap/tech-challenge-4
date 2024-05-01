using Microsoft.EntityFrameworkCore;
using TechChallenge4.Infra.Data.Context;
using TechChallenge4.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterServices();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("Connection string not found");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
