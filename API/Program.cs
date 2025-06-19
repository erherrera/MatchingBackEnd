using Application.Mentors.Queries;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPersistence(builder.Configuration); 
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetMentorList.Handler>());
var app = builder.Build();

// Configure the HTTP request pipeline.
//app.UseAuthorization();

app.MapControllers();

app.Run();
