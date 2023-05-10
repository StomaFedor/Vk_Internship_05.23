using Microsoft.EntityFrameworkCore;
using Vk_Internship.Database;
using Vk_Internship.Database.Repositories.UserRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionStringDB = builder.Configuration.GetConnectionString("VkInternship");
builder.Services.AddDbContext<VkDbContext>(options => options.UseNpgsql(connectionStringDB));
builder.Services.AddTransient<IUserRepository, UserRepository>();

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
