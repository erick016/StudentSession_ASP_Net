using System;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StudentSession_Oct12.Models;
using StudentSession_Oct12;

namespace StudentSession_Oct12.DAL
{
    public class mysqlContext : DbContext //IdentityDbContext<ApplicationUser> //iddbcontext of type appuser
    {

        public virtual DbSet<StudentModel> Student { get; set; }

        public virtual DbSet<Professor> Professor { get; set; }

        public mysqlContext(DbContextOptions<mysqlContext> options) :base(options)
        {
            this.Database.EnsureCreated();//Any time we run this project, we need to create the database. So any time we change the database, we'll need to drop it, and create it with a new structure.
           
        }

        public mysqlContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder) //What is this?
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().Property(u => u.Id).HasMaxLength(36);

            /*builder.Entity<Person>(entity =>
            {

                //entity.Property(e => e.PersonId).HasColumnType("SMALLINT");
                //entity.HasKey(e => e.PersonId);
                entity.Property(e => e.PersonId).IsRequired().HasMaxLength(36);
                entity.Property(e => e.PersonName).IsRequired().HasMaxLength(36);
                

            }); */

            builder.Entity<StudentModel>(entity =>
            {

               
                entity.Property(e => e.Student_id).IsRequired().HasMaxLength(36);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(36);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(36);
                entity.Property(e => e.Year).IsRequired().HasMaxLength(36);
                entity.Property(e => e.Major).IsRequired().HasMaxLength(36);
                entity.Property(e => e.Instructor_id).IsRequired().HasMaxLength(36);

            });

            builder.Entity<Professor>(entity =>
            {


                entity.Property(e1 => e1.InstructorId).IsRequired().HasMaxLength(36);
                entity.Property(e1 => e1.Name).IsRequired().HasMaxLength(36);
                entity.Property(e1 => e1.DeptName).IsRequired().HasMaxLength(36);
              

            });


            //builder.Entity<Person>().Property(e => e.PersonID).HasMaxLength(36);
            //builder.Entity<Person>().Property(e => e.PersonName).HasMaxLength(36);

        }

        //Program myProgram = new Program();
    }
}
