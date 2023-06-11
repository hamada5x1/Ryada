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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Hamada.DataAccess.Repositories
{
    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IBaseService _baseService;

        public CompaniesRepository(ApplicationDbContext context, IBaseService baseService)
        {
            _context = context;
            _baseService = baseService;
        }
        //public async Task<OperationResultVM<Company>> AddUpdateCompany(Company data)
        //{
        //    if (data is null)
        //        return new OperationResultVM<Company>(false, "Empty Data Was Passed :|", HttpStatusCode.NotAcceptable);

        //    try
        //    {
        //        if (data.Id == 0)
        //        {
        //            await _context.Companies.AddAsync(data);
        //        }
        //        else if (data.Id > 0)
        //        {
        //            _context.Companies.Update(data);
        //        }
        //        await _context.SaveChangesAsync();
        //        string message = (data.Id == 0) ? "Added Successfully :)" : "Updated Successfully :)";
        //        return new OperationResultVM<Company>(true, message , HttpStatusCode.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OperationResultVM<Company>(false, "Sorry, Something is not working properly !", HttpStatusCode.InternalServerError, new List<string> { ex.Message });
        //    }
        //}

        //[HttpDelete]
        //public async Task<OperationResultVM<Company>> DeleteCompany(int id)
        //{
        //    if (id < 1)
        //        return new OperationResultVM<Company>(false, "Invalid Identifier Was Passed :|", HttpStatusCode.NotAcceptable);

        //    try
        //    {
        //        var data = await _context.Companies.FindAsync(id);
        //        await _context.SaveChangesAsync();
        //        return new OperationResultVM<Company>(true, " Deleted Done", HttpStatusCode.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OperationResultVM<Company>(false, "Sorry, Something is not working properly !", HttpStatusCode.InternalServerError, new List<string> { ex.Message });
        //    }
        //}

        //[HttpGet]
        //public async Task<OperationResultVM<Company>> GetCompany(int id)
        //{
        //    if (id < 1)
        //        return new OperationResultVM<Company>(false, "Invalid Identifier Was Passed :|", HttpStatusCode.NotAcceptable, new Company { });

        //    try
        //    {
        //        var data = await _context.Companies.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
        //        return new OperationResultVM<Company>(true, " Data Return Successfully", HttpStatusCode.OK, data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OperationResultVM<Company>(false, "Sorry, Something is not working properly !", HttpStatusCode.InternalServerError, new List<string> { ex.Message }, null);
        //    }
        //}

        //[HttpGet]
        //public async Task<IQueryable<CompanyDto>> CompanyDT(HttpRequest request)
        //{
        //    var searchValue = request.Form["search[value]"].FirstOrDefault()?.ToLower();

        //    var qCompanies = _context.Companies.AsQueryable();


        //    IQueryable<CompanyDto> queryableData = qCompanies.Where(x => x.IsActive == true)
        //        .Select(x => new CompanyDto
        //        {
        //            Id = x.Id,
        //            Code = x.Code,
        //            Name1 = x.Name1,
        //            Mobile = x.Mobile,
        //            Tel = x.Tel,
        //            Website = x.Website,
        //        });

        //    if (!string.IsNullOrEmpty(searchValue))
        //    {
        //        queryableData = queryableData.Where(x => x.Code.ToLower().Contains(searchValue) || x.Name1.ToLower().Contains(searchValue) || x.Mobile.ToLower().Contains(searchValue) || x.Tel.ToLower().Contains(searchValue) || x.Website.ToLower().Contains(searchValue));
        //    }

        //    return queryableData;
        //}


        //public async Task<IEnumerable<Select2ItemVM>> GetCompanySelect2(string searchTerm, int page)
        //{

        //    return await _context.Companies
        //    .Where(i => i.IsActive == true && (string.IsNullOrEmpty(searchTerm) ? true : i.Name1.Contains(searchTerm)) && i.Name1 != "Default")
        //    .OrderBy(i => i.Id)
        //    .Skip((page - 1) * 20)
        //    .Take(20)
        //    .Select(i => new Select2ItemVM
        //    {
        //        Id = i.Id,
        //        Text = i.Name1
        //    })
        //    .ToListAsync();
        //}


        //public class CompanyDto
        //{
        //    public required int Id { get; set; }
        //    public required string Code { get; set; }
        //    public required string Name1 { get; set; }
        //    public required string Mobile { get; set; }
        //    public required string Tel { get; set; }
        //    public required string Website { get; set; }
        //}
    }
}
