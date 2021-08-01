using System;
using System.Collections.Generic;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class HomeController : Controller 
    {
        private IEmployeeRepository _emoloyeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _emoloyeeRepository = employeeRepository;
        }
        public string Index() 
        {
            return _emoloyeeRepository.GetEmployee(1).Name;
        }
    }
}