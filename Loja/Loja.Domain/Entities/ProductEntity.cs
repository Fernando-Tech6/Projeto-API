namespace Loja.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unity { get; set; }

        /*Responsavel por mostrar que item está disponivel no estoque*/
        public bool InStock { get; set; }
         
        public int StockId { get; set; }
        public StockEntity StockP { get; set; }


    }
}
