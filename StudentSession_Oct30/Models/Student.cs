using System;
using System.ComponentModel.DataAnnotations;
namespace StudentSession_Oct12.Models
{
    public class StudentModel
    {
        [Key]
        public Int32 Student_id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int32 Year { get; set; }
        public string Major { get; set; }
        public Int32 Instructor_id { get; set; }

        public StudentModel() { }
        public StudentModel(Int32 Student_id, string FirstName, string LastName, Int32 Year, string Major, Int32 Instructor_id)
        {
            this.Student_id = Student_id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Year= Year;
            this.Major = Major;
            this.Instructor_id = Instructor_id;
        }

    }
}