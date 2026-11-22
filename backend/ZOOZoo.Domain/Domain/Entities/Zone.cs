using ZOOZoo.Domain.Enums;

namespace ZOOZoo.Domain.Entities
{
    public class Zone
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public AccessPolicy AccessPolicyCode { get; set; }
        public InteractionPolicy InteractionPolicyCode { get; set; }
        public AccessLevel RequiredAccessLevel { get; set; }
        public int MinVisitorAge { get; set; }
        public TimeOnly OpenFrom { get; set; }
        public TimeOnly OpenTo { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<Animal> Animals { get; set; } = new List<Animal>();
    }

    public enum AccessPolicy
    {
        Open,
        Restricted,
        StaffOnly
    }

    public enum InteractionPolicy
    {
        Allowed,
        Forbidden
    }
    
}