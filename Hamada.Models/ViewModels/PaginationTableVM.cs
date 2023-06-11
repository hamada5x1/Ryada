using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamada.Models.ViewModels
{
    public class PaginationTableVM<T>
    {
        public required int CurrentPage { get; set; }
        public required int PageSize { get; set; }
        public required int TotalItems { get; set; }
        public required  IQueryable<T> Items { get; set; }
    }
}
