using Hamada.Models.Models;
using Hamada.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hamada.DataAccess.Repositories.CompaniesRepository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Hamada.DataAccess.Interfaces
{
    public interface ICompaniesRepository
    {
        //Task<OperationResultVM<Company>> AddUpdateCompany(Company data);
        //Task<OperationResultVM<Company>> DeleteCompany(int id);
        //Task<OperationResultVM<Company>> GetCompany(int id);
        //Task<IQueryable<CompanyDto>> CompanyDT(HttpRequest request);
        //Task<IEnumerable<Select2ItemVM>> GetCompanySelect2(string searchTerm, int page);

    }
}
