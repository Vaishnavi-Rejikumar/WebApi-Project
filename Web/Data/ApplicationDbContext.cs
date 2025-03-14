﻿using Microsoft.EntityFrameworkCore;
using Web.Models.Entities;

namespace Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee>Employees  { get; set; }
        public DbSet<Department>Departments  { get; set; }

    }
}
