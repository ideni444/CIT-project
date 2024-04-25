using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School_Schedule_MVC.Models;

namespace School_Schedule_MVC.Models
{
    //Connects the model layer to the database using entity framework.
    public class School_Schedule_MVCDataContext : DbContext
    {
        public School_Schedule_MVCDataContext (DbContextOptions<School_Schedule_MVCDataContext> options)
            : base(options)
        {
        }

        public DbSet<School_Schedule_MVC.Models.Subject> Subject { get; set; }

        public DbSet<School_Schedule_MVC.Models.Teacher> Teacher { get; set; }

        public DbSet<School_Schedule_MVC.Models.TimeTable> TimeTable { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Встановлення відносин один-до-багатьох між Subject і TimeTable 
            builder.Entity<Subject>()
                .HasMany(s => s.TimeTables)
                .WithOne(tt => tt.Subject)
                .HasForeignKey(tt => tt.SubjectId);

            // Встановлення відносин один-до-багатьох між Teacher і TimeTable 
            builder.Entity<Teacher>()
                .HasMany(t => t.TimeTables)
                .WithOne(tt => tt.Teacher)
                .HasForeignKey(tt => tt.TeacherId);
        }
    }
}
