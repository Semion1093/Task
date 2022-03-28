using Microsoft.EntityFrameworkCore;
using TestTask.API.Configuration;
using TestTask.API.Extensions;
using TestTask.BusinessLayer.Configuration;
using TestTask.DataLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

const string connectionEnvironmentVariableName = "CONNECTIONS_STRING";

var connectionString = builder.Configuration.GetValue<string>(connectionEnvironmentVariableName);
builder.Services.AddDbContext<TaskContext>(op => op.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(ApiMapper).Assembly, typeof(DataMapper).Assembly);

builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s => s.EnableAnnotations());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();