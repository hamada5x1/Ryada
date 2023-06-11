using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamada.Models.Data
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public IdentityUser? IdentityUser { get; set; }

    }
}
