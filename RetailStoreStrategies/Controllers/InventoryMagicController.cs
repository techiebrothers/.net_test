using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailStoreStrategies.Model.InventoryMagicModel;
using RetailStoreStrategies.Model.SmartRestockingPlanModel;
using RetailStoreStrategies.Service.Abstract;
using System.Text.Json;

namespace RetailStoreStrategies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryMagicController : BaseController
    {
        IInventoryMagicRepository _inventoryMagicRepository;

        public InventoryMagicController(IInventoryMagicRepository inventoryMagicRepository)
        {
            _inventoryMagicRepository = inventoryMagicRepository;
        }


        /// Post api/InventoryMagic/
        /// <summary>
        ///     Calculate Inventory adjustment
        /// </summary>
        /// <response code="200">Inventory Optimaization Json.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Item not found.</response>
        /// <response code="500">Exception or Internal server error.</response>
        [HttpPost("InventoryMagic")]
        public IActionResult InventoryMagic([FromBody] List<PopularityModel> Data)
        {
            //var inPutData = JsonSerializer.Deserialize<List<PopularityModel>>(Data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }); ;
            var outPutData = _inventoryMagicRepository.CreateOptimationModel(Data);

            return Ok(JsonSerializer.Serialize(outPutData));
        }

        /// Post api/InventoryMagic/
        /// <summary>
        ///     Calculate Inventory adjustment
        /// </summary>
        /// <response code="200">Inventory Optimaization Json.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Item not found.</response>
        /// <response code="500">Exception or Internal server error.</response>
        [HttpPost("InventoryMagicUploadFile")]
        public IActionResult InventoryMagicUploadFile(IFormFile file)
        {
            var inPutData = getDataFromFile(file);
            var outPutData = _inventoryMagicRepository.CreateOptimationModel(inPutData);

            return Ok(JsonSerializer.Serialize(outPutData));
        }

        private List<PopularityModel> getDataFromFile(IFormFile file)
        {
            List<PopularityModel> data = new List<PopularityModel>();
            if (checkFileType(file.FileName) && checkFileLength(file))
            {
                string content = ReadFile(file);

                data = JsonSerializer.Deserialize<List<PopularityModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return data;
        }

        private List<PopularityModel> getData()
        {
            return new List<PopularityModel> { new PopularityModel() {
                ProductId = 123,
                CurrentStock = 100,
                PopularityScore = Convert.ToDouble(1.2),
                ShelfLife = 30
            }, new PopularityModel()
            {
                ProductId = 456,
                CurrentStock = 200,
                PopularityScore = Convert.ToDouble(0.70),
                ShelfLife = 20
            }};
        }
    }
}
