using AlexaNextTournamentEndpoint.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexaNextTournamentEndpoint.Helpers
{
    public static class DateHelper
    {
        public static int GetMonth(string _name)
        {
            switch (_name.ToLower())
            {
                case "january":
                    return 1;
                case "february":
                    return 2;
                case "march":
                    return 3;
                case "april":
                    return 4;
                case "may":
                    return 5;
                case "june":
                    return 6;
                case "july":
                    return 7;
                case "august":
                    return 8;
                case "september":
                    return 9;
                case "october":
                    return 10;
                case "november":
                    return 11;
                case "december":
                    return 12;
            }

            return 0;
        }

        public static Season GetSeason(DateTime _requested)
        {
            int requestedMonth = _requested.Month;
            Season season = new Season();

            if (requestedMonth == 10
                || requestedMonth == 11
                || requestedMonth == 12)
            {
                season.IsCurrent = true;
                season.StartYear = _requested.Year;
                season.EndYear = _requested.Year + 1;
            }
            else if (requestedMonth == 1
                     || requestedMonth == 2
                     || requestedMonth == 3
                     || requestedMonth == 4)
            {
                season.IsCurrent = true;
                season.StartYear = _requested.Year - 1;
                season.EndYear = _requested.Year;
            }
            else
            {
                season.IsCurrent = false;
                season.StartYear = _requested.Year;
                season.EndYear = _requested.Year + 1;
            }

            return season;
        }
    }
}
