using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    ID = 1,
                    Name = "Mary",
                    Department = Dept.IT,
                    Email = "mary@gmail.com"
                },
                new Employee
                {
                    ID = 2,
                    Name = "John",
                    Department = Dept.HR,
                    Email = "john@gmail.com"
                }
            );
        }
    }
}