using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CacheProxyPattern.WebApp.Models;
using static CacheProxyPattern.WebApp.Startup;
using CacheProxyPattern.WebApp.Domain.Contracts;
using CacheProxyPattern.WebApp.Domain.Entities;

namespace CacheProxyPattern.WebApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepositoryProxy;

        public StudentsController(ServiceResolver serviceAccessor)
        {
            _studentRepositoryProxy = serviceAccessor("GetProxyObject");
        }

        public IActionResult Index()
        {
            IEnumerable<Student> students = _studentRepositoryProxy.GetAll();
            return View();
        }
    }
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
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
