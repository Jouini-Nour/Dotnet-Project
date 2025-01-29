using Dotnet_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Project.Repositories.Meetings
{
    public class MeetingRepository : IMeetingRepository
    {
       
            private readonly ApplicationDbContext _context;

            public MeetingRepository(ApplicationDbContext context)
            {
                _context = context;
            }

            public Meeting Add(Meeting meeting)
            {
                _context.Set<Meeting>().Add(meeting);
                _context.SaveChanges();
                return meeting;
            }

            public IEnumerable<Meeting> GetAll()
            {
                return _context.Set<Meeting>()
                            .Include(m => m.Participant)
                           .Include(m => m.Moderator)
                           .ToList();
            }

            public Meeting? GetById(int id)
            {
                return _context.Set<Meeting>().Find(id);
            }

            public Meeting? Update(Meeting meeting)
            {
                var existingMeeting = _context.Set<Meeting>().Find(meeting.Id);
                if (existingMeeting == null)
                {
                    return null;
                }

                _context.Entry(existingMeeting).CurrentValues.SetValues(meeting);
                _context.SaveChanges();
                return existingMeeting;
            }

            public bool Delete(int id)
            {
                var meeting = _context.Set<Meeting>().Find(id);
                if (meeting == null)
                {
                    return false;
                }

                _context.Set<Meeting>().Remove(meeting);
                _context.SaveChanges();
                return true;
            }
        }
}

