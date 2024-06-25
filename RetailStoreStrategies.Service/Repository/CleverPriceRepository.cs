using RetailStoreStrategies.Model.PriceTrickModel;
using RetailStoreStrategies.Service.Abstract;

namespace RetailStoreStrategies.Service.Repository
{
    public class CleverPriceRepository : ICleverPriceRepository
    {
        public List<UpdatePriceModel> CreateInventoryMagic(List<PriceDemandTrendModel> PriceDemand)
        {
            List<UpdatePriceModel> updatePriceModels = new List<UpdatePriceModel>();
            UpdatePriceModel priceModel;
            foreach (var item in PriceDemand)
            {
                priceModel = new UpdatePriceModel();
                priceModel.ProductId = item.ProductId;
                switch(item.Trend.ToLower())
                {
                    case "increasing":
                        priceModel.UpdatedPrice = item.Price + (item.Price * 0.3);
                        break;
                    case "decreasing":
                        priceModel.UpdatedPrice = item.Price - (item.Price * 0.2);
                        break;
                    default:
                        priceModel.UpdatedPrice = item.Price;
                        break;
                }
                
                updatePriceModels.Add(priceModel);
            }

            return updatePriceModels;
            //throw new NotImplementedException();
        }
    }
}
