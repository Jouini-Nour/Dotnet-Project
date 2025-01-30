using Dotnet_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Dotnet_Project.Repositories.Feedbacks
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _context;

        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Feedback> GetAllFeedbacks()
        {
            return _context.Feedbacks
                .Include(f => f.Writer)
                .Include(f => f.Receiver)
                .ToList();
        }

        public Feedback GetFeedbackById(int id)
        {
            return _context.Feedbacks
                .Include(f => f.Writer)
                .Include(f => f.Receiver)
                .FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Feedback> GetFeedbacksForEmployee(int employeeId)
        {
            return _context.Feedbacks
                .Where(f => f.ReceiverId == employeeId)
                .Include(f => f.Writer)
                .ToList();
        }

        public void AddFeedback(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
        }

        public void UpdateFeedback(Feedback feedback)
        {
            _context.Feedbacks.Update(feedback);
            _context.SaveChanges();
        }

        public void DeleteFeedback(int id)
        {
            var feedback = _context.Feedbacks.Find(id);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
                _context.SaveChanges();
            }
        }
    }
}
