using RetailStoreStrategies.Model.PriceTrickModel;

namespace RetailStoreStrategies.Service.Abstract
{
    public interface ICleverPriceRepository
    {
        List<UpdatePriceModel> CreateInventoryMagic(List<PriceDemandTrendModel> PriceDemand);
    }
}
