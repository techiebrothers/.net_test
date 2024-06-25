using RetailStoreStrategies.Model.SmartRestockingPlanModel;

namespace RetailStoreStrategies.Service.Abstract
{
    public interface IRestockPlanRepository
    {
        List<RestockPlanModel> GetRestockingPlan(List<SalesDataModel> SalesData);
    }
}
