using EGMTraning.BusinessEngine.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EGMTraning.API.Controllers
{

    [Authorize]
    public class WorkOrderController : BaseApiController
    {
        private readonly IWorkOrderBusinessEngine _workOrderBusinessEngine;

        public WorkOrderController(IWorkOrderBusinessEngine workOrderBusinessEngine)
        {
            _workOrderBusinessEngine=workOrderBusinessEngine;
        }

        [HttpGet("GetWorkOrderList")]
        public async Task<IActionResult> GetWorkOrderList()
        {
            var data = await _workOrderBusinessEngine.GetWorkOrders();
            return CreateActionResult(data);
          //  return Ok(data);
        }
    }
}
