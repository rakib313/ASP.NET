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
            ViewBag.PageTitle = "Employee Details";
            // using strongy typed data to pass data from controller to view
            return View(model);
        }
    }
}