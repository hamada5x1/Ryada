using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamada.DataAccess.Interfaces
{
    public interface IFileUploadService
    {
        Task<string> UploadFile(IFormFile file, string destinationPath, long maxFileSize, List<string> fileTypes);
    }
}
