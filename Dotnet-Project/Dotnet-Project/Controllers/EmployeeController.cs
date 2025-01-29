using Dotnet_Project.Models;
using Dotnet_Project.Repositories.Employees;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_Project.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.AddEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public IActionResult Edit(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _employeeRepository.UpdateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        public IActionResult Profile(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return PartialView("_EmployeeDetails", employee);
        }
        public IActionResult Delete(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EmployeeManagement(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);  // Récupérer l'employé par ID
            if (employee == null)
            {
                return NotFound();
            }

            // Passer l'employé au modèle de la partial view
            return View("EmployeeManagement", employee);
        }
    }
}

