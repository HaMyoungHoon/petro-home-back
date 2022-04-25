using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using petro_home_back.Data.Advice;
using petro_home_back.Data.Security;
using petro_home_back.Repository.Base;
using petro_home_back.Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HomepageDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped(typeof(HomepageService));
builder.Services.AddScoped(typeof(FileService));

builder.Services.AddDbContext<MsSQLDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("localConnection")));
builder.Services.AddScoped(typeof(IMSRepository<>), typeof(MSRepository<>));
builder.Services.AddScoped(typeof(MsSQLService));


builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(config =>
{
    config.AddPolicy(Policies.ADMIN, Policies.AdminPolicy());
    config.AddPolicy(Policies.USER, Policies.UserPolicy());
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
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
