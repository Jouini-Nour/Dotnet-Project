using Dotnet_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Project.Repositories.Meetings
{
    public class MeetingRepository
    {
       
            private readonly DbContext _context;

            public MeetingRepository(DbContext context)
            {
                _context = context;
            }

            public Meeting Add(Meeting meeting)
            {
                _context.Set<Meeting>().Add(meeting);
                _context.SaveChanges();
                return meeting;
            }

            public List<Meeting> GetAll()
            {
                return _context.Set<Meeting>().ToList();
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

