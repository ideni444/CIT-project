using cit_project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace cit_project.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public DbSet<Student> Students {  get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<Schedule> Schedules { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<Teacher> Teachers { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>()
                .HasOne(b => b.Group)
                .WithMany(a => a.Students)
                .HasForeignKey(b => b.GroupId);

            builder.Entity<Subject>()
                .HasMany(s => s.Schedules)
                .WithOne(sc => sc.Subject)
                .HasForeignKey(sc => sc.SubjectId);

            builder.Entity<Teacher>()
                .HasMany(t => t.Schedules)
                .WithOne(sc => sc.Teacher)
                .HasForeignKey(sc => sc.TeacherId);

            builder.Entity<Group>()
                .HasMany(g => g.Schedules)
                .WithOne(sc => sc.Group)
                .HasForeignKey(sc => sc.GroupId);
        }
    }
}

