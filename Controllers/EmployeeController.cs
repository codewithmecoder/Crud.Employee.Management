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
}