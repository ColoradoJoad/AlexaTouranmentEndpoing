namespace AlexaNextTournamentEndpoint.Objects
{
    public class Season
    {
        public bool IsCurrent { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public Season NextSeason()
        {
            return new Season
            {
                IsCurrent = false,
                StartYear = StartYear + 1,
                EndYear = EndYear + 1
            };
        }
    }
}
