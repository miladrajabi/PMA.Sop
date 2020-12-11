using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace PMA.Sop.Framework.Common.File
{
    public static class FileHandler
    {


        public static UploadDto UploadFile(IFormFile file, string pathFolder)
        {
            if (file != null && !string.IsNullOrEmpty(pathFolder))
            {
                var fileName = $"{DateTime.Now.Ticks}{file.FileName}";
                var uploadsRootFolder = Path.Combine(pathFolder, fileName);
                if (!Directory.Exists(uploadsRootFolder))
                    Directory.CreateDirectory(uploadsRootFolder);
                if (file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = string.Empty,
                    };
                }

                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                file.CopyTo(fileStream);

                return new UploadDto()
                {
                    FileNameAddress = path + fileName,
                    Status = true,
                };
            }
            return null;

        }
    }

    public class UploadDto
    {
        public long Id { get; set; }
        public bool Status { get; set; }
        public string FileNameAddress { get; set; }
    }
}