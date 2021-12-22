using IMDBprocessor;
using Microsoft.EntityFrameworkCore;
using MovieAPI;
using MovieAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MovieContext>(
       options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.Configure<IMDBprocessorConfiguration>(builder.Configuration.GetSection("IMDBprocessorConfiguration"));
builder.Services.AddScoped<IMovieServiceManager, MovieServiceManager>();
builder.Services.AddScoped<BaseProcessor.ISideService, MovieProcessor>();
//builder.Services.AddScoped<ISideService, MovieProcessor>();>
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


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<MovieContext>();
    context.Database.EnsureCreated(); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
 
app.Run();
