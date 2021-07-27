using System;
using System.ComponentModel.DataAnnotations;
namespace StudentSession_Oct12.Models
{
    public class CourseModel
    {
        [Key]
        public Int32 CRN { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Desc { get; set; }
        public Int32 Instid { get; set; }

        public CourseModel() { }
        public CourseModel(Int32 Student_id, string Name,  string StartDate, string EndDate, string Desc)
        {
            this.CRN = Student_id;
            this.Name = Name;
 
            this.StartDate= StartDate;
            this.EndDate = EndDate;
            this.Desc = Desc;
            this.Instid = Instid;
        }

    }
}