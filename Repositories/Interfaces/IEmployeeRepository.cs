using Employee.Management.Models.Employees;
using Employee.Management.ViewModels.Employees;

namespace Employee.Management.Repositories.Interfaces;

public interface IEmployeeRepository
{
   Task CreateEmployeeAsync(CreateViewModel m, CancellationToken token = default);
   Task<List<EmployeeModel>> GetAsync(CancellationToken token = default);
   Task<EmployeeModel?> GetByIdAsync(int id, CancellationToken token = default);
   Task<bool> UpdateAsync(UpdateEmployeeViewModel m, CancellationToken cancellationToken = default);
   Task<bool> UpdateProfileImageAsync(UpdateProfileImageViewModel m, CancellationToken token = default);
   Task<bool> DeleteAsync(int id, CancellationToken token = default);
}