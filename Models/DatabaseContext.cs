using Employee.Management.Models.Employees;
using Microsoft.EntityFrameworkCore;

namespace Employee.Management.Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }

    public DbSet<EmployeeModel> Employees { get; set; } = default!;
}