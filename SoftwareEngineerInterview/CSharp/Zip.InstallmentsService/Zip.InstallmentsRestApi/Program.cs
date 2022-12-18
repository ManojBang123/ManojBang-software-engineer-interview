using Microsoft.OpenApi.Models;
using Zip.InstallmentsService;
using Newtonsoft.Json;
using Zip.InstallmentsService.ViewModels;
using Zip.InstallmentsRestApi.Filters;
using Zip.InstallmentsRestApi.Middleware;
using Zip.InstallmentsService.Persistence;
using Microsoft.EntityFrameworkCore;
using Zip.InstallmentsService.Domain.UnitOfWork;
using Zip.InstallmentsService.Persistence.UnitOfWork;
using Zip.InstallmentsService.Services;
using AutoMapper;
using Zip.InstallmentsService.Services.Mapper;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMvcCore(option =>
{
    option.Filters.Add(new RequestValidationFilter());
});


var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new PaymentPlanMapper());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Inject the Dependancy to instantiate DBContext classes. 
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<ZipInstallmentsServiceDbContext>(option =>
{
    option.UseInMemoryDatabase(configuration.GetConnectionString("ZipInstallmentServiceInMemoryDatabase"));
});


// Inject the Dependancy to instantiate service classes.  
builder.Services.AddScoped<IPaymentPlanService, PaymentPlanService>();









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

public partial class Program { }
