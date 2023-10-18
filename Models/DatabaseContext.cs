using Microsoft.EntityFrameworkCore;

namespace Employee.Management.Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }
}