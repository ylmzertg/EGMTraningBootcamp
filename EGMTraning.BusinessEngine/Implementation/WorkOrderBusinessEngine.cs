using EGMTraning.BusinessEngine.Contracts;
using EGMTraning.Common.Dtos;
using EGMTraning.Data.DataContracts;

namespace EGMTraning.BusinessEngine.Implementation
{
    public class WorkOrderBusinessEngine : IWorkOrderBusinessEngine
    {
        private readonly IUnitOfWork _uow;

        public WorkOrderBusinessEngine(IUnitOfWork uow)
        {
            _uow=uow;
        }


        public async Task<CustomResponseDto<List<WorkOrderDto>>> GetWorkOrders()
        {
            var data = _uow.workOrderRepository.GetAll().ToList();

            if (data!=null)
            {
                List<WorkOrderDto> wOrder = new List<WorkOrderDto>();

                foreach (var order in data)
                {
                    wOrder.Add(new WorkOrderDto
                    {
                        WorkOrderDescription = order.WorkOrderDescription,
                        WorkOrderNumber = order.WorkOrderNumber,
                        WorkOrderStatus = order.WorkOrderStatus,
                    });
                }
                return await Task.FromResult(CustomResponseDto<List<WorkOrderDto>>.Success(200, wOrder));
            }
            return await Task.FromResult(CustomResponseDto<List<WorkOrderDto>>.Fail(500, "Data Not Found"));
        }

        public Task<CustomResponseDto<WorkOrderDto>> GetWorkOrderByName(string workOrderName)
        {
            throw new NotImplementedException();
        }
    }
}
