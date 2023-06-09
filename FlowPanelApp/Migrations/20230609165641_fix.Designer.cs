﻿// <auto-generated />
using System;
using FlowPanelApp.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlowPanelApp.Migrations
{
    [DbContext(typeof(FlowContext))]
    [Migration("20230609165641_fix")]
    partial class fix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("FlowPanelApp.Models.Announcement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("FlowPanelApp.Models.ClassModel", b =>
                {
                    b.Property<long>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SchoolId")
                        .HasColumnType("bigint");

                    b.Property<long>("TeacherId")
                        .HasColumnType("bigint");

                    b.HasKey("ClassId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("FlowPanelApp.Models.Course", b =>
                {
                    b.Property<long>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.HasKey("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("FlowPanelApp.Models.Grade", b =>
                {
                    b.Property<long>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("AddDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<string>("GradeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GradeValue")
                        .HasColumnType("float");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("GradeId");

                    b.HasIndex("CourseId");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("FlowPanelApp.Models.School", b =>
                {
                    b.Property<long>("SchoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Logo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolId");

                    b.ToTable("School");
                });

            modelBuilder.Entity("FlowPanelApp.Models.Student", b =>
                {
                    b.Property<long>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<long>("ClassId")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pesel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("FlowPanelApp.Models.Teacher", b =>
                {
                    b.Property<long>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<long>("ClassId")
                        .HasColumnType("bigint");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pesel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("TeacherId");

                    b.HasIndex("ClassId")
                        .IsUnique();

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("FlowPanelApp.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FlowPanelApp.Models.Announcement", b =>
                {
                    b.HasOne("FlowPanelApp.Models.User", "User")
                        .WithMany("Announcements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlowPanelApp.Models.ClassModel", b =>
                {
                    b.HasOne("FlowPanelApp.Models.School", "School")
                        .WithMany("Classes")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("FlowPanelApp.Models.Course", b =>
                {
                    b.HasOne("FlowPanelApp.Models.Student", "Student")
                        .WithMany("Courses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("FlowPanelApp.Models.Grade", b =>
                {
                    b.HasOne("FlowPanelApp.Models.Course", "Course")
                        .WithMany("Grades")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("FlowPanelApp.Models.Student", b =>
                {
                    b.HasOne("FlowPanelApp.Models.ClassModel", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("FlowPanelApp.Models.Teacher", b =>
                {
                    b.HasOne("FlowPanelApp.Models.ClassModel", "ClassModel")
                        .WithOne("Teacher")
                        .HasForeignKey("FlowPanelApp.Models.Teacher", "ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassModel");
                });

            modelBuilder.Entity("FlowPanelApp.Models.ClassModel", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("FlowPanelApp.Models.Course", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("FlowPanelApp.Models.School", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("FlowPanelApp.Models.Student", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("FlowPanelApp.Models.User", b =>
                {
                    b.Navigation("Announcements");
                });
#pragma warning restore 612, 618
        }
    }
}
