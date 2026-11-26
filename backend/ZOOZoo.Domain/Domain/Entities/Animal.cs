namespace ZOOZoo.Domain.Entities
{
    public class Animal
    {
        public Animal(
            int id,
            string name,
            int speciesId,
            int zoneId,
            HealthStatus healthStatus,
            bool interactionAllowed,
            FoodType dietType,
            TimeOnly feedingFrom,
            TimeOnly feedingTo
            )
        {
            if(id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), id, "ID не может быть отрицательным");

            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            if(speciesId < 0)
                throw new ArgumentOutOfRangeException(nameof(speciesId), speciesId, "ID вида не может быть отрицательным");

            if (zoneId < 0)
                throw new ArgumentOutOfRangeException(nameof(zoneId), zoneId, "ID зоны не может быть отрицательным");

            if(!Enum.IsDefined(healthStatus))
                throw new ArgumentException("Неизвестный статус здоровья", nameof(healthStatus));

            if (!Enum.IsDefined(dietType))
                throw new ArgumentException("Неизвестный тип питания", nameof(dietType));

            if (feedingFrom == feedingTo)
                throw new ArgumentException(
                    "Время начала и окончания кормления не должны совпадать.",
                    nameof(feedingTo));

            Id = id;
            Name = name;
            SpeciesId = speciesId;
            ZoneId = zoneId;
            HealthStatus = healthStatus;
            InteractionAllowed = interactionAllowed;
            DietType = dietType;
            FeedingFrom = feedingFrom;
            FeedingTo = feedingTo;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int SpeciesId { get; private set; }
        public int ZoneId { get; private set; }
        public HealthStatus HealthStatus { get; private set; }
        public bool InteractionAllowed { get; private set; }
        public FoodType DietType { get; private set; }
        public TimeOnly FeedingFrom { get; private set; }
        public TimeOnly FeedingTo { get; private set; }
        public DateTime? LastFedAt { get; private set; }

        public Species Species { get; private set; } = null!;
        public Zone Zone { get; private set; } = null!;

        public void MoveToZone(int zoneId)
        {
            if (zoneId < 0)
                throw new ArgumentOutOfRangeException(nameof(zoneId), zoneId, "ID зоны не может быть отрицательным");

            if(zoneId == ZoneId)
                throw new ArgumentException("Животное уже находится в этой зоне", nameof(zoneId));

            ZoneId = zoneId;
        }

        public bool CanInteract() => 
            InteractionAllowed && HealthStatus == HealthStatus.Healthy;

        public void Feed(FoodType food, DateTime currentTime)
        {
            if (!Enum.IsDefined(food))
                throw new ArgumentOutOfRangeException(nameof(food), food, "Неизвестный тип еды");

            if(food != DietType)
                throw new ArgumentException("Неподходящий тип еды для данного животного", nameof(food));

            var time = TimeOnly.FromDateTime(currentTime);

            if(!IsFeedingTime(time))
                throw new InvalidOperationException("Сейчас не время кормления");

            if (LastFedAt.HasValue && IsWithinFeedingWindow(LastFedAt.Value) == 
                IsWithinFeedingWindow(currentTime))
                throw new InvalidOperationException("Животное уже было покормлено сегодня");

            LastFedAt = currentTime;
        }

        private bool IsFeedingTime(TimeOnly time) =>
            FeedingFrom <= FeedingTo
                ? time >= FeedingFrom && time <= FeedingTo
                : time >= FeedingFrom || time <= FeedingTo;

        private DateTime IsWithinFeedingWindow(DateTime time) =>
            FeedingFrom > FeedingTo &&
                TimeOnly.FromDateTime(time) <= FeedingTo
                ? time.Date.AddDays(-1)
                : time.Date;
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
