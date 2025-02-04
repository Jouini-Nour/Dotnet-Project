using Dotnet_Project.Models;
using Dotnet_Project.Repositories.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Project.Controllers

{
    [Authorize(Roles = "HR Manager, Project Manager")]

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
            var totalEmployees = _employeeRepository.GetTotalEmployees();
            var maleEmployees = _employeeRepository.GetMaleEmployees();
            var femaleEmployees = _employeeRepository.GetFemaleEmployees();
            ViewData["TotalEmployees"] = totalEmployees;
            ViewData["MaleEmployees"] = maleEmployees;
            ViewData["FemaleEmployees"] = femaleEmployees;

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
            Feedback f=new Feedback();
            employee.ReceivedFeedbacks.Add(f);

            return View("Views/Profile/Index.cshtml", employee);


        }

        [HttpPost]
        public IActionResult UpdateEvaluation(int id, Evaluation evaluation)
        {
            Employee employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            

            employee.Evaluation = evaluation;
            _employeeRepository.UpdateEmployee(employee);

            return View("Views/Profile/Index.cshtml", employee);
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
            ViewBag.Employees = _employeeRepository.GetAllEmployees().ToList();
            return View("EmployeeManagement", employee);
        }
        public IActionResult EmployeeProductivity(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);  // Récupérer l'employé par ID
            if (employee == null)
            {
                return NotFound();
            }
            ViewBag.Employees = _employeeRepository.GetAllEmployees().ToList();
            return View("Views/Profile/Index.cshtml", employee);
        }

    }
}

