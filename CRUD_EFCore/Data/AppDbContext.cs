using CRUD_EFCore.Models.Employees;
using Microsoft.EntityFrameworkCore;

namespace CRUD_EFCore.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
    }
}