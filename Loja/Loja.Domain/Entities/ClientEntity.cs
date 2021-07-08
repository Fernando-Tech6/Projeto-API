using System.Collections.Generic;

namespace Loja.Domain.Entities
{
    public class ClientEntity : BaseEntity
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<SaleEntity> SaleCl { get; set; }

        public int AdressId { get; set; }

        public virtual AddressEntity AdressCl { get; set; }

    }
}