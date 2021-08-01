using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { ID = 1, Name = "Mary", Department = "HR", Email = "mary@pragimtech.com" },
                new Employee() { ID = 2, Name = "John", Department = "IT", Email = "john@pragimtech.com" },
                new Employee() { ID = 3, Name = "Sam", Department = "IT", Email = "sam@pragimtech.com" },
            };
        }
        public Employee GetEmployee(int ID)
        {
            return _employeeList.FirstOrDefault(employee => employee.ID == ID);
        }
        
    }
}