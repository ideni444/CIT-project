using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
