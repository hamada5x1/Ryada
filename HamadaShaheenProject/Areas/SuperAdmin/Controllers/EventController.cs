using Hamada.DataAccess.Interfaces;
using Hamada.DataAccess.Repositories;
using Hamada.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hamada.Areas.SuperAdmin.Controllers
{
    [Authorize]
    [Area(nameof(SuperAdmin))]

    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IBaseService _baseService;

        public EventController(IEventService productService, IBaseService baseService)
        {
            _eventService = productService;
            _baseService = baseService;

        }

        public async Task<IActionResult> Index(int page = 1, string? eventName = null, DateTime? startDate = null, int categoryId = 0) {

            var categories = await _eventService.GetAllEventsCatigoriesAsync();
            var selectList = new SelectList(categories, "Id", "EventCategoryName");
            ViewData["EventCategoryId"] = selectList;
            return View(_eventService.GetAllEvents(page, eventName, startDate, categoryId));
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var result = await _eventService.DeleteEvent(id);

            return Json(new { success = result.Success, message = result.Message });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUpdateEvent(Event data)
        {
            ModelState.Remove("Id");
            ModelState.Remove("CreatedBy");
            data.CreatedBy = _baseService.GetUserName();

            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Some Inputs have wrong values", errors = ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage).ToList() });

            var result = await _eventService.AddUpdateEvent(data);

            return Json(new { success = result.Success, message = result.Message });
        }

        public JsonResult GetEvent(int id) => Json(new { success = true, data = _eventService.GetEvent(id).Result.Data });

    }
}
