using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailStoreStrategies.Model.InventoryMagicModel;
using RetailStoreStrategies.Model.PriceTrickModel;
using RetailStoreStrategies.Service.Abstract;
using RetailStoreStrategies.Service.Repository;
using System.Text.Json;

namespace RetailStoreStrategies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CleverPriceTrickController : BaseController
    {
        ICleverPriceRepository _cleverPriceRepository;

        public CleverPriceTrickController(ICleverPriceRepository cleverPriceRepository)
        {
            _cleverPriceRepository = cleverPriceRepository;
        }

        /// Post api/CleverPriceTrick/
        /// <summary>
        ///     Calculate updated Price
        /// </summary>
        /// <response code="200">Clever Price Json.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Item not found.</response>
        /// <response code="500">Exception or Internal server error.</response>
        [HttpPost("CleverPriceTrick")]
        public IActionResult CleverPriceTrick([FromBody] List<PriceDemandTrendModel> inPutData)
        {
            //var inPutData = getData();
            var outPutData = _cleverPriceRepository.CreateInventoryMagic(inPutData);

            return Ok(JsonSerializer.Serialize(outPutData));
        }

        /// Post api/CleverPriceTrick/
        /// <summary>
        ///     Calculate updated Price
        /// </summary>
        /// <response code="200">Clever Price Json.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Item not found.</response>
        /// <response code="500">Exception or Internal server error.</response>
        [HttpPost("CleverPriceTrickUploadFile")]
        public IActionResult CleverPriceTrickUploadFile(IFormFile file)
        {
            var inPutData = getDataFromFile(file);
            var outPutData = _cleverPriceRepository.CreateInventoryMagic(inPutData);

            return Ok(JsonSerializer.Serialize(outPutData));
        }

        private List<PriceDemandTrendModel> getDataFromFile(IFormFile file)
        {
            List<PriceDemandTrendModel> data = new List<PriceDemandTrendModel>();
            if (checkFileType(file.FileName) && checkFileLength(file))
            {
                string content = ReadFile(file);

                data = JsonSerializer.Deserialize<List<PriceDemandTrendModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return data;
        }

        private List<PriceDemandTrendModel> getData()
        {
            return new List<PriceDemandTrendModel> { new PriceDemandTrendModel()
            {
                ProductId = 123,
                Price = 10,
                Trend = "increasing"
            }, new PriceDemandTrendModel()
            {
                ProductId = 456,
                Price = 10,
                Trend = "decreasing"
            }
            };
        }
    }
}
