using System.ComponentModel.DataAnnotations;

namespace Employee.Management.ViewModels.Employees;

public class CreateViewModel
{
    [Required(ErrorMessage = "Name cannot be empty!")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email cannot be empty!")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Address cannot be empty!")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone Number cannot be empty!")]
    public string PhoneNumber { get; set; } = string.Empty;
    public IFormFile? File { get; set; } = default!;
}