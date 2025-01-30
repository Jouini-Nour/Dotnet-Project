using Dotnet_Project.Models;
using System.Collections.Generic;

namespace Dotnet_Project.Repositories.Feedbacks
{
    public interface IFeedbackRepository
    {
        IEnumerable<Feedback> GetAllFeedbacks();
        Feedback GetFeedbackById(int id);
        IEnumerable<Feedback> GetFeedbacksForEmployee(int employeeId);
        void AddFeedback(Feedback feedback);
        void UpdateFeedback(Feedback feedback);
        void DeleteFeedback(int id);
    }
}
