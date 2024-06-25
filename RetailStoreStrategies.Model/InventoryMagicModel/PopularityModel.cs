namespace RetailStoreStrategies.Model.InventoryMagicModel
{
    public class PopularityModel
    {
        public int ProductId { get; set; }
        public double PopularityScore { get; set; }
        public int ShelfLife { get; set; }
        public int CurrentStock { get; set; }
    }
}
