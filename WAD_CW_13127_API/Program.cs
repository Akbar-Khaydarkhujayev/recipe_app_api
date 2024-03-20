using Microsoft.EntityFrameworkCore;
using WAD_CW_13127_API.Data;
using WAD_CW_13127_API.Models;
using WAD_CW_13127_API.Repositories;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";



var builder = WebApplication.CreateBuilder(args);





builder.Services.AddCors(options =>

{

    options.AddPolicy(MyAllowSpecificOrigins,

               policy =>

               {

                   policy.WithOrigins("http://localhost:4200")

                           .AllowAnyHeader()

                           .AllowAnyMethod()

                           .AllowAnyOrigin();

               });

});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GeneralDBContext>(
    o => o.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServerConnection")));

builder.Services.AddScoped<IRepository<Recipe>, RecipeRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();