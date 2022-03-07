using BusinessAccessLayer;
using CommanLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultiTierAnoop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTierAnoop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private StudentBusiness business = new StudentBusiness();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var emp = business.GetSutdents();
            return View(emp);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Students students)
        {
            var result = business.CreateStudents(students);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("error", "Error in create students !");
                return View(students);
            }
        }

        
        public IActionResult Delete(int Id)
        {
           
            bool result = business.DeleteStudents(Id);
            if(result)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }


        public IActionResult Update(int Id)
        {

            var result = business.GetStudentsById(Id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Update(Students students)
        {

            var result = business.UpdateStudents(students);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
