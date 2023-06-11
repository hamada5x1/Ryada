using Hamada.DataAccess.Interfaces;
using Hamada.Models.Models;
using Hamada.Models.ViewModels;
using HamadaShaheenProject.DataAcess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hamada.DataAccess.Repositories
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;
        private readonly IBaseService _baseService;

        public EventService(ApplicationDbContext context, IBaseService baseService)
        {
            _context = context;
            _baseService = baseService;
        }

        public PaginationTableVM<Event> GetAllEvents(int page, string? eventName, DateTime? startDate, int categoryId)
        {
            int pageSize = 10;
            var products = _context.Events.Include(x => x.EventCategory).AsNoTracking().AsQueryable();
            
            if(eventName is not null)
                products = products.Where(x => x.EventName == eventName);

            if (startDate is not null)
                products = products.Where(x => x.StartDate == startDate);

            if (categoryId != 0)
                products = products.Where(x => x.EventCategoryId == categoryId);


            int count = products.Count();
            var itemsToSkip = (page - 1) * pageSize;

            return new PaginationTableVM<Event>()
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = count,
                Items = products.Skip(itemsToSkip).Take(pageSize)
            };
        }

        [HttpDelete]
        public async Task<OperationResultVM<Event>> DeleteEvent(int id)
        {
            if (id < 1)
                return new OperationResultVM<Event>(false, "Invalid Identifier Was Passed :|", HttpStatusCode.NotAcceptable);

            try
            {
                var data = await _context.Events.FindAsync(id);

                if (data == null)
                    return new OperationResultVM<Event>(false, "Invalid Identifier Was Passed :|", HttpStatusCode.NotAcceptable);

                _context.Events.Remove(data!);
                await _context.SaveChangesAsync();
                return new OperationResultVM<Event>(true, " Deleted Done", HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new OperationResultVM<Event>(false, "Sorry, Something is not working properly !", HttpStatusCode.InternalServerError, new List<string> { ex.Message });
            }
        }

        public async Task<OperationResultVM<Event>> AddUpdateEvent(Event data)
        {
            if (data is null)
                return new OperationResultVM<Event>(false, "Empty Data Was Passed :|", HttpStatusCode.NotAcceptable);

            try
            {
                if (data.Id == 0)
                {
                    await _context.Events.AddAsync(data);
                }
                else if (data.Id > 0)
                {
                    _context.Events.Update(data);
                }
                await _context.SaveChangesAsync();
                string message = (data.Id == 0) ? "Added Successfully :)" : "Updated Successfully :)";
                return new OperationResultVM<Event>(true, message, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new OperationResultVM<Event>(false, "Sorry, Something is not working properly !", HttpStatusCode.InternalServerError, new List<string> { ex.Message });
            }
        }

        public async Task<IEnumerable<EventCategory>> GetAllEventsCatigoriesAsync()
        {

            var categories = _context.EventCategories.Select(x => new EventCategory
            {
                Id = x.Id,
                EventCategoryName = x.EventCategoryName
            });

            return await Task.FromResult(categories);
        }

        [HttpGet]
        public async Task<OperationResultVM<Event>> GetEvent(int id)
        {
            if (id < 1)
                return new OperationResultVM<Event>(false, "Invalid Identifier Was Passed :|", HttpStatusCode.NotAcceptable);

            try
            {
                var data = await _context.Events.FindAsync(id);
                return new OperationResultVM<Event>(true, " Data Return Successfully", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new OperationResultVM<Event>(false, "Sorry, Something is not working properly !", HttpStatusCode.InternalServerError, new List<string> { ex.Message }, null);
            }
        }
    }
}
