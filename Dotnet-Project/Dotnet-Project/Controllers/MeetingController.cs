using Dotnet_Project.Models;
using Dotnet_Project.Repositories.Meetings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Project.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IMeetingRepository _repository;
        private readonly ApplicationDbContext _db;

        public MeetingController(IMeetingRepository repository, ApplicationDbContext db)
        {
            _repository = repository;
            _db = db;
        }

        public IActionResult Index()
        {
            var meetings = _repository.GetAll();
            ViewData["Meetings"] = meetings;
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
        public IActionResult Create(Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(meeting);
                return RedirectToAction("Index");
            }

            ViewBag.Employees = new SelectList(_db.Employees, "Id");
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
