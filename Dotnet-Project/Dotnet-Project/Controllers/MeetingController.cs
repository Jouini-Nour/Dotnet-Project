using Dotnet_Project.Models;
using Dotnet_Project.Repositories.Employees;
using Dotnet_Project.Repositories.Meetings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Project.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IMeetingRepository _repository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ApplicationDbContext _db;

        public MeetingController(IMeetingRepository repository, ApplicationDbContext db, IEmployeeRepository er)
        {
            _repository = repository;
            _db = db;
            _employeeRepository = er;
        }

        public IActionResult Index()
        {
            var meetings = _repository.GetAll();
            ViewData["Meetings"] = meetings;
            ViewBag.Employees = new SelectList(_employeeRepository.GetAllEmployees(), "Id", "Name");

            return View();
        }

        public IActionResult Details(int id)
        {
            var meeting = _repository.GetById(id);
            if (meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }


        [HttpPost]
        public IActionResult Create(int ParticipantId, string Subject, int ModeratorId, DateOnly Date, TimeOnly Time)
        {
            var meet = new Meeting();
            meet.Subject = Subject;
            meet.Date = Date;
            meet.Time = Time;
            meet.ModeratorId = ModeratorId;
            meet.ParticipantId = ParticipantId;

            if (ModelState.IsValid)
            {
                Console.WriteLine("hereé");
                _repository.Add(meet);
                return RedirectToAction("Index");
            }

            ViewBag.Employees = new SelectList(_employeeRepository.GetAllEmployees(), "Id", "Name");
            return RedirectToAction("Index");


        }
    

        public IActionResult Edit(int id)
        {
            var meeting = _repository.GetById(id);
            if (meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Meeting meeting)
        {
            if (id != meeting.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var updatedMeeting = _repository.Update(meeting);
                if (updatedMeeting == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(meeting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var meeting = _repository.GetById(id);  
            if (meeting == null)
            {
                return NotFound();  
            }
            var success = _repository.Delete(id);  
            if (!success)
            {
                return NotFound();  
            }
            return RedirectToAction(nameof(Index));  
        }
    }
}
