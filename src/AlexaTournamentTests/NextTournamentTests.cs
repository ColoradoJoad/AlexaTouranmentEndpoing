using AlexaNextTournamentEndpoint.Handlers;
using AlexaTournamentTests.Helpers;
using AlexaTournamentTests.MockObjects;
using System;
using Xunit;

namespace AlexaTournamentTests
{
    public class NextTournamentTests
    {
        [Fact]
        public void TestJanuary()
        {
            DateTime now = new DateTime(2017, 1, 1);

            NextTournamentHandler handler = new NextTournamentHandler(now);

            var request = RequestHelper.GetRequest("NextTournamentIntent");
            var logger = new MockLogger();

            var response = handler.HandleRequest(request, logger);

        }
    }
}
