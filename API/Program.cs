using Application;
//using Persistence;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient();

//builder.Services.AddPersistence(builder.Configuration);
//builder.Services.AddScoped<DataverseContext>();
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetMentorList.Handler>());
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetMentorDetails.Handler>());

// Configure Swagger/OpenAPI
builder.Services.AddSwaggerGen(c =>
{

    c.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header
        });

    c.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });

    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "CFE API Proxy",
        Version = "v1",
        Description = "API to handle the requests and responses from CFE API. "
    });

    // Enable XML comments for API documentation
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
    
    // Check if XML file exists before including it
    if (System.IO.File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }

    // Customize schema IDs to avoid conflicts
    c.CustomSchemaIds(type => type.FullName);
});



builder.Services.AddAuthorization();


// Add Health Checks for container orchestration
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CFE DEV API Proxy v1"));
    app.UseDeveloperExceptionPage();
}
else
{
    // Production configuration
    app.UseExceptionHandler("/error");
    // Enable Swagger in production if needed (optional)
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CFE PROD API Proxy v1");
        c.RoutePrefix = string.Empty; // Swagger at root in production
    });
}

// Enable HTTPS redirection (important for production)
app.UseHttpsRedirection();

// Enable CORS if needed for frontend access
app.UseCors(policy => 
{
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();
});

// Uncomment when you implement authentication
// app.UseAuthentication();
// app.UseAuthorization();

// Add Health Check endpoint
app.MapHealthChecks("/health");

app.MapControllers();

app.Run();
