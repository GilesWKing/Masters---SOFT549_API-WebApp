using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SOFT549_CW_API.Models
{
    public partial class GilesContext : DbContext
    {
        public GilesContext()
        {
        }

        public GilesContext(DbContextOptions<GilesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Assignment> Assignment { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Initial Catalog=Giles;User ID=Giles;Password=10147671;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.ActivityId)
                    .HasColumnName("activity_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActivityName)
                    .IsRequired()
                    .HasColumnName("activity_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActivitySequence).HasColumnName("activity_sequence");

                entity.Property(e => e.ActualCompletionDate)
                    .HasColumnName("actual_completion_date")
                    .HasColumnType("date");

                entity.Property(e => e.ActualCost).HasColumnName("actual_cost");

                entity.Property(e => e.ActualStartDate)
                    .HasColumnName("actual_start_date")
                    .HasColumnType("date");

                entity.Property(e => e.PredictedCompletionDate)
                    .HasColumnName("predicted_completion_date")
                    .HasColumnType("date");

                entity.Property(e => e.PredictedCost).HasColumnName("predicted_cost");

                entity.Property(e => e.PredictedStartDate)
                    .HasColumnName("predicted_start_date")
                    .HasColumnType("date");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_ToProject");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_ToStaff");
            });

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(e => e.TaskId);

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

                entity.Property(e => e.ActualCompletionDate)
                    .HasColumnName("actual_completion_date")
                    .HasColumnType("date");

                entity.Property(e => e.ActualCost).HasColumnName("actual_cost");

                entity.Property(e => e.ActualStartDate)
                    .HasColumnName("actual_start_date")
                    .HasColumnType("date");

                entity.Property(e => e.PredictedCompletionDate)
                    .HasColumnName("predicted_completion_date")
                    .HasColumnType("date");

                entity.Property(e => e.PredictedCost).HasColumnName("predicted_cost");

                entity.Property(e => e.PredictedStartDate)
                    .HasColumnName("predicted_start_date")
                    .HasColumnType("date");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.TaskName)
                    .IsRequired()
                    .HasColumnName("task_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaskSequence).HasColumnName("task_sequence");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Assignment)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assignment_ToActivity");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Assignment)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assignment_ToStaff");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientContact)
                    .IsRequired()
                    .HasColumnName("client_contact")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasColumnName("client_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectId)
                    .HasColumnName("project_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActualCompletionDate)
                    .HasColumnName("actual_completion_date")
                    .HasColumnType("date");

                entity.Property(e => e.ActualCost)
                    .HasColumnName("actual_cost")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActualLaunchDate)
                    .HasColumnName("actual_launch_date")
                    .HasColumnType("date");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.PredictedCompletionDate)
                    .HasColumnName("predicted_completion_date")
                    .HasColumnType("date");

                entity.Property(e => e.PredictedCost)
                    .IsRequired()
                    .HasColumnName("predicted_cost")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PredictedLaunchDate)
                    .HasColumnName("predicted_launch_date")
                    .HasColumnType("date");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasColumnName("project_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_ToClient");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CostPerHour).HasColumnName("cost_per_hour");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("role_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.StaffId)
                    .HasColumnName("staff_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ContactDetails)
                    .HasColumnName("contact_details")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Organisation)
                    .IsRequired()
                    .HasColumnName("organisation")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.StaffName)
                    .IsRequired()
                    .HasColumnName("staff_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_ToRole");
            });
        }
    }
}
