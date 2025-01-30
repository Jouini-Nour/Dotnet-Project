using Dotnet_Project.Models;
using Dotnet_Project.Repositories.Employees;
using Dotnet_Project.Repositories.Feedbacks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Project.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository, IEmployeeRepository employeeRepository)
        {
            _feedbackRepository = feedbackRepository;
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            var feedbacks = _feedbackRepository.GetAllFeedbacks();
            return View(feedbacks);
        }

       

        
        [HttpPost]
        public IActionResult Create([Bind("Description,WriterId,ReceiverId")] Feedback feedback)
        {
           
            
             if (ModelState.IsValid)
                {
                feedback.Date = DateTime.Now;
                _feedbackRepository.AddFeedback(feedback);
                return RedirectToAction("EmployeeManagement", "Employee", new { id = feedback.ReceiverId });
                }            

            return RedirectToAction("EmployeeManagement", "Employee", new { id = feedback.ReceiverId });
        }



        public IActionResult Edit(int id)
        {
            var feedback = _feedbackRepository.GetFeedbackById(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Feedback feedback)
        {
            if (id != feedback.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _feedbackRepository.UpdateFeedback(feedback);
                return RedirectToAction(nameof(Index));
            }
            return View(feedback);
        }

        public IActionResult Delete(int id)
        {
            var feedback = _feedbackRepository.GetFeedbackById(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _feedbackRepository.DeleteFeedback(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EmployeeFeedbacks(int employeeId)
        {
            var employee = _employeeRepository.GetEmployeeById(employeeId);
            if (employee == null)
            {
                return NotFound();
            }

            var feedbacks = _feedbackRepository.GetFeedbacksForEmployee(employeeId);
            return View(feedbacks);
        }
    }
}
