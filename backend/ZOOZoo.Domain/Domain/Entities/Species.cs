namespace ZOOZoo.Domain.Entities
{
    public class Species
    {
        public Species(int id, string name)
        {
            if(id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), id, "ID не может быть отрицательным");

            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }

        public ICollection<Animal> Animals { get; private set; } = new List<Animal>();
    }
}
