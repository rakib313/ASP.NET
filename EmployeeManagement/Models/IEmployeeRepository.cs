using System;
using EmployeeManagemnet.Models;

namespace EmployeeManagement.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int ID);
    }
}