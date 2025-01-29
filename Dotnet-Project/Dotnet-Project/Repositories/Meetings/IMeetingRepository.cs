using Dotnet_Project.Models;

namespace Dotnet_Project.Repositories.Meetings
{
    public interface IMeetingRepository
    {
        Meeting Add(Meeting meeting);
        IEnumerable<Meeting> GetAll();
        Meeting? GetById(int id);
        Meeting? Update(Meeting meeting);
        bool Delete(int id);
    }
}
