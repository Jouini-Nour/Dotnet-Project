using Dotnet_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Project.Repositories.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees
                            .Include(e => e.Tasks)
                            .ToList();        
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees
                .Include(e => e.Tasks)
                .Include(e => e.ReceivedFeedbacks)
                
                .FirstOrDefault(e => e.Id == id);
                
     
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
        public int GetTotalEmployees()
        {
            return _context.Employees.Count();
        }

        public int GetMaleEmployees()
        {
            return _context.Employees.Count(e => e.Gender == Gender.Male);
        }

        public int GetFemaleEmployees()
        {
            return _context.Employees.Count(e => e.Gender == Gender.Female);
        }
    }
}
