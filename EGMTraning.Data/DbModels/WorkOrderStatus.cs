﻿using System;
using System.Collections.Generic;

namespace EGMTraning.Data.DbModels
{
    public partial class WorkOrderStatus
    {
        public int Id { get; set; }
        public string WorkOrderStatusName { get; set; } = null!;
    }
}
