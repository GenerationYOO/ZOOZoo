namespace ZOOZoo.Domain.Entities
{
    public class Species
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<Animal> Animals { get; set; } = new List<Animal>();
    }
}
