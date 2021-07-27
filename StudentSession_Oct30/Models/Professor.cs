using System;
using System.ComponentModel.DataAnnotations;
namespace StudentSession_Oct12.Models
{
    public class Professor
    {
        [Key]
        public Int32 InstructorId { get; set; }
        public string Name { get; set; }
        public string DeptName { get; set; }

    }
}