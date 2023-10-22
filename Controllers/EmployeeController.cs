using Employee.Management.Repositories.Interfaces;
using Employee.Management.ViewModels.Employees;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Management.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeRepository _repository;

    public EmployeeController(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var employees = await _repository.GetAsync();
        return View(employees);
    } 
    
    public IActionResult Create()
    {
        return View();
    }

    public async Task<IActionResult> Update(int id)
    {
        var employee = await _repository.GetByIdAsync(id);

        if (employee is null) return View();
        
        // var imageBytes = await System.IO.File.ReadAllBytesAsync($"{_environment.WebRootPath}/images/employees/{employee.ProfilePhoto}");
        //
        // using var imageStream = new MemoryStream(imageBytes);
        return View(new UpdateEmployeeViewModel
        {
            // File = new FormFile(imageStream, 0, imageBytes.Length, employee.ProfilePhoto ?? "", employee.ProfilePhoto ?? ""),
            PhoneNumber = employee.PhoneNumber,
            CreatedAt = employee.CreatedAt,
            Email = employee.Email,
            Name = employee.Name,
            Address = employee.Address,
            Id = employee.Id
        });
    }

    public async Task<IActionResult> Detail(int id)
    {
        var employee = await _repository.GetByIdAsync(id);
        return View(employee);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        await _repository.CreateEmployeeAsync(model);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateEmployeeViewModel m)
    {
        if (!ModelState.IsValid) return View(m);
        var isUpdateSuccess = await _repository.UpdateAsync(m);
        if (isUpdateSuccess) return RedirectToAction("Index");
        return View(m);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProfileImage(UpdateProfileImageViewModel m)
    {
        var isUploadSuccess = await _repository.UpdateProfileImageAsync(m);
        return Ok(isUploadSuccess);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var isDeleteSuccess = await _repository.DeleteAsync(id);
        return Ok(isDeleteSuccess);
    }
}