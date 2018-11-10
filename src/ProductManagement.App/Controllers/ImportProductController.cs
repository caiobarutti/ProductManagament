using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Infra.Sheets;

namespace ProductManagement.App.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportProductController : ControllerBase 
    {
        private readonly IHostingEnvironment _environment;
        private readonly ICsvParser _csvParser;

        public ImportProductController(IHostingEnvironment environment, ICsvParser csvParser)
        {
            _environment = environment;
            _csvParser = csvParser;
        }

        [HttpPost]
        [AllowAnonymous]
        [DisableRequestSizeLimit]
        public IActionResult Import() 
        {
            var formFile = Request.Form.Files[0];

            var stringBuilder = new StringBuilder();
            using (var sr = new StreamReader(formFile.OpenReadStream(), Encoding.UTF8))
            {
                var line = string.Empty;

                while (!string.IsNullOrEmpty(line = sr.ReadLine()))
                {
                    stringBuilder.AppendLine(line);
                }
            }

            var productCsv = _csvParser.Parse(stringBuilder.ToString());
            
            return Ok(productCsv);
        }

        private async Task<string> SaveTheFileIntoDisk(string name, Stream file)
        {
            var rootPath = $"{_environment.ContentRootPath}/wwwroot/csv";
            Directory.CreateDirectory(rootPath);

            var newName = $"{Guid.NewGuid().ToString()}.csv";

            using (var fileStream = new FileStream($"{rootPath}/{newName}", FileMode.Create))
                await file.CopyToAsync(fileStream);

            return $"{Request.Scheme}://{Request.Host}/UploadsDeDocumentos/{newName}";
        }
    }
}