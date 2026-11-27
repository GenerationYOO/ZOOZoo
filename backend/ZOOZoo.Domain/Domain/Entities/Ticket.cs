namespace ZOOZoo.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int VisitorId { get; set; }
        public int TicketTypeId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }

        public Visitor Visitor { get; set; } = null!;
        public TicketType TicketType { get; set; } = null!;
    }
}
