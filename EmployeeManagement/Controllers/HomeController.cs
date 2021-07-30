using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class HomeController : Controller 
    {
        public string Index() 
        {
            return "Hello from mvc";
        }
    }
}