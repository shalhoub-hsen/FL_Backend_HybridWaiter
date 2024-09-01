using HybridWaiterDataLayer;
using Microsoft.EntityFrameworkCore;
using HybridWaiterDataLayer.Infrastructure;
using HybridWaiterServiceLayer.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddDbContext<HybridWaiterModel>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseDB")));

//Add Configuration for class and Interfaces
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();
builder.Services.AddCustomConfiguredAutoMapper();
/*builder.Services.AddCustomRepositoriesFingerPrints()*/;   

builder.Services.AddCustomRepositories();
//builder.Services.AddCustomRepositories(Assembly.GetExecutingAssembly());

builder.Services.AddCustomServices();
//builder.Services.AddTransient<ITokenService, TokenService>();


builder.Services.AddMvc();
//string[] origins = builder.Configuration.GetRequiredSection("CORSOrigins").Get<string[]>();

// start authentication

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                     .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                     {
                         //options.Authority = "localhost";

                         options.TokenValidationParameters = new TokenValidationParameters
                         {
                             ValidIssuer = "localhost",
                             ValidateAudience = false,
                             IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("CJKFOGk-9E0aI8Gv09mD-8utzSyLQx_yrJKi1fXc6Y7CeYszLzcmMA2C0_Ej3K7BQdsCW9zoqW3a-5L1ZNRytFC0BeA6dZLsCjoTrFoI9guwvEmJ0gbN9yHQ0fDYbkwGUyJbP6eNEzKbWHMarSx7RWGKaGsxy0qguEMSO3OUWU8"))
                         };
                     });

// Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();


// end authentication

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();


app.UseAuthorization();



app.UseCors(builder =>
        builder
        .WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseStaticFiles();

app.MapControllers();

app.Run();
