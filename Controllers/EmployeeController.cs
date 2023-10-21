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

    public IActionResult Index()
    {
        return View();
    } 
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        await _repository.CreateEmployeeAsync(model);
        return RedirectToAction("Index");
    }
}