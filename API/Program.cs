using Application;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddScoped<DataverseContext>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetMentorList.Handler>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetMentorDetails.Handler>());
// Configure Swagger/OpenAPI
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Admin Matching API",
        Version = "v1",
        Description = "API to handle the requests and responses from Futurpreneur Admin Matching Portal. ",
        /*Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Your Company/Team",
            Email = "contact@yourcompany.com",
            Url = new Uri("https://www.yourcompany.com")
        },
        License = new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name = "Your License Name",
            Url = new Uri("https://www.yourcompany.com/license")
        }*/
    });

   

    // 1. Enable XML comments for API documentation
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);


    // 3. Optional: Customize schema IDs to avoid conflicts (useful if you have duplicate class names in different namespaces)
    c.CustomSchemaIds(type => type.FullName);
});
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    // Enable Swagger in development mode
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin Matching API v1"));
    app.UseDeveloperExceptionPage();
}

// Configure the HTTP request pipeline.
//app.UseAuthorization();



app.MapControllers();

app.Run();
