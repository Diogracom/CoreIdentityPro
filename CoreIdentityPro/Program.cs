using CoreIdentityPro.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DbConnectionString");
builder.Services.AddDbContext<CoreIdentityDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(
    options =>
    {
        options.Password.RequiredLength = 10;
        options.Password.RequiredUniqueChars = 3;
    })    .AddEntityFrameworkStores<CoreIdentityDbContext>();

/*
 * overrriding the the register option
 builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequiredLength = 10;
    opt.Password.RequiredUniqueChars = 3;
});
*/


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
