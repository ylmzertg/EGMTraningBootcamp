using System;
using System.Collections.Generic;

namespace EGMTraning.Data.DbModels
{
    public partial class EmployeeLeaveRequest
    {
        public int Id { get; set; }
        public string? RequestingEmployeeId { get; set; }
        public string? ApprovedEmployeeId { get; set; }
        public int EmployeeLeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }
        public string? RequestComments { get; set; }
        public int? Approved { get; set; }
        public bool Cancelled { get; set; }

        public virtual AspNetUser? ApprovedEmployee { get; set; }
        public virtual EmployeeLeaveType EmployeeLeaveType { get; set; } = null!;
        public virtual AspNetUser? RequestingEmployee { get; set; }
    }
}
