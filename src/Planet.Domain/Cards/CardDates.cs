namespace Planet.Domain.Cards
{
    public record CardDates
    {
        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }

        private CardDates() { }

        private CardDates(
            DateTime? startDate,
            DateTime? endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public static CardDates Create(
            DateTime? startDate,
            DateTime? endDate)
        {
            return new CardDates(startDate, endDate);
        }
    }
}
