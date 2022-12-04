using Microsoft.OpenApi.Models;
using Zip.InstallmentsService;
using Newtonsoft.Json;
using Zip.InstallmentsService.ViewModels;
using Zip.InstallmentsRestApi.Filters;
using Zip.InstallmentsRestApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMvcCore(option =>
{
    option.Filters.Add(new RequestValidationFilter());
});

// Inject the Dependancy to instantiate service classes.  
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


// Swagger support with API details
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Installment Calculator",
        Description = "a Web API for Managing the payment plan and calculate the Installments",
       
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // Custom exception to be shown in Prod environment instead of  actual exception details 
    app.ConfigureCustomException();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
