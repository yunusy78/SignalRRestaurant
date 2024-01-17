using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BusinessLayer;
using BusinessLayer.Abstract;
using BusinessLayer.Validations;
using CachingLayer;
using DataAccessLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApi.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Filters;
using WebApi.Filter;
using WebApi.Middlewares;
using WebApi.Modules;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme(\"bearer {token}\"))",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});


builder.Services.AddScoped(typeof(NotFoundFilter<>));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SignalRContext>(options =>
    options.UseSqlServer(connectionString!,
        option =>
        {
            option.MigrationsAssembly(Assembly.GetAssembly(typeof(SignalRContext))!.GetName().Name);
            
        }));
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.RequireHttpsMetadata = false;
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidAudience = "http://localhost",
            ValidIssuer = "http://localhost",
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddScoped<IProductService, ProductServiceWithCaching>();
builder.Services.ContainerDependencies();
builder.Services.AddCors(opt=>
{
    opt.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials();
        });
});
builder.Services.AddSignalR();
// Add services to the container.


builder.Services.AddControllers(options=>
    { 
        options.Filters.Add(new ValidateFilterAttribute());
    }).AddFluentValidation(x=>
        x.RegisterValidatorsFromAssemblyContaining<CreateProductDtoValidator>());
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMemoryCache();
/*builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new RepoServiceModule());
});*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.MapHub<SignalRHub>("/signalrhub");
app.MapHub<SignalRBookingHub>("/signalrbookinghub");
app.MapHub<SignalRNotificationHub>("/signalrnotificationhub");
app.UseHttpsRedirection();
app.UserCustomException();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();