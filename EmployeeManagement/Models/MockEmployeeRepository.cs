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
                new Employee() { ID = 1, Name = "Mary", Department = Dept.HR, Email = "mary@pragimtech.com" },
                new Employee() { ID = 2, Name = "John", Department = Dept.IT, Email = "john@pragimtech.com" },
                new Employee() { ID = 3, Name = "Sam", Department = Dept.IT, Email = "sam@pragimtech.com" },
            };
        }

        public Employee Add(Employee employee)
        {
            employee.ID =  _employeeList.Max(employee=>employee.ID) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int ID)
        {
            return _employeeList.FirstOrDefault(employee => employee.ID == ID);
        }
        
    }
}