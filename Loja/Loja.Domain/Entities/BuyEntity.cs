namespace Loja.Domain.Entities
{
    public class BuyEntity : BaseEntity
    {
        
        public decimal Value { get; set; }
        public int Quantity { get; set; } 

        public int ProviderId { get; set; }
        public ProviderEntity ProviderBuy { get; set; }


        public StockEntity StockBuy { get; set; }
        public int StockId { get; set; }


    }
}