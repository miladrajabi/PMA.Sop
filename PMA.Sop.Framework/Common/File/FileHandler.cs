using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PMA.Sop.Framework.Common.Interfaces;

namespace PMA.Sop.Framework.Common.File
{
    public class FileHandler : IFileHandler
    {
        private readonly IHostingEnvironment _environment;

        public FileHandler(IHostingEnvironment environment)
        {
            _environment = environment;
        }


        public UploadDto UploadFile(IFormFile file, string pathFolder)
        {
            if (file != null && !string.IsNullOrEmpty(pathFolder))
            {
                var fileName = $"{Guid.NewGuid()}{file.FileName}";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, pathFolder);
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

                var filePath = EnsureCorrectFileAddress(Path.Combine(pathFolder, fileName));
                using var fileStream = new FileStream(Path.Combine(uploadsRootFolder, fileName), FileMode.Create);
                file.CopyTo(fileStream);

                return new UploadDto()
                {
                    FileNameAddress = filePath,
                    Status = true,
                };
            }
            return null;

        }
        public async Task<UploadDto> UploadFileAsync(IFormFile file, string pathFolder)
        {
            if (file != null && !string.IsNullOrEmpty(pathFolder))
            {
                var fileName = $"{Guid.NewGuid()}{file.FileName}";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, pathFolder);
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

                var filePath = EnsureCorrectFileAddress(Path.Combine(pathFolder, fileName));
                await using var fileStream = new FileStream(Path.Combine(uploadsRootFolder, fileName), FileMode.Create);
                await file.CopyToAsync(fileStream);

                return new UploadDto()
                {
                    FileNameAddress = filePath,
                    Status = true,
                };
            }
            return null;

        }

        public async Task<List<UploadDto>> UploadFile(List<IFormFile> files, string pathFolder)
        {
            var list = new List<UploadDto>();

            foreach (var file in files)
            {
                var fileDto = await UploadFileAsync(file, pathFolder);
                if (fileDto != null && fileDto.Status)
                {
                    list.Add(fileDto);
                }
            }

            return list;
        }

        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\", StringComparison.Ordinal) + 1);

            return filename;
        }
        private string EnsureCorrectFileAddress(string fileAddress)
        {
            if (fileAddress.Contains("\\"))
                fileAddress = fileAddress.Replace("\\", "/");

            return fileAddress;
        }

        //UploadDto IFileHandler.UploadFile(IFormFile file, string pathFolder)
        //{
        //    return UploadFile(file, pathFolder);
        //}
    }

    public class UploadDto
    {
        public long Id { get; set; }
        public bool Status { get; set; }
        public string FileNameAddress { get; set; }
    }
}