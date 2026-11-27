using System;
using System.Collections.Generic;
using System.Text;

namespace ZOOZoo.Domain.ValueObjects
{
    public sealed record FeedingWindow
    {
        public TimeOnly Start { get; private set; }
        public TimeOnly End { get; private set; }

        public FeedingWindow(TimeOnly start, TimeOnly end)
        {
            if (start == end)
                throw new ArgumentException(
                    "Начало и конец окна кормления не должны совпадать.");

            Start = start;
            End = end;
        }

        public bool Contains(TimeOnly time) =>
            Start < End
                ? time >= Start && time <= End
                : time >= Start || time <= End;

        public DateTime GetPeriodStart(DateTime time) =>
            Start > End && 
                TimeOnly.FromDateTime(time) <= End
                ? time.Date.AddDays(-1)
                : time.Date;
    }
}
