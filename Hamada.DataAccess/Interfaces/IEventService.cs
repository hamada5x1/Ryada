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
    public interface IEventService
    {
        PaginationTableVM<Event> GetAllEvents(int page, string? eventName, DateTime? startDate, int categoryId);
        Task<OperationResultVM<Event>> DeleteEvent(int id);
        Task<OperationResultVM<Event>> AddUpdateEvent(Event data);
        Task<IEnumerable<EventCategory>> GetAllEventsCatigoriesAsync();
        Task<OperationResultVM<Event>> GetEvent(int id);
    }
}
