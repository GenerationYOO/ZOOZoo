namespace ZOOZoo.Domain.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int SpeciesId { get; set; }
        public int ZoneId { get; set; }
        public HealthStatus HealthStatus { get; set; }
        public bool InteractionAllowed { get; set; }
        public FoodType FoodType { get; set; }
        public TimeOnly FeedingFrom { get; set; }
        public TimeOnly FeedingTo { get; set; }
        public DateTime? LastFedAt { get; set; }

        public Species Species { get; set; } = null!;
        public Zone Zone { get; set; } = null!;
    }

    public enum HealthStatus
    {
        Healthy,
        Sick
    }

    public enum FoodType
    {
        Herbivore,
        Carnivore,
        Omnivore
    }
}
