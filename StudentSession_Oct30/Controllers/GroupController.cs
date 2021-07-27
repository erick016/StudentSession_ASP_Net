using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StudentSession_Oct12.DAL;
using StudentSession_Oct12.Models;
using StudentSession_Oct12;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentSession_Oct12.Controllers
{
    public class GroupController : Controller
    {
        private readonly mysqlContext context; //in .Net Core, dependency injection is baked into the whole framework

        IConfiguration _iconfiguration;

        Models.Group groupToUse = new Models.Group();

        public List<string> groupQueryHistory = new List<string>();

        public GroupController(mysqlContext context, IConfiguration iconfiguration)
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

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<StudentModel> students = new List<StudentModel>();
            string connStr = "server=localhost;user=root;database=StudentSession;port=3306;password=mypass";
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
                        Student_id = Convert.ToInt32(rdr["StuID"]),
                        FirstName = rdr["Name"].ToString(),
                        LastName = "",
                        Year = Convert.ToInt32(rdr["Year"]),
                        Major = rdr["Major"].ToString(),
                        Instructor_id = Convert.ToInt32(rdr["InstructorId"])
                    });
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            finally { groupQueryHistory.Add("SELECT * FROM Student LIMIT 0, 1000"); }

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

            //return View(students);

            //groupToUse.stuOnDB = students.ConvertAll(stu => new StudentModel(stu.Student_id,stu.FirstName,stu.LastName,stu.Year,stu.Major,stu.Instructor_id));
            groupToUse.stuOnDB = students;
            return View(groupToUse);
        }

        public IActionResult Course()
        {
            List<CourseModel> courses = new List<CourseModel>();
            string connStr = "server=localhost;user=root;database=StudentSession;port=3306;password=mypass";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM Course LIMIT 0, 1000";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                        /*public Int32 CRN { get; set; }
                        public string Name { get; set; }
                        public Int32 StartDate { get; set; }
                        public Int32 EndDate { get; set; }
                        public string Desc { get; set; } */

                /*while (rdr.Read())
                {
                    courses.Add(new CourseModel
                    {
                        CRN = Convert.ToInt32(rdr["CRN"]),
                        Name = rdr["Name"].ToString(),
                        StartDate = rdr["StartDate"].ToString(),
                        EndDate = rdr["EndDate"].ToString(),
                        Desc = rdr["Description"].ToString()
                    });
                }
                rdr.Close(); */

                while (rdr.Read())
                {
                    courses.Add(new CourseModel
                    {
                        CRN = Convert.ToInt32(rdr["CRN"]),
                        Name = rdr["Cname"].ToString(),
                        StartDate = rdr["Startdate"].ToString(),
                        EndDate = rdr["Enddate"].ToString(),
                        Desc = rdr["Descption"].ToString(),
                        Instid = Convert.ToInt32(rdr["InstructorId"])
                    });
                }
                rdr.Close(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                groupQueryHistory.Add("SELECT * FROM Course LIMIT 0, 1000");
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

            //return View(students);

            //groupToUse.stuOnDB = students.ConvertAll(stu => new StudentModel(stu.Student_id,stu.FirstName,stu.LastName,stu.Year,stu.Major,stu.Instructor_id));
            groupToUse.courseOnDB = courses;
            return View(groupToUse);
        }

        public IActionResult Instructor()
        {
            List<Professor> instructors = new List<Professor>();
            string connStr = "server=localhost;user=root;database=StudentSession;port=3306;password=mypass";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM Instructor LIMIT 0, 1000";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                /*public Int32 CRN { get; set; }
                public string Name { get; set; }
                public Int32 StartDate { get; set; }
                public Int32 EndDate { get; set; }
                public string Desc { get; set; } */

                while (rdr.Read())
                {
                    instructors.Add(new Professor
                    {
                        InstructorId = Convert.ToInt32(rdr["ProfID"]),
                        Name = rdr["Name"].ToString(),
                        DeptName = rdr["DeptName"].ToString()
                    });
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                groupQueryHistory.Add("SELECT * FROM Instructor LIMIT 0, 1000");
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

            //return View(students);

            //groupToUse.stuOnDB = students.ConvertAll(stu => new StudentModel(stu.Student_id,stu.FirstName,stu.LastName,stu.Year,stu.Major,stu.Instructor_id));
            groupToUse.instOnDB = instructors;
            return View(groupToUse);
        }

        public IActionResult Create(Models.Group group)
        {
            //groupToUse.FirstName = group.Name;

            /*//int newID = groupToUse.stuOnDB.Where(r => r.Student_id != null).Max(r => r.Student_id) + 1;

            int newID = 0;
            foreach (StudentModel stm in groupToUse.stuOnDB)
                {
                    if (stm.Student_id > newID)
                    {
                        newID = stm.Student_id;
                    }
                }

            newID += 1;

            context.Student.Add(new StudentModel
            {
                Student_id = newID,
                FirstName = groupToUse.FirstName,
                LastName = "McGuillicudy",
                Year = 3,
                Major = "Performing Arts",
                Instructor_id = 208
            }); 

             context.SaveChanges();*/

            string connStr = "server=localhost;user=root;database=StudentSession;port=3306;password=mypass";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO Student(Name,Year,Major,InstructorId) VALUES(@fn, @yr, @maj, @inst)";
            comm.Parameters.AddWithValue("@fn", group.Name);
            //comm.Parameters.AddWithValue("@ln", group.LastName);
            comm.Parameters.AddWithValue("@yr", group.Year);
            comm.Parameters.AddWithValue("@maj", group.Major);
            comm.Parameters.AddWithValue("@inst", group.Instructor_id);
            comm.ExecuteNonQuery();
            conn.Close();

            groupQueryHistory.Add("INSERT INTO Student(Name,Year,Major,InstructorId) VALUES(" + group.Name + ", " + group.Year.ToString() + ", " + group.Major + ", " + group.Instructor_id.ToString() + ")" );

            return View("Index", groupToUse);
        }

        public IActionResult CreateCourse(Models.Group group)
        {
            List<Professor> instructors = new List<Professor>();
            string connStr = "server=localhost;user=root;database=StudentSession;port=3306;password=mypass";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM Instructor LIMIT 0, 1000";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    instructors.Add(new Professor
                    {
                        InstructorId = Convert.ToInt32(rdr["ProfID"]),
                        Name = rdr["Name"].ToString(),
                        DeptName = rdr["DeptName"].ToString()
                    });
                }
                rdr.Close();
            }
            catch (Exception ex)
            {

                groupToUse.error = true;
                return View("Course", groupToUse);
            
            }
            finally
            {
                groupQueryHistory.Add("SELECT * FROM Instructor LIMIT 0, 1000");
            }

            conn.Close();
            Console.WriteLine("Done.");

            int fixedTeacher = -1;

            if (instructors.Count > 0)
            {
                fixedTeacher = instructors.Exists(p => p.InstructorId == group.Instructor_id) ? group.Instructor_id : instructors[0].InstructorId;
            }

            else { return View("Index", groupToUse); }

            string fixedStartDate = DateTimeFix(group.CStartDate);
            string fixedEndDate = DateTimeFix(group.CEndDate);


            MySqlConnection conn2 = new MySqlConnection(connStr);
            conn2.Open();
            MySqlCommand comm = conn2.CreateCommand();


            comm.CommandText = "INSERT INTO Course(Cname,Startdate,Enddate,Descption,InstructorId) VALUES(@nm, @sd, @ed, @dtion, @iid)";
            comm.Parameters.AddWithValue("@nm", group.CName);
            comm.Parameters.AddWithValue("@sd", fixedStartDate);
            comm.Parameters.AddWithValue("@ed", fixedEndDate);
            comm.Parameters.AddWithValue("@dtion", group.CDesc);
            comm.Parameters.AddWithValue("@iid", fixedTeacher);
            try
            { comm.ExecuteNonQuery(); }
            catch
            {
                groupToUse.error = true;
                return View("Course", groupToUse);
            }
            finally
            {
                groupQueryHistory.Add("INSERT INTO Course(Cname,Startdate,Enddate,Descption,InstructorId) VALUES(" + ", " + group.CName + ", " + fixedStartDate + ", " + fixedEndDate + ", " + group.CDesc + ", " + fixedTeacher + ")");
            }

            conn2.Close();

            return View("Course", groupToUse);
        }

        public IActionResult CreateInstructor(Models.Group group)
        {
            string connStr = "server=localhost;user=root;database=StudentSession;port=3306;password=mypass";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();


            comm.CommandText = "INSERT INTO Instructor(Name,Deptname) VALUES(@iname, @dn)";
            comm.Parameters.AddWithValue("@iname", group.InstrName);
            comm.Parameters.AddWithValue("@dn", group.DeptName);
            comm.ExecuteNonQuery();
            conn.Close();

            groupQueryHistory.Add("INSERT INTO Instructor(Name,Deptname) VALUES(" + ", " + group.InstrName + ", " + group.DeptName + ")");

            return View("Instructor", groupToUse);
        }

        public IActionResult Update(Models.Group group)
        {

            List<Professor> instructors = new List<Professor>();
            string connStr = "server=localhost;user=root;database=StudentSession;port=3306;password=mypass";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM Instructor LIMIT 0, 1000";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    instructors.Add(new Professor
                    {
                        InstructorId = Convert.ToInt32(rdr["ProfID"]),
                        Name = rdr["Name"].ToString(),
                        DeptName = rdr["DeptName"].ToString()
                    });
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                groupQueryHistory.Add("SELECT * FROM Instructor LIMIT 0, 1000");
            }

            conn.Close();
            Console.WriteLine("Done.");

            int fixedAdvisor = -1;

            if (instructors.Count > 0)
            {
                fixedAdvisor = instructors.Exists(p => p.InstructorId == group.Instructor_id) ? group.Instructor_id : instructors[0].InstructorId;
            }

            else { return View("Index", groupToUse); }

            string connStr2 = "server=localhost;user=root;database=StudentSession;port=3306;password=mypass";
            MySqlConnection conn2 = new MySqlConnection(connStr2);
            conn2.Open();
            MySqlCommand comm = conn2.CreateCommand();
            comm.CommandText = "UPDATE Student SET Name = @fn,Year = @yr ,Major = @maj,InstructorId = @inst WHERE StuID = @stuid";
            comm.Parameters.AddWithValue("@fn", group.Name);
            //comm.Parameters.AddWithValue("@ln", group.LastName);
            comm.Parameters.AddWithValue("@yr", group.Year);
            comm.Parameters.AddWithValue("@maj", group.Major);
            comm.Parameters.AddWithValue("@inst", fixedAdvisor);
            comm.Parameters.AddWithValue("@stuid", group.Student_id);
            comm.ExecuteNonQuery();
            conn2.Close();

            groupQueryHistory.Add("UPDATE Student SET Name =" + group.Name + ", " + "Year =  " +group.Year.ToString() + ", Major = " + group.Major.ToString() + ", " + "InstructorId = " + fixedAdvisor.ToString() + "WHERE StuID = " + group.Student_id.ToString());

            return View("Index", groupToUse);
        }

        public IActionResult UpdateInstructor(Models.Group group)
        {
            string connStr = "server=localhost;user=root;database=StudentSession;port=3306;password=mypass";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "UPDATE Instructor SET Name = @nm, Deptname = @dn WHERE ProfID = @pid";
            comm.Parameters.AddWithValue("@pid", group.InstId);
            comm.Parameters.AddWithValue("@nm", group.InstrName);
            comm.Parameters.AddWithValue("@dn", group.DeptName);
            comm.ExecuteNonQuery();
            conn.Close();

            groupQueryHistory.Add("UPDATE Instructor SET Name = " + group.InstrName + "Deptname = " + group.DeptName + " WHERE ProfID = " + group.InstId.ToString());

            return View("Instructor", groupToUse);
        }

        public IActionResult CourseUpdate(Models.Group group)
        {

            List<Professor> instructors = new List<Professor>();
            string connStr = "server=localhost;user=root;database=StudentSession;port=3306;password=mypass";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM Instructor LIMIT 0, 1000";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    instructors.Add(new Professor
                    {
                        InstructorId = Convert.ToInt32(rdr["ProfID"]),
                        Name = rdr["Name"].ToString(),
                        DeptName = rdr["DeptName"].ToString()
                    });
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                groupQueryHistory.Add("SELECT * FROM Instructor LIMIT 0, 1000");
            }

            conn.Close();
            Console.WriteLine("Done.");

            int fixedTeacher = -1;

            if (instructors.Count > 0)
            {
                fixedTeacher = instructors.Exists(p => p.InstructorId == group.Instructor_id) ? group.Instructor_id : instructors[0].InstructorId;
            }

            else { return View("Index", groupToUse); }

            string fixedStartDate = DateTimeFix(group.CStartDate);
            string fixedEndDate = DateTimeFix(group.CEndDate);

            MySqlConnection conn2 = new MySqlConnection(connStr);
            conn2.Open();
            MySqlCommand comm = conn2.CreateCommand();
            comm.CommandText = "UPDATE Course SET Cname = @cname, Startdate = @cstartdate, Enddate = @cenddate, Descption = @cdesc, InstructorId = @iid WHERE CRN = @mycrn";
            comm.Parameters.AddWithValue("@mycrn", group.CRN);
            comm.Parameters.AddWithValue("@cname", group.CName);
            /*if (fixedStartDate != "FAIL") { comm.Parameters.AddWithValue("@cstartdate", fixedStartDate); }
            else { comm.Parameters.AddWithValue("@cstartdate", "1970-1-1"); }
            if (fixedEndDate != "FAIL") { comm.Parameters.AddWithValue("@cenddate", fixedEndDate); }
            else { comm.Parameters.AddWithValue("@cenddate", "1970-1-1"); }*/
            comm.Parameters.AddWithValue("@cstartdate", fixedStartDate);
            comm.Parameters.AddWithValue("@cenddate", fixedEndDate);
            comm.Parameters.AddWithValue("@cdesc", group.CDesc);
            comm.Parameters.AddWithValue("@iid", fixedTeacher);
            try
            { comm.ExecuteNonQuery(); }
            catch
            {
                groupToUse.error = true;
                return View("Course", groupToUse);
             }
            finally
            {
                groupQueryHistory.Add("UPDATE Course SET Cname = " + group.CName + ", Startdate = " + fixedStartDate.ToString() + ", Enddate = " + fixedEndDate.ToString() + ", Descption =" + group.CDesc + ", InstructorId = " + fixedTeacher.ToString() + "WHERE CRN = " + group.CRN.ToString());
            }

            conn2.Close();
            
            return View("Course", groupToUse);
        }

        public string DateTimeFix(string originalDT) //09/02/2019 00:00:00
        {
            int month = 0;
            int day = 0;
            int year = 0;

            string failString = "FAIL";

            foreach (char c in originalDT)
            {
                if (!char.IsDigit(c) && c != '/' && c != ':' && c != ' ')
                { return failString; }
            }

            string pattern1 = @"(?:\d{4}|\d{2})";
            Regex r = new Regex(pattern1);
            MatchCollection m = r.Matches(originalDT);

            List <Int32> dateNumbers = new List<Int32> { };

            foreach (Match match in m)
            {
                Int32.TryParse(match.ToString(), out int myout);
                dateNumbers.Add(myout);
            }

            Int32 fourDigitNumbers;
            fourDigitNumbers = dateNumbers.Count(n => n > 999);

            if (fourDigitNumbers > 1)
            {
                return failString;
            }

            if (dateNumbers[1] > 999)
            {
                return failString;
            }

            if (dateNumbers[1] > 12 && dateNumbers[2] > 999)
            {
                year = dateNumbers[2];
                day = dateNumbers[1];
                month = dateNumbers[0];

            }

            else if (dateNumbers[2] > 999)
            {
                month = dateNumbers[1];
                day = dateNumbers[0];
                year = dateNumbers[2];
            }

            else if (dateNumbers[1] > 12 && dateNumbers[0] > 999)
            {
                month = dateNumbers[2];
                day = dateNumbers[1];
                year = dateNumbers[0];
            }

            else if (dateNumbers[0] > 999)
            {
                year = dateNumbers[0];
                month = dateNumbers[1];
                day = dateNumbers[2];
            }

            if (month == 2)
            {
                if (year % 4 == 0) //if it's a leap year
                {
                    if (day > 29) { return failString; }
                }
                else if (day > 28) { return failString; }
                else
                {}
            }

            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                if (day > 30) { return failString; }

            }

            else
            {
                if (day > 31) { return failString; }
                
            }

            return year.ToString() + "-" + month.ToString() + "-" + day.ToString();
        }

        public IActionResult Delete(Models.Group group)
        {
            //groupToUse.FirstName = group.Name;

            /*//int newID = groupToUse.stuOnDB.Where(r => r.Student_id != null).Max(r => r.Student_id) + 1;

            int newID = 0;
            foreach (StudentModel stm in groupToUse.stuOnDB)
                {
                    if (stm.Student_id > newID)
                    {
                        newID = stm.Student_id;
                    }
                }

            newID += 1;

            context.Student.Add(new StudentModel
            {
                Student_id = newID,
                FirstName = groupToUse.FirstName,
                LastName = "McGuillicudy",
                Year = 3,
                Major = "Performing Arts",
                Instructor_id = 208
            }); 

             context.SaveChanges();*/

            string connStr = "server=localhost;user=root;database=StudentSession;port=3306;password=mypass";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "DELETE FROM Student WHERE StuID = @stuid";
            comm.Parameters.AddWithValue("@stuid", group.Student_id);
            comm.ExecuteNonQuery();
            conn.Close();

            groupQueryHistory.Add("DELETE FROM Student WHERE StuID = " + group.Student_id.ToString());

            return View("Index", groupToUse);
        }

        public IActionResult DeleteInstructor(Models.Group group)
        {
            string connStr = "server=localhost;user=root;database=StudentSession;port=3306;password=mypass";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "DELETE FROM Instructor WHERE ProfID = @pid";
            comm.Parameters.AddWithValue("@pid", group.InstId);
            try
            { comm.ExecuteNonQuery(); }
            catch
            {
                groupToUse.error = true;
                return View("Instructor", groupToUse);
            }
            finally { groupQueryHistory.Add("DELETE FROM Instructor WHERE ProfID = " + group.InstId.ToString()); }

            conn.Close();

            return View("Instructor", groupToUse);
        }

        public IActionResult CourseDelete(Models.Group group)
        {
            string connStr = "server=localhost;user=root;database=StudentSession;port=3306;password=mypass";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "DELETE FROM Course WHERE CRN = @crn";
            comm.Parameters.AddWithValue("@crn", group.CRN);
            comm.ExecuteNonQuery();
            conn.Close();
            groupQueryHistory.Add("DELETE FROM Course WHERE CRN = " + group.CRN.ToString());

            return View("Course", groupToUse);
        }
        /*public PartialViewResult Login()
        {
             return PartialView("NewEntry");
        }*/



    }

}
