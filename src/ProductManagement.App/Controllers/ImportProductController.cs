using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Domain.Products.Services;

namespace ProductManagement.App.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportProductController : ControllerBase 
    {
        private readonly IImportProductFromCsvService _importProductFromCsvService;

        public ImportProductController(IImportProductFromCsvService importProductFromCsvService)
        {
            _importProductFromCsvService = importProductFromCsvService;
        }

        [HttpPost]
        [AllowAnonymous]
        [DisableRequestSizeLimit]
        public IActionResult Import()
        {
            if (Request.Form.Files.Count == 0)
                return BadRequest("The CSV that contains the data to import is required.");

            var formFile = Request.Form.Files[0];
            var csv = ParseCsvFileToString(formFile);

            _importProductFromCsvService.Import(csv.ToString());

            return Ok();
        }

        private static StringBuilder ParseCsvFileToString(IFormFile formFile)
        {
            var stringBuilder = new StringBuilder();
            using (var sr = new StreamReader(formFile.OpenReadStream(), Encoding.UTF8))
            {
                string line;

                while (!string.IsNullOrEmpty(line = sr.ReadLine()))
                {
                    stringBuilder.AppendLine(line);
                }
            }

            return stringBuilder;
        }
    }
}