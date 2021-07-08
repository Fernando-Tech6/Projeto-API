using System.Collections.Generic;

namespace Loja.Domain.Entities
{
    public class ProviderEntity : BaseEntity
    {
        public string Cnpj { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        
        public virtual ICollection<BuyEntity> BuyPro { get; set; }

        public int AdressId { get; set; }

        public virtual AddressEntity AdressPr { get; set; }

    }
}