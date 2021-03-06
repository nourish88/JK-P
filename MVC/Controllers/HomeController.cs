﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Utils.Bases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IControllerUtil _controllerUtil;

        public HomeController(ILogger<HomeController> logger, IControllerUtil controllerUtil)
        {
            _logger = logger;
            _controllerUtil = controllerUtil;
        }

        public IActionResult Index()
        {
            _controllerUtil.SetLiActive("Home");
            ViewBag.LiActives = _controllerUtil.LiActives;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
