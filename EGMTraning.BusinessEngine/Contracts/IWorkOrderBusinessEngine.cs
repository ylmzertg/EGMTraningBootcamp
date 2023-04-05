using EGMTraning.Common.Dtos;

namespace EGMTraning.BusinessEngine.Contracts
{
    public interface IWorkOrderBusinessEngine
    {
       public Task<CustomResponseDto<List<WorkOrderDto>>> GetWorkOrders();

        public Task<CustomResponseDto<WorkOrderDto>> GetWorkOrderByName(string workOrderName);
    }
}
