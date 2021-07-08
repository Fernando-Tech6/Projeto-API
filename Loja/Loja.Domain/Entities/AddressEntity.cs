namespace Loja.Domain.Entities
{
    public class AddressEntity : BaseEntity
    {
        public string PublicArea { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string Code { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ProviderEntity ProviderAd { get; set; }

        public virtual ClientEntity ClientAd { get; set; }
    }
}