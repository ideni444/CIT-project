using cit_project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace cit_project.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public DbSet<Student> Students {  get; set; }

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
        }
    }
}

