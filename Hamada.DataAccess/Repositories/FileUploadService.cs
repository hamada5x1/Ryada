using Hamada.DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamada.DataAccess.Repositories
{
    public class FileUploadService : IFileUploadService
    {
        public async Task<string> UploadFile(IFormFile file, string destinationPath, long maxFileSize, List<string> fileTypes)
        {
            if (file.Length <= 0)
            {
                throw new ArgumentException("Invalid file size");
            }

            if (file.Length > maxFileSize)
            {
                throw new ArgumentException("File size exceeds the maximum allowed limit");
            }

            if (fileTypes == null || fileTypes.Count == 0)
            {
                throw new ArgumentException("Invalid file types");
            }

            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!fileTypes.Contains(fileExtension))
            {
                throw new ArgumentException("Invalid file type");
            }

            var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
            var filePath = Path.Combine(destinationPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return uniqueFileName;
        }

    }
}
