using System;
using System.Collections.Generic;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class HomeController : Controller 
    {
        private IEmployeeRepository _emoloyeeRepository;
        // Inject IEmployeeRepository using Constructor Injection
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _emoloyeeRepository = employeeRepository;
        }
        // Retrieve employee name and return
        public string Index() 
        {
            return _emoloyeeRepository.GetEmployee(1).Name;
        }
    }
}