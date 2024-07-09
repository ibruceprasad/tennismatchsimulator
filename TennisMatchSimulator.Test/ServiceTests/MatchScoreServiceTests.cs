using ScoreBoardService;
using ScoreBoardService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisMatchSimulator.Test.ServiceTests
{
    public class MatchScoreServiceTests
    {
        private readonly IMatchScoreService _matchScoreService;

        public MatchScoreServiceTests()
        {
            _matchScoreService = ServiceProviderFactory.GetRequiredService<IMatchScoreService>();
        }

        [Fact]
        public void GetNewScore_GivenCurrentMatchBoard_ReturnsNeMatchBoard()
        {

            // Arrange
            var currentPlayerMatchScore = 2;
            var opponentPlayerMatchScore = 1;


            // Act
            var status = _matchScoreService.GetNewScore(currentPlayerMatchScore, opponentPlayerMatchScore);

            // Assert
            // 1. Match ends as the current match score is 3-1
            Assert.True(status.Item3);

            // 2. Current player's match score is changed to 3
            Assert.Equal(status.Item1, currentPlayerMatchScore + 1 );

            // 3. Opponent player's match score is not changed
            Assert.Equal(status.Item2, opponentPlayerMatchScore);

        }

    }
}
