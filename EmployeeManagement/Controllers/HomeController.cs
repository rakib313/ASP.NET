using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class HomeController : Controller 
    {
        public JsonResult Index() 
        {
            return Json(new {ID = 1, name = "Rakib"});
        }
    }
}