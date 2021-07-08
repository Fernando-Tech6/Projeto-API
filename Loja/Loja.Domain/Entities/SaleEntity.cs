namespace Loja.Domain.Entities
{
    public class SaleEntity : BaseEntity
    {

        public int Quantity { get; set; }
        public bool Delivered { get; set; }  /*Para confirmar o recebimento*/
        public decimal Value {get; set;}
        
         public int ClienteId { get; set; }
         public virtual ClientEntity ClientSale { get; set; }

         public int StockId { get; set; }
         public StockEntity SaleSt { get; set; }

    }
}