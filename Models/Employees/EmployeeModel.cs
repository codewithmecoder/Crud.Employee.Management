using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Management.Models.Employees;

public class EmployeeModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? ProfilePhoto { get; set; }

    [NotMapped]
    public IFormFile File { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }
}