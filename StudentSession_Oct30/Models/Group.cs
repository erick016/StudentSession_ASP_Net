using System;
using System.Collections.Generic;

namespace StudentSession_Oct12.Models
{
    public class Group
    {
        //public StudentModel Temp{ get; set; }
        public Int32 Student_id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Int32 Year { get; set; }
        public string Major { get; set; }
        public Int32 Instructor_id { get; set; }
        public Int32 CRN { get; set; }
        public string CName { get; set; }
        public string CStartDate { get; set; }
        public string CEndDate { get; set; }
        public string CDesc { get; set; }
        public Int32 CIId { get; set; }
        public bool error { get; set; }
        public Int32 InstId { get; set; }
        public String InstrName { get; set; }
        public String DeptName { get; set; }
        public List<StudentModel> stuOnDB;
        public List<CourseModel> courseOnDB;
        public List<Professor> instOnDB;
    }
}
