using System;
using System.Collections.Generic;

namespace EGMTraning.Data.DbModels
{
    public partial class EmployeeLeaveType
    {
        public EmployeeLeaveType()
        {
            EmployeeLeaveAllocations = new HashSet<EmployeeLeaveAllocation>();
            EmployeeLeaveRequests = new HashSet<EmployeeLeaveRequest>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int DefaultDays { get; set; }
        public DateTime DateCreated { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<EmployeeLeaveAllocation> EmployeeLeaveAllocations { get; set; }
        public virtual ICollection<EmployeeLeaveRequest> EmployeeLeaveRequests { get; set; }
    }
}
