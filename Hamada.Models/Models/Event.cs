using Hamada.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamada.Models.Models
{
    public class Event : BaseEntity
    {
        [Required(ErrorMessage = "Please Type Event Name"), MinLength(2, ErrorMessage = "Event Minimum Length is 2 char"), MaxLength(30, ErrorMessage = "Event Maximum Length is 30 char")]
        public required string EventName { get; set; }
        public decimal EventPrice { get; set; }
        public string? EventDetails { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        [Required(ErrorMessage = "Please Select Event Category")]
        public int EventCategoryId { get; set; }
        [ForeignKey("EventCategoryId")]
        public EventCategory? EventCategory { get; set; }
    }
}
