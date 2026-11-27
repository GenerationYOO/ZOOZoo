using ZOOZoo.Domain.Enums;
using ZOOZoo.Domain.ValueObjects;

namespace ZOOZoo.Domain.Entities
{
    public class Animal
    {
        private Animal()
        {
            Name = null!;
            FeedingWindow = null!;
        }

        public Animal(
            int id,
            string name,
            int speciesId,
            int zoneId,
            HealthStatus healthStatus,
            bool interactionAllowed,
            FoodType dietType,
            FeedingWindow feedingWindow
            )
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), id, "ID не может быть отрицательным");

            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            if (speciesId <= 0)
                throw new ArgumentOutOfRangeException(nameof(speciesId), speciesId, "ID вида не может быть отрицательным");

            if (zoneId <= 0)
                throw new ArgumentOutOfRangeException(nameof(zoneId), zoneId, "ID зоны не может быть отрицательным");

            if (!Enum.IsDefined(healthStatus))
                throw new ArgumentOutOfRangeException("Неизвестный статус здоровья", nameof(healthStatus));

            if (!Enum.IsDefined(dietType))
                throw new ArgumentOutOfRangeException("Неизвестный тип питания", nameof(dietType));

            ArgumentNullException.ThrowIfNull(feedingWindow);

            Id = id;
            Name = name;
            SpeciesId = speciesId;
            ZoneId = zoneId;
            HealthStatus = healthStatus;
            InteractionAllowed = interactionAllowed;
            DietType = dietType;
            FeedingWindow = feedingWindow;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int SpeciesId { get; private set; }
        public int ZoneId { get; private set; }
        public HealthStatus HealthStatus { get; private set; }
        public bool InteractionAllowed { get; private set; }
        public FoodType DietType { get; private set; }
        public FeedingWindow FeedingWindow { get; private set; } = null!;
        public DateTime? LastFedAt { get; private set; }

        public Species Species { get; private set; } = null!;
        public Zone Zone { get; private set; } = null!;

        public void MoveToZone(Zone zone)
        {
            ArgumentNullException.ThrowIfNull(zone);

            if (zone.Id <= 0)
                throw new ArgumentOutOfRangeException(nameof(zone));

            if (zone.Id == ZoneId)
                throw new InvalidOperationException("Животное уже находится в этой зоне.");

            ZoneId = zone.Id;
            Zone = zone;
        }

        public bool CanInteract =>
            InteractionAllowed && HealthStatus == HealthStatus.Healthy;

        public void Feed(FoodType food, DateTime currentTime)
        {
            if (!Enum.IsDefined(food))
                throw new ArgumentOutOfRangeException(nameof(food), food, "Неизвестный тип еды");

            if (food != DietType)
                throw new InvalidOperationException("Неподходящий тип еды для данного животного");

            var time = TimeOnly.FromDateTime(currentTime);

            if (!FeedingWindow.Contains(time))
                throw new InvalidOperationException("Сейчас не время кормления");

            if (LastFedAt is { } lastFedAt &&
                FeedingWindow.GetPeriodStart(lastFedAt) ==
                FeedingWindow.GetPeriodStart(currentTime))
                throw new InvalidOperationException("Животное уже было покормлено сегодня");

            LastFedAt = currentTime;
        }
    }
}