using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZwkProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileController : ControllerBase
    {
        private readonly HostingEnvironment _hostingEnvironment;

        public FileController(HostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }


        [Route("/api/file/upload")]
        [HttpPost]
        public async Task<IActionResult> Upload(IFormCollection collection)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            //获取文件
            if (collection.Files.Count != 1)
                return new JsonResult(new { success = false, message = "只能上传一个文件" });
            var file = collection.Files[0];
            //相对路径
            var relativePath = "/File/" + DateTime.Now.ToString("yyyyMMdd");
            //绝对路径
            var absolutePath = _hostingEnvironment.WebRootPath + relativePath;
            if (!Directory.Exists(absolutePath))
                Directory.CreateDirectory(absolutePath);
            using (var fs = new FileStream(absolutePath + "\\" + file.FileName, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }
            return new JsonResult(new { success = true, data = relativePath + "/" + file.FileName });
        }

    }
}