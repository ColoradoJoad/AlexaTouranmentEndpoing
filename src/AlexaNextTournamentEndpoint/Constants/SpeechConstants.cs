namespace AlexaNextTournamentEndpoint.Constants
{
    public static class SpeechConstants
    {
        public const string WelcomeText = "Welcome to Colorado Junior Olympic Archery.";
        public const string HelpText = "You can ask about the next tournament, or a specific month's tournament.";
        public const string NoNextTournamentOutOfSeaon = "The indoor season has ended.  Check back in August.";
        public const string NoNextTournamentInSeason = "I am not aware of any tournaments that have been scheduled.";
        public const string UnknownRequest = "I am unsure what has been requested. " + HelpText;
        public const string NotSure = "I am not sure which month you are asking about. " + HelpText;
    }
}
