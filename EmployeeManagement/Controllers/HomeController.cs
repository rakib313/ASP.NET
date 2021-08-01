using System;
using System.Collections.Generic;
using EmployeeManagement.Models;
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
            // Pass PageTitle and Employee model to the View using ViewData
            ViewData["PageTitle"] = "Employee Details";
            ViewData["Employee"] = model;

            return View(model);
        }
    }
}