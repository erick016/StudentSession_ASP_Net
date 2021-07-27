using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentSession_Oct12.Models;
using StudentSession_Oct12.DAL;
namespace StudentSession_Oct12.Controllers
{
    public class ProfessorController : Controller
    {
      
            private readonly mysqlContext context; //in .Net Core, dependency injection is baked into the whole framework


        public ProfessorController(mysqlContext context)
        {
            this.context = context;

            context.Database.EnsureCreated();

            /*context.Professor.Add(new Professor
            {
                InstructorId = 201,
                Name = "Roman Reigns",
                DeptName = "INSY"
            });*/

            context.SaveChanges();


        }



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




