using Hamada.DataAccess.Interfaces;
using Hamada.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hamada.Areas.SuperAdmin.Controllers
{
    [Authorize]
    [Area(nameof(SuperAdmin))]
    public class EventCategoryController : Controller
    {
        private readonly IEventCategoryService _eventCategoryService;
        private readonly IBaseService _baseService;

        public EventCategoryController(IEventCategoryService eventCategoryService, IBaseService baseService)
        {
            _eventCategoryService = eventCategoryService;
            _baseService = baseService;
        }

        public IActionResult Index(int page = 1) => View(_eventCategoryService.GetAllEventsCategory(page));

        [HttpDelete]
        public async Task<IActionResult> DeleteEventsCategory(int id)
        {
            var result = await _eventCategoryService.DeleteEventsCategory(id);
            return Json(new { success = result.Success, message = result.Message });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUpdateEventsCategory(EventCategory data)
        {
            ModelState.Remove("Id");
            ModelState.Remove("CreatedBy");
            data.CreatedBy = _baseService.GetUserName();

            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Some Inputs have wrong values", errors = ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage).ToList() });

            var result = await _eventCategoryService.AddUpdateEventsCategory(data);

            return Json(new { success = result.Success, message = result.Message });
        }

        public JsonResult GetEventsCategory(int id) => Json(new { success = true, data = _eventCategoryService.GetEventsCategory(id).Result.Data });

    }
}
