using FlowPanelApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Context
{
    public class FlowContext : DbContext
    {

        public FlowContext(DbContextOptions<FlowContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<ClassModel> ClassModels { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClassModel>()
                .HasOne(x => x.Teacher)
                .WithOne()
                .HasForeignKey<ClassModel>(x => x.TeacherId);

            modelBuilder.Entity<ClassModel>()
                .HasMany(x => x.Students)
                .WithOne(x => x.Class)
                .HasForeignKey(x => x.ClassId);

            modelBuilder.Entity<ClassModel>()
              .HasOne(x => x.School)
              .WithMany(x => x.Classes)
              .HasForeignKey(x => x.SchoolId);

            modelBuilder.Entity<Teacher>()
                .HasOne(x => x.ClassModel)
                .WithOne(x => x.Teacher)
                .HasForeignKey<Teacher>(x => x.ClassId);

            modelBuilder.Entity<School>()
                .HasMany(x => x.Classes)
                .WithOne(x => x.School)
                .HasForeignKey(x =>x.SchoolId);
                

        }
    }
}
