using EGMTraning.BusinessEngine.Contracts;
using EGMTraning.Common.ConstantsModels;
using EGMTraning.Common.Dtos;
using Microsoft.Extensions.Caching.Memory;

namespace EGMTraning.Caching
{
    public class WorkOrderCaching
    {
        private readonly IWorkOrderBusinessEngine _workOrderBusinessEngine;
        private readonly IMemoryCache _memoryCache;

        public WorkOrderCaching(IWorkOrderBusinessEngine workOrderBusinessEngine, IMemoryCache memoryCache)
        {
            _workOrderBusinessEngine=workOrderBusinessEngine;
            _memoryCache=memoryCache;

            if (!_memoryCache.TryGetValue(ResultConstant.cacheAllWorkOrder,out _))
            {
                var data =  _workOrderBusinessEngine.GetWorkOrders().Result.Data;
                _memoryCache.Set(ResultConstant.cacheAllWorkOrder, data);
            }
        }

        public async Task CacheAllWorkOrderAsync()
        {
            var data = await _workOrderBusinessEngine.GetWorkOrders();
            _memoryCache.Set(ResultConstant.cacheAllWorkOrder, data);
        }

        public Task<IEnumerable<WorkOrderDto>> GetAllWorkOrderAsync()
        {
            var workOrder = _memoryCache.Get<IEnumerable<WorkOrderDto>>(ResultConstant.cacheAllWorkOrder);
            return Task.FromResult(workOrder);
        }

    }
}
