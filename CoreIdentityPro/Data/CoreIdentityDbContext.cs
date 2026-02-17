using CoreIdentityPro.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class CoreIdentityDbContext : IdentityDbContext
{
    public CoreIdentityDbContext(DbContextOptions<CoreIdentityDbContext> options) : base(options)
    {

    }
    public DbSet<Employee> Employees { get; set; }
}