using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace RetailStoreStrategies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        protected bool checkFileType(string file)
        {
            string ext = Path.GetExtension(file);
            switch (ext.ToLower())
            {
                case ".json":
                    return true;
                default:
                    return false;
            }
        }

        protected bool checkFileLength(IFormFile file)
        {
            long length = file.Length;
            if (length > 0) return true;
            return false;
        }

        protected string ReadFile(IFormFile file)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(reader.ReadLine());
            }
            return result.ToString();
        }
    }
}
