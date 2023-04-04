using Microsoft.EntityFrameworkCore;

namespace EGMTraning.UI.Models
{
    public class EmployeeDbContext :DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) :base(options)
        {

        }
       // DbSet<WorkOrder> WorkOrders { get; set; }
    }
}
