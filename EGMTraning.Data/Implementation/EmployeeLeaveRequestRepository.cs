using EGMTraning.Data.DataContext;
using EGMTraning.Data.DataContracts;
using EGMTraning.Data.DbModels;

namespace EGMTraning.Data.Implementation
{
    public class EmployeeLeaveRequestRepository : Repository<EmployeeLeaveRequest>, IEmployeeLeaveRequestRepository
    {
        private readonly EmployeeDbContext _ctx;
        public EmployeeLeaveRequestRepository(EmployeeDbContext context) : base(context)
        {
            _ctx = context;
        }
    }
}
