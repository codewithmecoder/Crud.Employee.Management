using Employee.Management.Models;
using Employee.Management.Models.Employees;
using Employee.Management.Repositories.Interfaces;
using Employee.Management.ViewModels.Employees;
using Microsoft.EntityFrameworkCore;

namespace Employee.Management.Repositories.Implementations;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly DatabaseContext _context;
    private readonly IWebHostEnvironment _environment;

    public EmployeeRepository(DatabaseContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public async Task CreateEmployeeAsync(CreateViewModel m, CancellationToken token = default)
    {
        string? fileName = null;
        var empPath = "";

        if (m.File is not null)
        {
            var wwwrootPath = _environment.WebRootPath;
            fileName = $"{Guid.NewGuid().ToString().Replace("-", "")}-{m.File?.FileName}";
            empPath = Path.Join(wwwrootPath, $@"images\employees\{fileName}");
        }

        var newEmployee = new EmployeeModel
        {
            Address = m.Address,
            Email = m.Email,
            Name = m.Name,
            CreatedAt = DateTime.UtcNow,
            PhoneNumber = m.PhoneNumber,
            ProfilePhoto = fileName,
            UpdatedAt = DateTime.UtcNow,
        };
        await using var transaction = await _context.Database.BeginTransactionAsync(token);
        await _context.Employees.AddAsync(newEmployee, token);
        var isSuccess = await _context.SaveChangesAsync(token);
        
        if (m.File is not null && isSuccess == 1)
        {
            await using var fileStream = new FileStream(empPath, FileMode.Create);
            await m.File.CopyToAsync(fileStream, token);
        }

        await transaction.CommitAsync(token);
    }

    public Task<List<EmployeeModel>> GetAsync(CancellationToken token = default)
    {
        return _context.Employees.ToListAsync(token);
    }

    public Task<EmployeeModel?> GetByIdAsync(int id, CancellationToken token = default)
    {
        return _context.Employees.FirstOrDefaultAsync(i => i.Id == id, token);
    }
}