using System;
using System.Collections.Generic;
using EmployeeManagement.Models;
using EmployeeManagemnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class HomeController : Controller 
    {
        private readonly IEmployeeRepository _employeeRepository;
        // Inject IEmployeeRepository using Constructor Injection
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        // Retrieve employee name and return
        public string Index() 
        {
            return _employeeRepository.GetEmployee(1).Name;
        }

        // Return .cshtml file
        public ViewResult Details() 
        {
            Employee model = _employeeRepository.GetEmployee(1);
            return View(model);
        }
    }
}