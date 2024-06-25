
using RetailStoreStrategies.Model.InventoryMagicModel;
using RetailStoreStrategies.Service.Abstract;

namespace RetailStoreStrategies.Service.Repository
{
    public class InventoryMagicRepository : IInventoryMagicRepository
    {
        public List<InventoryOptimizationModel> CreateOptimationModel(List<PopularityModel> Popularitys)
        {
            List<InventoryOptimizationModel> inventoryOptimizationModels = new List<InventoryOptimizationModel>();
            InventoryOptimizationModel model;
            foreach (var popularity in Popularitys)
            {
                model = new InventoryOptimizationModel();
                double shellDateFactor = popularity.PopularityScore > 0.9 ? 0.1 : -0.1;
                model.RecommendedAdjustment = Convert.ToInt32(Math.Floor(popularity.CurrentStock * (shellDateFactor + popularity.PopularityScore)));
                model.ProductId = popularity.ProductId;
                inventoryOptimizationModels.Add(model);
            }

            return inventoryOptimizationModels;
            //throw new NotImplementedException();
        }
    }
}
