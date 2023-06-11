using Hamada.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamada.Models.Models
{
    public class EventCategory : BaseEntity
    {
        [Required(ErrorMessage = "Please Type Category Name")]
        public required string EventCategoryName { get; set; }
    }
}
