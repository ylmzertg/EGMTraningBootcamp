using EGMTraning.BusinessEngine.Contracts;
using EGMTraning.Common.Dtos;
using EGMTraning.Common.PagingListModels;
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

        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            #region DataTable ile Listeleme
            //var data = await _workOrderBusinessEngine.GetWorkOrders();
            //if (data.StatusCode == (int)HttpStatusCode.OK)
            //    return View(data.Data);
            //else
            //    return BadRequest(data.StatusCode); 
            #endregion

            #region Ozel Listeleme
            var data = await _workOrderBusinessEngine.GetWorkOrders();
            var model = PaginatedList<WorkOrderDto>.CreateAsync(data.Data, pageNumber, 5);
            return View(model);
            #endregion
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _workOrderBusinessEngine.GetWorkOrderById(id);
            if (data.StatusCode == (int)HttpStatusCode.OK)
                return View(data.Data);
            else
                return BadRequest(data.StatusCode);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(WorkOrderDto model)
        {
            var data = await _workOrderBusinessEngine.EditWorkOrderById(model);
            if (data.StatusCode == (int)HttpStatusCode.OK)
                return RedirectToAction("Index");
            else
                return BadRequest(data.StatusCode);
        }
    }
}
