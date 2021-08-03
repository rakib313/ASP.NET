using System;
using System.Collections.Generic;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
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
        public ViewResult Index() 
        {
            // Retrive all employees
            var model = _employeeRepository.GetAllEmployees();
            // Pass List of employees to the View
            return View(model);
        }

        // Return .cshtml file
        public ViewResult Details(int? id) 
        {
            // Pass data to view using ViewModel
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                PageTitle = "Employee Details",
                Employee = _employeeRepository.GetEmployee(id??1)
            };
            return View(homeDetailsViewModel);
        }
    }
}