﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WebApplication.Models;
using System.Threading.Tasks;
using WebApplication.Data;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var ClassInputModels =  _context.ClassInputModeles.FirstOrDefault(x => x.Id == 1);
            
            return View(ClassInputModels);
        }

        [HttpPost]
        public IActionResult Index(ClassInputModels ci)
        {
            ClassMidCalcModels cm = new ClassMidCalcModels();
            ClassMidCalcPut mc = new ClassMidCalcPut();
            ClassFinalCalcModels fc = new ClassFinalCalcModels();
            ClassOutputModels co = new ClassOutputModels();
            mc = cm.GasCalc(ci);
            co = fc.FinalResult(ci, mc);
            ViewBag.ClassOutputModels = co;


            var IncomingPart = new List<double>() { Math.Round(co.Q_x, 2), Math.Round(co.Q_fiztopl, 2), Math.Round(co.Q_fizvozd, 2) };//Выводим график
            ViewBag.TheIncomingPart = Newtonsoft.Json.JsonConvert.SerializeObject(IncomingPart);
            var ExpenditurePart = new List<double>() { Math.Round(co.Q1, 2), Math.Round(co.Q2, 2), Math.Round(co.Q3, 2), Math.Round(co.Q5_top, 2), Math.Round(co.Q5_rp, 2) };//Выводим график
            ViewBag.TheExpenditurePart = Newtonsoft.Json.JsonConvert.SerializeObject(ExpenditurePart);

            return View(ci);
        }

        public IActionResult Contact()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
