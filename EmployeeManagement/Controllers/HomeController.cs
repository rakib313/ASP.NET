using System;
using System.Collections.Generic;
using System.IO;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller 
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        // Inject IEmployeeRepository using Constructor Injection
        public HomeController(IEmployeeRepository employeeRepository,
                                IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            this.webHostEnvironment = webHostEnvironment;
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

        [HttpGet]
        public ViewResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                // // If the Photos property on the incoming model object is not null and if count > 0,
                // // then the user has selected at least one file to upload
                // if (model.Photo != null && model.Photo.Count > 0)
                // {
                //     // Loop thru each selected file
                //     foreach (IFormFile photo in model.Photo)
                //     {
                //         // The file must be uploaded to the images folder in wwwroot
                //         // To get the path of the wwwroot folder we are using the injected
                //         // webHostingEnvironment service provided by ASP.NET Core
                //         string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                //         // To make sure the file name is unique, appending a new
                //         // GUID value and and an underscore to the file name
                //         uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                //         string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //         // Use CopyTo() method provided by IFormFile interface to
                //         // copy the file to wwwroot/images folder
                //         photo.CopyTo(new FileStream(filePath, FileMode.Create));
                //     }
                if (model.Photo != null)
                {
                    
                    //path to wwwroot folder
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Employee newEmployee =  new Employee() 
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };
                _employeeRepository.Add(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.ID });
            }
            return View();
        }
    }
}