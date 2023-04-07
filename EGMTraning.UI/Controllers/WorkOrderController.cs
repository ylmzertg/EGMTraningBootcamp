using EGMTraning.BusinessEngine.Contracts;
using EGMTraning.Caching;
using EGMTraning.Common.Dtos;
using EGMTraning.Common.PagingListModels;
using EGMTraning.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

namespace EGMTraning.UI.Controllers
{
    public class WorkOrderController : Controller
    {
        #region Variables
        private readonly IWorkOrderBusinessEngine _workOrderBusinessEngine;
        private readonly IMemoryCache _memoryCache;
        private readonly WorkOrderApiService _workOrderApiService;


        #endregion

        #region Ctor
        public WorkOrderController(IWorkOrderBusinessEngine workOrderBusinessEngine, IMemoryCache memoryCache, WorkOrderApiService workOrderApiService)
        {
            _workOrderBusinessEngine=workOrderBusinessEngine;
            _memoryCache=memoryCache;
            _workOrderApiService = workOrderApiService;
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
            //var data = await _workOrderBusinessEngine.GetWorkOrders();
            //HttpContext.Session.SetObjectInSession("workOrderList", data.Data);

            //var dataSession = HttpContext.Session.GetCustomObjectFromSession<List<WorkOrderDto>>("workOrderList");

            ////TODO:Session Silme
            //HttpContext.Session.Remove("workOrderList");


            //var model = PaginatedList<WorkOrderDto>.CreateAsync(data.Data, pageNumber, 5);
            //return View(model);
            #endregion

            #region CacheListeleme

            //var data = new WorkOrderCaching(_workOrderBusinessEngine, _memoryCache);
            //var result =await data.GetAllWorkOrderAsync() ;

            //var model = PaginatedList<WorkOrderDto>.CreateAsync(result.ToList(), pageNumber, 5);
            //return View(model);

            #endregion

            #region GetDataWithApi

            var model = await _workOrderApiService.GetAllWorkOrderAsync();
            var result = PaginatedList<WorkOrderDto>.CreateAsync(model.ToList(), pageNumber, 5);
            return View(result);
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
