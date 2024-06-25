using RetailStoreStrategies.Model.InventoryMagicModel;

namespace RetailStoreStrategies.Service.Abstract
{
    public interface IInventoryMagicRepository
    {
        List<InventoryOptimizationModel> CreateOptimationModel(List<PopularityModel> Popularitys);
    }
}
