using Microsoft.AspNetCore.Mvc;
using MissionSystem.Application.Services;
using MissionSystem.Helpers;

namespace MissionSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IWebHostEnvironment _web;
        private readonly FileService _fileService;

        public FilesController(IWebHostEnvironment web, FileService fileService)
        {
            _web = web;
            _fileService = fileService;
        }

        [HttpGet("{path}/{file}")]
        public IActionResult GetFile(string path, string file)
        {
            return File(Helper.GetImage(_web.WebRootPath, $"Resources/Images/{path}/", file), "image/png");
        }

        [HttpPost("UploadFiles")]
        public IActionResult CreateFile(IFormFile file, string path)
        {
            return Ok(_fileService.CreateFile(file,path));
        }
        
        [HttpPost("UploadFile")]
        public string Upload(IFormFile file, string path)
        {
            return _fileService.CreateFile(file,path);
        }
    }
}
