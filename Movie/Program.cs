using Hangfire;
using IMDBprocessor;
using Microsoft.EntityFrameworkCore;
using MovieAPI;
using MovieAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();

builder.Services.AddControllers();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddDbContext<MovieContext>(
       options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.Configure<IMDBprocessorConfiguration>(builder.Configuration.GetSection("IMDBprocessorConfiguration"));
builder.Services.AddScoped<IMovieServiceManager, MovieServiceManager>()
                .AddScoped<BaseProcessor.ISideService, MovieProcessor>()
                .AddScoped<IJobRecommendService, JobRecommendService>()
                .AddScoped<IEmailServiceManager, EmailServiceManager>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddHangfire(x =>
{
    x.UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection"));
});
builder.Services.AddHangfireServer();

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

app.UseHangfireDashboard();

//RecurringJob.AddOrUpdate<JobRecommendService>("recommendService",job => job.ReccuringJob(), "30 19 * * 7", TimeZoneInfo.Local);
RecurringJob.AddOrUpdate<JobRecommendService>("recommendService", job => job.ReccuringJob(), Cron.Minutely, TimeZoneInfo.Local);

app.Run();
