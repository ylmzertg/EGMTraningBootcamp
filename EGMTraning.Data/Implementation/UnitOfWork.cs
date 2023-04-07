using EGMTraning.Data.DataContext;
using EGMTraning.Data.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGMTraning.Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeDbContext _context;

        public UnitOfWork(EmployeeDbContext context)
        {
            _context=context;
            employeeLeaveAllocationRepository = new EmployeeLeaveAllocationRepository(_context);
            employeeLeaveRequestRepository = new EmployeeLeaveRequestRepository(_context);
            employeeLeaveTypeRepository = new EmployeeLeaveTypeRepository(_context);
            workOrderRepository= new WorkOrderRepository(_context);
            language = new LanguageRepository(context);
            stringResourceRepository = new StringResourceRepository(context);
        }

        public IEmployeeLeaveAllocationRepository employeeLeaveAllocationRepository { get;  private set; }

        public IEmployeeLeaveRequestRepository employeeLeaveRequestRepository { get; private set; }

        public IEmployeeLeaveTypeRepository employeeLeaveTypeRepository { get; private set; }

        public IWorkOrderRepository workOrderRepository { get; private set; }
        public ILanguageRepository language { get; }
        public IStringResourceRepository stringResourceRepository { get; }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void BulkInsert<T>(T[] data)
        {
            //BulkOperation.Insert(data);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
