namespace ZOOZoo.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required EmployeeRole RoleName { get; set; }
        public bool IsAvailable { get; set; }
    }

    public enum EmployeeRole
    {
        Zookeeper,
        Veterinarian,
        Guide,
        Maintenance
    }
}
