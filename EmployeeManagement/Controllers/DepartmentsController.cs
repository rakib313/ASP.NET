using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class DepartmentsController
    {
        public string List()
        {
            return "List() of DepartmentsController";
        }

        public string Details()
        {
            return "Details() of DepartmentsController";
        }
    }
}