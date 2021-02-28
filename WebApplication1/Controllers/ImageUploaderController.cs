using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ImageUploader.Models;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("")]
    public class ImageUploaderController : ControllerBase
    {
        
       
            private readonly IWebHostEnvironment env;

            public ImageUploaderController(IWebHostEnvironment environment)
            {
                env = environment ?? throw new ArgumentNullException(nameof(environment));
            }

            // POST: /image
            [HttpPost]
            public async Task Post(IFormFile file)
            {
                var uploads = Path.Combine(env.WebRootPath, "uploads");
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }

            [HttpGet]
            public List<string> Get()
            {
                 var imagelist = new List<string>();
                //Fetch Uploaded Image Data.
                var path = Path.Combine(env.WebRootPath, "uploads");
                DirectoryInfo info = new DirectoryInfo(path);
                FileInfo[] files = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();
                foreach (var file in files)
                {
                    imagelist.Add(file.Name);
                }

                return imagelist;
            }

        [HttpGet("asc")]
        public List<string> GetAsc()
        {
            var imagelist = new List<string>();
            //Fetch Uploaded Image Data.
            var path = Path.Combine(env.WebRootPath, "uploads");
            DirectoryInfo info = new DirectoryInfo(path);
            FileInfo[] files = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();
            foreach (var file in files)
            {
                imagelist.Add(file.Name);
            }

            return imagelist;
        }

        [HttpGet("des")]
        public List<string> GetDsc()
        {
            var imagelist = new List<string>();
            //Fetch Uploaded Image Data.
            var path = Path.Combine(env.WebRootPath, "uploads");
            DirectoryInfo info = new DirectoryInfo(path);
            FileInfo[] files = info.GetFiles().OrderByDescending(p => p.CreationTime).ToArray();
            foreach (var file in files)
            {
                imagelist.Add(file.Name);
            }

            return imagelist;
        }

    }
}
