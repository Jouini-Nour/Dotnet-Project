using Dotnet_Project.Models;

namespace Dotnet_Project.Repositories.Employees
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();  
        Employee GetEmployeeById(int id);  
        void AddEmployee(Employee employee); 
        void UpdateEmployee(Employee employee); 
        void DeleteEmployee(int id);
        int GetTotalEmployees();
        int GetMaleEmployees();
        int GetFemaleEmployees();
    }
}
