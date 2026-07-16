using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Context
{


    public class MyDbContext : DbContext
    {
        //setting which make in db context one time setup (not update later)
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {


        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        
        
        //can recreate for implementation this method
        protected override void OnConfiguring(DbContextOptionsBuilder DbContextoptionsBuilder)
        {
            base.OnConfiguring(DbContextoptionsBuilder);
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            var constring = config.GetConnectionString("MyConnection");
            DbContextoptionsBuilder.UseSqlServer(constring);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        
        
        }


    }
}
