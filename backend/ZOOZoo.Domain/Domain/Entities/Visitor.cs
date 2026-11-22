namespace ZOOZoo.Domain.Entities
{
    public class Visitor
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
