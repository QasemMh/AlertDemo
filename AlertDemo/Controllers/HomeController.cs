using AlertDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlertDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static List<Employee> employees;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            employees = new List<Employee>();
            employees.Add(new Employee { Id = 1, FirstName = "Ali", LastName = "Ahmad 1", Salary = 680 });
            employees.Add(new Employee { Id = 2, FirstName = "Ali 2", LastName = "Ahmad 2", Salary = 350 });
            employees.Add(new Employee { Id = 3, FirstName = "Ali 3", LastName = "Ahmad 3", Salary = 500 });
            employees.Add(new Employee { Id = 4, FirstName = "Ali 4", LastName = "Ahmad 4", Salary = 650 });
            employees.Add(new Employee { Id = 5, FirstName = "Ali 5", LastName = "Ahmad 5", Salary = 800 });

        }

        public IActionResult Index()
        {
            TempData["welcom"] = "welcom";

            return View(employees);
        }


        //using ajax 

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var delay = 3000;
            Thread.Sleep(delay);


            if (id == null) return BadRequest();

            var employee = employees.FirstOrDefault(x => x.Id == id);

            if (employee == null) return BadRequest();

            employees.Remove(employee);

            return Ok();
        }

        public IActionResult Privacy()
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
