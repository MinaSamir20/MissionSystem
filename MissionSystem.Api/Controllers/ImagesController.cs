using Microsoft.AspNetCore.Mvc;
using MissionSystem.Helpers;

namespace MissionSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment _web;

        public ImagesController(IWebHostEnvironment web)
        {
            _web = web;
        }

        [HttpGet("{path}/{image}")]
        public IActionResult GetIamge(string path, string image)
        {
            return File(Helper.GetImage(_web.WebRootPath, $"Images/{path}/", image), "image/png");
        }
    }
}
