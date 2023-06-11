using Hamada.DataAccess.Interfaces;
using HamadaShaheenProject.DataAcess.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hamada.DataAccess.Repositories
{
    public class BaseService : IBaseService
    {
        public readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly ApplicationDbContext _context;
        public BaseService(IHttpContextAccessor HttpContextAccessor, ApplicationDbContext context)
        {
            _HttpContextAccessor = HttpContextAccessor;
            _context = context;
        }

        public string GetUserName()
        {
            return _HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
