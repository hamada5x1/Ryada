using Hamada.Models.Models;
using Hamada.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamada.DataAccess.Interfaces
{
    public interface IEventCategoryService
    {
        PaginationTableVM<EventCategory> GetAllEventsCategory(int page);
        Task<OperationResultVM<EventCategory>> DeleteEventsCategory(int id);
        Task<OperationResultVM<EventCategory>> AddUpdateEventsCategory(EventCategory data);
        Task<OperationResultVM<EventCategory>> GetEventsCategory(int id);
    }
}
