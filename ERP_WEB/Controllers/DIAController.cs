﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_WEB.Controllers
{
    public class DIAController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
