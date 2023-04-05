using System;
using System.Collections.Generic;

namespace EGMTraning.Data.DbModels
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            EmployeeLeaveAllocations = new HashSet<EmployeeLeaveAllocation>();
            EmployeeLeaveRequestApprovedEmployees = new HashSet<EmployeeLeaveRequest>();
            EmployeeLeaveRequestRequestingEmployees = new HashSet<EmployeeLeaveRequest>();
            WorkOrders = new HashSet<WorkOrder>();
            Roles = new HashSet<AspNetRole>();
        }

        public string Id { get; set; } = null!;
        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? TaxId { get; set; }
        public string Discriminator { get; set; } = null!;
        public bool? IsActive { get; set; }
        public bool? IsAdmin { get; set; }

        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual ICollection<EmployeeLeaveAllocation> EmployeeLeaveAllocations { get; set; }
        public virtual ICollection<EmployeeLeaveRequest> EmployeeLeaveRequestApprovedEmployees { get; set; }
        public virtual ICollection<EmployeeLeaveRequest> EmployeeLeaveRequestRequestingEmployees { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }

        public virtual ICollection<AspNetRole> Roles { get; set; }
    }
}
