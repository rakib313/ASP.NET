using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtions
    {
        public static void Seed(this ModelBuilder modelBuilder)
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