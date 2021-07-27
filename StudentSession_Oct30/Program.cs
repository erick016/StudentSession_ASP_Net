using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StudentSession_Oct12.DAL;
using StudentSession_Oct12.Models;

namespace StudentSession_Oct12
{
    public class Program
    {



        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            //private readonly mysqlContext context;



            InsertData();

        }



        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        private static void InsertData()
        {
            Console.Out.WriteLine("The insert in Program");
            using (var context = new mysqlContext())
            {
                context.Database.EnsureCreated();

                /*context.Person.Add(new Person
                 {
                     PersonId = 42,
                     PersonName = "Marcus Aurelius Antoninus"

                 }); */

                /*context.Student.Add(new Student
                {
                    Student_id = 1,
                    FirstName = "Bharat",
                    LastName = "Kumar",
                    Year = 1,
                    Major = "Economics",
                    Instructor_id = 204

                }) ;*/

                /*Professor professor = new Professor
                {

                    InstructorId = 201,
                    Name = "Roman Reigns",
                    DeptName = "INSY"
                };
                context.Professor.Add(professor);*/
                /*context.SaveChanges();*/
            }
        }
    }
}
/*using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StudentSession_Oct12;

namespace StudentSession_Oct12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}*/
