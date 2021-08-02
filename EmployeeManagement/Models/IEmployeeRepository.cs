using System;
using System.Collections.Generic;
namespace EmployeeManagement.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int ID);
        // Retrive all Employees
        IEnumerable<Employee> GetAllEmployees();
    }
}