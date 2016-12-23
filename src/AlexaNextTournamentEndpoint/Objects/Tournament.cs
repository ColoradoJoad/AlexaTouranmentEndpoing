using System;

namespace AlexaNextTournamentEndpoint.Objects
{
    public class Tournament
    {
        public string Host { get; set; }
        public string Location { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
    }
}
