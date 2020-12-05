using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PMA.Sop.ApplicationServices.Interfaces;
using PMA.Sop.Framework.Common;

namespace PMA.Sop.ApplicationServices.Services
{
    public class WebFileSystem : IFileSystem
    {
        private readonly HttpClient _httpClient;
        private readonly string _url;
        public const string AUTH_KEY = "AuthKeyOfDoomThatMustBeAMinimumNumberOfBytes";

        public WebFileSystem(string url)
        {
            _url = url;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("auth-key", AUTH_KEY);
        }
        public async Task<bool> SavePicture(string pictureName, string pictureBase64)
        {
            return !string.IsNullOrEmpty(pictureBase64) && await UploadFile(pictureName, Convert.FromBase64String(pictureBase64));
        }


        private async Task<bool> UploadFile(string fileName, byte[] fileData)
        {
            if (fileData.IsValidImage(fileName)) return await UploadToWeb(fileName, fileData);
            return false;

        }

        private async Task<bool> UploadToWeb(string fileName, byte[] fileData)
        {
            var request = new FileItem
            {
                DataBase64 = Convert.ToBase64String(fileData),
                FileName = fileName
            };
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            using var message = await _httpClient.PostAsync(_url, content);
            return message.IsSuccessStatusCode;
        }
    }
    public static class ImageValidators
    {
        private const int ImageMaximumBytes = 512000;

        public static bool IsValidImage(this byte[] postedFile, string fileName)
        {
            return postedFile != null && postedFile.Length > 0 && postedFile.Length <= ImageMaximumBytes && IsExtensionValid(fileName);
        }

        private static bool IsExtensionValid(string fileName)
        {
            var extension = Path.GetExtension(fileName);
            return string.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".gif", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase);
        }
    }
}