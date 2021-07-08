using System.Collections.Generic;

namespace Loja.Domain.Entities
{
    public class StockEntity : BaseEntity
    {   
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public bool ChangeValue { get; set; }

        public ProductEntity ProductSt { get; set; }

         public  ICollection<BuyEntity> BuySt { get; set; }

         public ICollection<SaleEntity> SaleSt { get; set; }
    }
}