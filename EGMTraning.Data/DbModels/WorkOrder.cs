using System;
using System.Collections.Generic;

namespace EGMTraning.Data.DbModels
{
    public partial class WorkOrder
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? WorkOrderDescription { get; set; }
        public int WorkOrderStatus { get; set; }
        public double WorkOrderPoint { get; set; }
        public string? WorkOrderNumber { get; set; }
        public string? AssignEmployeeId { get; set; }
        public string? PhotoPath { get; set; }

        public virtual AspNetUser? AssignEmployee { get; set; }
    }
}
