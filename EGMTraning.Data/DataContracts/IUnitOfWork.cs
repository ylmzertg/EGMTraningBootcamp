namespace EGMTraning.Data.DataContracts
{
    public interface IUnitOfWork :IDisposable
    {
        IEmployeeLeaveAllocationRepository employeeLeaveAllocationRepository { get; }

        IEmployeeLeaveRequestRepository employeeLeaveRequestRepository { get; }
        IEmployeeLeaveTypeRepository employeeLeaveTypeRepository { get; }
        IWorkOrderRepository workOrderRepository { get; }
        void Commit();
        Task CommitAsync();
    }
}
