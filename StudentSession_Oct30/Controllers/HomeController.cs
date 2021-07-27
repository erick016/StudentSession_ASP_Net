using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StudentSession_Oct12.DAL;
using StudentSession_Oct12.Models;

namespace StudentSession_Oct12.Controllers
{
    public class HomeController : Controller
    {
        private readonly mysqlContext context; //in .Net Core, dependency injection is baked into the whole framework

        IConfiguration _iconfiguration;

        public HomeController(mysqlContext context, IConfiguration iconfiguration)
        {
            this.context = context;
            context.Database.EnsureCreated();

            /*context.Person.Add(new Person
            {
                PersonId = 42,
                PersonName = "Marcus Aurelius Antoninus"

            }); 
            context.Student.Add(new Student
            {
                Student_id = 1,
                FirstName = "Bharat",
                LastName = "Kumar",
                Year = 1,
                Major = "Economics",
                Instructor_id = 204
            });*/

            context.SaveChanges();

            _iconfiguration = iconfiguration;
        }

        public IActionResult Index()
        {
            List<StudentModel> students = new List<StudentModel>();
            string connStr = "server=localhost;user=root;database=aspDBSep22_Bhavi;port=3306;password=mypass";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM Student LIMIT 0, 1000";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    students.Add(new StudentModel
                    {
                        Student_id = Convert.ToInt32(rdr["Student_id"]),
                        FirstName = rdr["FirstName"].ToString(),
                        LastName = rdr["LastName"].ToString(),
                        Year = Convert.ToInt32(rdr["Year"]),
                        Major = rdr["Major"].ToString(),
                        Instructor_id = Convert.ToInt32(rdr["Instructor_id"])
                    });
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");

            /*var student = new Student()
            {
                Student_id = 1,
                FirstName = "Bharat",
                LastName = "Kumar",
                Year = 1,
                Major = "Economics",
                Instructor_id = 204
            };*/

            return View(students);
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
