using System;
using System.Collections.Generic;

namespace EGMTraning.UI.DbModels
{
    public partial class EmployeeLeaveAllocation
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public int Period { get; set; }
        public string? EmployeeId { get; set; }
        public int EmployeeLeaveTypeId { get; set; }

        public virtual AspNetUser? Employee { get; set; }
        public virtual EmployeeLeaveType EmployeeLeaveType { get; set; } = null!;
    }
}
