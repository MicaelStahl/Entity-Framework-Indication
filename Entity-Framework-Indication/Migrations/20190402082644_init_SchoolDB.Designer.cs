﻿// <auto-generated />
using System;
using Entity_Framework_Indication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entity_Framework_Indication.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20190402082644_init_SchoolDB")]
    partial class init_SchoolDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity_Framework_Indication.Models.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId");

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueToDate");

                    b.Property<string>("Grades");

                    b.Property<string>("Subject")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("Entity_Framework_Indication.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Grades");

                    b.Property<int?>("StudentId");

                    b.Property<string>("Subject")
                        .IsRequired();

                    b.Property<int?>("TeacherId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Entity_Framework_Indication.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("PhoneNumber");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Entity_Framework_Indication.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Entity_Framework_Indication.Models.Assignment", b =>
                {
                    b.HasOne("Entity_Framework_Indication.Models.Course", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("Entity_Framework_Indication.Models.Course", b =>
                {
                    b.HasOne("Entity_Framework_Indication.Models.Student")
                        .WithMany("Courses")
                        .HasForeignKey("StudentId");

                    b.HasOne("Entity_Framework_Indication.Models.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId");
                });
#pragma warning restore 612, 618
        }
    }
}