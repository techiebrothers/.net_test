using RetailStoreStrategies.Model.SmartRestockingPlanModel;
using RetailStoreStrategies.Service.Abstract;

namespace RetailStoreStrategies.Service.Repository
{
    public class RestockPlanRepository : IRestockPlanRepository
    {
        public List<RestockPlanModel> GetRestockingPlan(List<SalesDataModel> SalesData)
        {
            var product = SalesData.GroupBy(x => x.ProductId);
            List<RestockPlanModel> restockPlanModels = new List<RestockPlanModel>();
            foreach (var item in product)
            {
                restockPlanModels.Add(new RestockPlanModel()
                {
                    ProductId = item.Key,
                    RecommendedQuantity = (SalesData.Where(x => x.ProductId == item.Key).Sum(m => m.QuantitySold))
                                                / (SalesData.Where(x => x.ProductId == item.Key).Count())
                });
            }
            
            
            return restockPlanModels;
        }
    }
}
