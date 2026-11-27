using ZOOZoo.Domain.Enums;

namespace ZOOZoo.Domain.Entities
{
    public class TicketType
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }
        public decimal BasePrice { get; set; }
        public AccessLevel AccessLevel { get; set; }
        public PricingStrategy PricingStrategyCode { get; set; }
    }

    public enum PricingStrategy
    {
        Fixed,
        AgeBased,
        Dynamic
    }
}