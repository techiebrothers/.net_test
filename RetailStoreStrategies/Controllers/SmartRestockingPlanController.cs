using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using RetailStoreStrategies.Model.SmartRestockingPlanModel;
using RetailStoreStrategies.Service.Abstract;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace RetailStoreStrategies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartRestockingPlanController : BaseController
    {
        private readonly IRestockPlanRepository _restockPlanRepository;

        public SmartRestockingPlanController(IRestockPlanRepository restockPlanRepository) 
        {
            _restockPlanRepository = restockPlanRepository;
        }


        /// Post api/RestockingPlan/
        /// <summary>
        ///     Calculate Restocking Product.
        /// </summary>
        /// <response code="200">Restock plan Json.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Item not found.</response>
        /// <response code="500">Exception or Internal server error.</response>
        [HttpPost("RestockingPlan")]
        public IActionResult RestockingPlan([FromBody] List<SalesDataModel> inPutData)
        {
            //var inPutData = getData();
            var outPutData = _restockPlanRepository.GetRestockingPlan(inPutData);

            return Ok(JsonSerializer.Serialize(outPutData));
        }

        /// Post api/RestockingPlan/
        /// <summary>
        ///     Calculate Restocking Product.
        /// </summary>
        /// <response code="200">Restock plan Json.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Item not found.</response>
        /// <response code="500">Exception or Internal server error.</response>
        [HttpPost("RestockingPlanUploadFile")]
        public IActionResult RestockingPlanUploadFile(IFormFile file)
        {
            var inPutData = getDataFromFile(file);
            var outPutData = _restockPlanRepository.GetRestockingPlan(inPutData);

            byte[] bytes = Encoding.ASCII.GetBytes(JsonSerializer.Serialize(outPutData));

            var stream = new MemoryStream();
            stream.Write(bytes);

            return Ok(JsonSerializer.Serialize(outPutData));
        }

        private List<SalesDataModel> getDataFromFile(IFormFile file)
        {
            List<SalesDataModel> data = new List<SalesDataModel>();
            if (checkFileType(file.FileName) && checkFileLength(file))
            {
                string content = ReadFile(file);

                data = JsonSerializer.Deserialize<List<SalesDataModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
            }
            return data;
        }

        private List<SalesDataModel> getData()
        {
            return new List<SalesDataModel>() { new SalesDataModel()
            {
                ProductId = 123,
                QuantitySold = 10,
                TimeStamp = Convert.ToDateTime("2024-06-01")
            }, new SalesDataModel() {
                ProductId = 456,
                QuantitySold = 20,
                TimeStamp = Convert.ToDateTime("2024-06-02")
            }, new SalesDataModel()
            {
                ProductId = 123,
                QuantitySold = 15,
                TimeStamp = Convert.ToDateTime("2024-06-03")
            }
            };
        }
    }
}
