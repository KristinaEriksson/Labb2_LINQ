﻿// <auto-generated />
using Labb2_LINQ.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb2_LINQ.Migrations
{
    [DbContext(typeof(ForzaDbContext))]
    [Migration("20230429125550_fix")]
    partial class fix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Labb2_LINQ.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Labb2_LINQ.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseID"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CourseID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Labb2_LINQ.Models.SchoolConnection", b =>
                {
                    b.Property<int>("ConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConnectionId"));

                    b.Property<int>("FK_ClassID")
                        .HasColumnType("int");

                    b.Property<int>("FK_CourseID")
                        .HasColumnType("int");

                    b.Property<int>("FK_StudentID")
                        .HasColumnType("int");

                    b.Property<int>("FK_TeacherID")
                        .HasColumnType("int");

                    b.HasKey("ConnectionId");

                    b.HasIndex("FK_ClassID");

                    b.HasIndex("FK_CourseID");

                    b.HasIndex("FK_StudentID");

                    b.HasIndex("FK_TeacherID");

                    b.ToTable("SchoolConnections");
                });

            modelBuilder.Entity("Labb2_LINQ.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"));

                    b.Property<string>("StudentFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StudentLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StudentID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Labb2_LINQ.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherID"));

                    b.Property<string>("TeacherFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TeacherLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TeacherID");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Labb2_LINQ.Models.SchoolConnection", b =>
                {
                    b.HasOne("Labb2_LINQ.Models.Class", "Classes")
                        .WithMany("SchoolConnections")
                        .HasForeignKey("FK_ClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb2_LINQ.Models.Course", "Courses")
                        .WithMany("SchoolConnections")
                        .HasForeignKey("FK_CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb2_LINQ.Models.Student", "Students")
                        .WithMany("SchoolConnections")
                        .HasForeignKey("FK_StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb2_LINQ.Models.Teacher", "Teachers")
                        .WithMany("SchoolConnections")
                        .HasForeignKey("FK_TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classes");

                    b.Navigation("Courses");

                    b.Navigation("Students");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("Labb2_LINQ.Models.Class", b =>
                {
                    b.Navigation("SchoolConnections");
                });

            modelBuilder.Entity("Labb2_LINQ.Models.Course", b =>
                {
                    b.Navigation("SchoolConnections");
                });

            modelBuilder.Entity("Labb2_LINQ.Models.Student", b =>
                {
                    b.Navigation("SchoolConnections");
                });

            modelBuilder.Entity("Labb2_LINQ.Models.Teacher", b =>
                {
                    b.Navigation("SchoolConnections");
                });
#pragma warning restore 612, 618
        }
    }
}
