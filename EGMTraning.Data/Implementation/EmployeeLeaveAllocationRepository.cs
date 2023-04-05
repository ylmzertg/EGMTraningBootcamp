using EGMTraning.Data.DataContext;
using EGMTraning.Data.DataContracts;
using EGMTraning.Data.DbModels;

namespace EGMTraning.Data.Implementation
{
    public class EmployeeLeaveAllocationRepository : Repository<EmployeeLeaveAllocation>, IEmployeeLeaveAllocationRepository
    {
        private readonly EmployeeDbContext _ctx;
        public EmployeeLeaveAllocationRepository(EmployeeDbContext context) : base(context)
        {
            _ctx = context;
        }
    }
}
