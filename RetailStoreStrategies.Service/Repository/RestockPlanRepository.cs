using RetailStoreStrategies.Model.SmartRestockingPlanModel;
using RetailStoreStrategies.Service.Abstract;

namespace RetailStoreStrategies.Service.Repository
{
    public class RestockPlanRepository : IRestockPlanRepository
    {
        public List<RestockPlanModel> GetRestockingPlan(List<SalesDataModel> SalesData)
        {
            
            List<RestockPlanModel> restockPlanModels = SalesData.GroupBy(x => x.ProductId).Select(l => new RestockPlanModel { 
                ProductId = l.First().ProductId,
                RecommendedQuantity = Convert.ToInt32((l.Sum(sm => sm.QuantitySold)) + Math.Floor(l.Sum(sm => sm.QuantitySold) * 0.5))
            }).ToList();
            
            return restockPlanModels;
        }
    }
}
