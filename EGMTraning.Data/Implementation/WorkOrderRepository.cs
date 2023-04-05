using EGMTraning.Data.DataContext;
using EGMTraning.Data.DataContracts;
using EGMTraning.Data.DbModels;

namespace EGMTraning.Data.Implementation
{
    public class WorkOrderRepository : Repository<WorkOrder>, IWorkOrderRepository
    {
        private readonly EmployeeDbContext _ctx;
        public WorkOrderRepository(EmployeeDbContext context) : base(context)
        {
            _ctx = context;
        }
    }
}
