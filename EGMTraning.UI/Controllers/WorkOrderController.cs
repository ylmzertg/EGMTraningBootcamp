using EGMTraning.BusinessEngine.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EGMTraning.UI.Controllers
{
    public class WorkOrderController : Controller
    {
        #region Variables
        private readonly IWorkOrderBusinessEngine _workOrderBusinessEngine;


        #endregion

        #region Ctor
        public WorkOrderController(IWorkOrderBusinessEngine workOrderBusinessEngine)
        {
            _workOrderBusinessEngine=workOrderBusinessEngine;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            var data = await _workOrderBusinessEngine.GetWorkOrders();
            if (data.StatusCode == (int)HttpStatusCode.OK)
                return View(data.Data);
            else
                return BadRequest(data.StatusCode);
        }
    }
}
