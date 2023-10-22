namespace Employee.Management.ViewModels.Employees;

public class UpdateProfileImageViewModel
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string FileExtension { get; set; } = string.Empty;
    public string FileContent { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
}