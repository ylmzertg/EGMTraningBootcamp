using EGMTraning.Data.DataContext;
using EGMTraning.Data.DataContracts;
using EGMTraning.Data.DbModels;

namespace EGMTraning.Data.Implementation
{
    public class EmployeeLeaveTypeRepository : Repository<EmployeeLeaveType>, IEmployeeLeaveTypeRepository
    {
        private readonly EmployeeDbContext _ctx;
        public EmployeeLeaveTypeRepository(EmployeeDbContext context) : base(context)
        {
            _ctx = context;
        }
    }
}
