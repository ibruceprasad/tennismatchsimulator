using ScoreBoardService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisMatchSimulator.Test.ServiceTests
{
    public class ScoreBoardProcessorTests
    {
        private readonly IScoreBoardProcessor _scoreBoardProcessor;

        public ScoreBoardProcessorTests()
        {
            _scoreBoardProcessor = ServiceProviderFactory.GetRequiredService<IScoreBoardProcessor>();
        }

        [Fact]
        public void GetScoreBoard_GivenInCompleteMatchDetails_ReturnsMatchIncomplete()
        {
            // Arrange
            var matchDetails = new MatchDetails()
            {
                Players = new string[2] { "Page", "Alex" },
                Points = new[] { 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 1 }
            };

            // Act
            var finalScoreBoard = _scoreBoardProcessor.GetScoreBoard(matchDetails);
            
            // Asset
            Assert.False(finalScoreBoard.IsMatchFinished);

        }

    }
}


