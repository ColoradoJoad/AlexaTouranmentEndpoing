using AlexaNextTournamentEndpoint.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexaNextTournamentEndpoint.Helpers
{
    public static class TournamentHelper
    {
        public static List<Tournament> GetTournaments()
        {
            List<Tournament> tournaments = new List<Tournament>();

            tournaments.Add(new Tournament()
            {
                Host = "Full Rut Joad",
                Location = "Parker, Colorado",
                EventStart = new DateTime(2017, 01, 14),
                EventEnd = new DateTime(2017, 1, 15)
            });

            tournaments.Add(new Tournament()
            {
                Host = "Rocky Mountain Hot Shtos",
                Location = "Fort Collins, Colorado",
                EventStart = new DateTime(2017, 2, 18),
                EventEnd = new DateTime(2017, 2, 19)
            });

            tournaments.Add(new Tournament()
            {
                Host = "Archery School of the Rockies",
                Location = "Colorado Springs, Colorado",
                EventStart = new DateTime(2017, 3, 18),
                EventEnd = new DateTime(2017, 3, 19)
            });

            tournaments.Add(new Tournament()
            {
                Host = "Greeley X Factor",
                Location = "Denver, Colorado",
                EventStart = new DateTime(2017, 4, 22),
                EventEnd = new DateTime(2017, 4, 23)
            });

            return tournaments;
        }
    }
}
