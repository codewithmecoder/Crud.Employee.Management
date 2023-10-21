using Employee.Management.ViewModels.Employees;

namespace Employee.Management.Repositories.Interfaces;

public interface IEmployeeRepository
{
   Task CreateEmployeeAsync(CreateViewModel m, CancellationToken token = default);
}