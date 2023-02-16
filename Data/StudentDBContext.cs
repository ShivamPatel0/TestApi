using System;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Data
{
	public class StudentDBContext: DbContext
	{
		private readonly IConfiguration _configuration;
		public StudentDBContext(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public virtual DbSet<Student> Student { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
		{
			if (!dbContextOptionsBuilder.IsConfigured)
			{
				dbContextOptionsBuilder.UseSqlServer(_configuration.GetConnectionString("StudentDb"));
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>
				(
					entity=>
					{
						entity.ToTable("Student");
						entity.HasKey(e => new { e.Id });
						entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(50);
						entity.Property(e => e.Age).HasColumnName("Age");
						entity.Property(e => e.Marks).HasColumnName("Marks");
					}
					
				);
		}
    }
}

