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
                        Id = order.Id,
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

        public async Task<CustomResponseDto<WorkOrderDto>> GetWorkOrderById(int workOrderId)
        {
            var data = await _uow.workOrderRepository.GetByIdAsync(workOrderId);

            if (data!=null)
            {
                WorkOrderDto nihalDto = new WorkOrderDto();

                nihalDto.Id = data.Id;
                nihalDto.WorkOrderDescription = data.WorkOrderDescription;
                nihalDto.WorkOrderNumber = data.WorkOrderNumber;
                nihalDto.WorkOrderStatus = data.WorkOrderStatus;
                return await Task.FromResult(CustomResponseDto<WorkOrderDto>.Success(200, nihalDto));
            }
            return await Task.FromResult(CustomResponseDto<WorkOrderDto>.Fail(500, "Data Not Found"));
        }

        public async Task<CustomResponseDto<WorkOrderDto>> EditWorkOrderById(WorkOrderDto model)
        {
            if (model.Id>0)
            {
                var data = await _uow.workOrderRepository.GetByIdAsync(model.Id);
                if (data!=null)
                {
                    data.WorkOrderNumber=model.WorkOrderNumber;
                    data.WorkOrderStatus =model.WorkOrderStatus;
                    data.WorkOrderDescription =model.WorkOrderDescription;
                    _uow.workOrderRepository.Update(data);
                    _uow.Commit();
                    return await Task.FromResult(CustomResponseDto<WorkOrderDto>.Success(200, model));
                }
                return await Task.FromResult(CustomResponseDto<WorkOrderDto>.Fail(500, "Data Not Found"));
            }
            return await Task.FromResult(CustomResponseDto<WorkOrderDto>.Fail(500, "Id Not Found"));
        }
    }
}
