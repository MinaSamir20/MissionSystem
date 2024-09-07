using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MissionSystem.Helpers;

namespace MissionSystem.Application.Services
{
    public class FileService
    {
        private readonly IWebHostEnvironment _web;
        private readonly List<string> _allowedExtentions = new() { ".jpg", ".png", ".jpeg" };

        public FileService(IWebHostEnvironment web)
        {
            _web = web;
        }
        public string CreateFile(IFormFile file, string path = "")
        {
            if (file.Length > 3145728)
                return "Not Allowed Size Maximum 3 MB";
            if (path.StartsWith("Resources/Images/"))
            {
                if (!_allowedExtentions.Contains(Path.GetExtension(file!.FileName).ToLower()))
                    return "Only accepts files with the following extensions: .jpg, .png, .jpeg";
                return Helper.UploadFiles(_web.ContentRootPath, $"Resources/Images/{path}/", file!);
            }
            return Helper.UploadFiles(_web.ContentRootPath, $"Resources/File/", file!);
        }

        public string Upload()
        {
            return "";
        }
    }
}
