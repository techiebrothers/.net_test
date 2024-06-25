
namespace RetailStoreStrategies.Model.SmartRestockingPlanModel
{
    public class SalesDataModel
    {
        public int ProductId { get; set; }                   
        public int QuantitySold { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
