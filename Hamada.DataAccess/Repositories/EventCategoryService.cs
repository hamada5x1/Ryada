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
    public class EventCategoryService : IEventCategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IBaseService _baseService;

        public EventCategoryService(ApplicationDbContext context, IBaseService baseService)
        {
            _context = context;
            _baseService = baseService;
        }

        public PaginationTableVM<EventCategory> GetAllEventsCategory(int page)
        {
            int pageSize = 10;
            var eventCategories = _context.EventCategories.AsNoTracking().AsQueryable();
            int count = eventCategories.Count();
            var itemsToSkip = (page - 1) * pageSize;

            return new PaginationTableVM<EventCategory>()
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = count,
                Items = eventCategories.Skip(itemsToSkip).Take(pageSize)
            };
        }

        [HttpDelete]
        public async Task<OperationResultVM<EventCategory>> DeleteEventsCategory(int id)
        {
            if (id < 1)
                return new OperationResultVM<EventCategory>(false, "Invalid Identifier Was Passed :|", HttpStatusCode.NotAcceptable);

            try
            {
                var data = await _context.EventCategories.FindAsync(id);

                if (data == null)
                    return new OperationResultVM<EventCategory>(false, "Invalid Identifier Was Passed :|", HttpStatusCode.NotAcceptable);

                _context.EventCategories.Remove(data!);
                await _context.SaveChangesAsync();
                return new OperationResultVM<EventCategory>(true, " Deleted Done", HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new OperationResultVM<EventCategory>(false, "This Category Has Relationshib With Other Events !", HttpStatusCode.InternalServerError, new List<string> { ex.Message });
            }
        }

        public async Task<OperationResultVM<EventCategory>> AddUpdateEventsCategory(EventCategory data)
        {
            if (data is null)
                return new OperationResultVM<EventCategory>(false, "Empty Data Was Passed :|", HttpStatusCode.NotAcceptable);

            try
            {
                if (data.Id == 0)
                {
                    await _context.EventCategories.AddAsync(data);
                }
                else if (data.Id > 0)
                {
                    _context.EventCategories.Update(data);
                }
                await _context.SaveChangesAsync();
                string message = (data.Id == 0) ? "Added Successfully :)" : "Updated Successfully :)";
                return new OperationResultVM<EventCategory>(true, message, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new OperationResultVM<EventCategory>(false, "Sorry, Something is not working properly !", HttpStatusCode.InternalServerError, new List<string> { ex.Message });
            }
        }



        [HttpGet]
        public async Task<OperationResultVM<EventCategory>> GetEventsCategory(int id)
        {
            if (id < 1)
                return new OperationResultVM<EventCategory>(false, "Invalid Identifier Was Passed :|", HttpStatusCode.NotAcceptable);

            try
            {
                var data = await _context.EventCategories.FindAsync(id);
                return new OperationResultVM<EventCategory>(true, " Data Return Successfully", HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new OperationResultVM<EventCategory>(false, "Sorry, Something is not working properly !", HttpStatusCode.InternalServerError, new List<string> { ex.Message }, null);
            }
        }
    }
}
