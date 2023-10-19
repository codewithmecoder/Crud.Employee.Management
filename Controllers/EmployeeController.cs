using Employee.Management.ViewModels.Employees;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Management.Controllers;

public class EmployeeController : Controller
{
    public IActionResult Index()
    {
        return View();
    } 
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            return View(model);
        }
        return View();
    }
}