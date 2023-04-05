using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EGMTraning.Data.DbModels;

namespace EGMTraning.Data.DataContext
{
    public partial class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {
        }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<EmployeeLeaveAllocation> EmployeeLeaveAllocations { get; set; } = null!;
        public virtual DbSet<EmployeeLeaveRequest> EmployeeLeaveRequests { get; set; } = null!;
        public virtual DbSet<EmployeeLeaveType> EmployeeLeaveTypes { get; set; } = null!;
        public virtual DbSet<WorkOrder> WorkOrders { get; set; } = null!;
        public virtual DbSet<WorkOrderStatus> WorkOrderStatuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-D3FTT7O;Database=EmployeeDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Turkish_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Discriminator).HasDefaultValueSql("(N'')");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.IsActive).HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.Property(e => e.IsAdmin).HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<EmployeeLeaveAllocation>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId, "IX_EmployeeLeaveAllocations_EmployeeId");

                entity.HasIndex(e => e.EmployeeLeaveTypeId, "IX_EmployeeLeaveAllocations_EmployeeLeaveTypeId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeLeaveAllocations)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.EmployeeLeaveType)
                    .WithMany(p => p.EmployeeLeaveAllocations)
                    .HasForeignKey(d => d.EmployeeLeaveTypeId);
            });

            modelBuilder.Entity<EmployeeLeaveRequest>(entity =>
            {
                entity.HasIndex(e => e.ApprovedEmployeeId, "IX_EmployeeLeaveRequests_ApprovedEmployeeId");

                entity.HasIndex(e => e.EmployeeLeaveTypeId, "IX_EmployeeLeaveRequests_EmployeeLeaveTypeId");

                entity.HasIndex(e => e.RequestingEmployeeId, "IX_EmployeeLeaveRequests_RequestingEmployeeId");

                entity.HasOne(d => d.ApprovedEmployee)
                    .WithMany(p => p.EmployeeLeaveRequestApprovedEmployees)
                    .HasForeignKey(d => d.ApprovedEmployeeId);

                entity.HasOne(d => d.EmployeeLeaveType)
                    .WithMany(p => p.EmployeeLeaveRequests)
                    .HasForeignKey(d => d.EmployeeLeaveTypeId);

                entity.HasOne(d => d.RequestingEmployee)
                    .WithMany(p => p.EmployeeLeaveRequestRequestingEmployees)
                    .HasForeignKey(d => d.RequestingEmployeeId);
            });

            modelBuilder.Entity<EmployeeLeaveType>(entity =>
            {
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            modelBuilder.Entity<WorkOrder>(entity =>
            {
                entity.HasIndex(e => e.AssignEmployeeId, "IX_WorkOrders_AssignEmployeeId");

                entity.Property(e => e.WorkOrderDescription).HasMaxLength(750);

                entity.Property(e => e.WorkOrderNumber).HasMaxLength(35);

                entity.HasOne(d => d.AssignEmployee)
                    .WithMany(p => p.WorkOrders)
                    .HasForeignKey(d => d.AssignEmployeeId);
            });

            modelBuilder.Entity<WorkOrderStatus>(entity =>
            {
                entity.ToTable("WorkOrderStatus");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
