using ScoreBoardService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoreBoardService;
using NuGet.Frameworks;

namespace TennisMatchSimulator.Test.ServiceTests
{
    public class GameScoreServiceTests
    {
        private readonly IGameScoreService _gamesScoreService;

        public GameScoreServiceTests()
        {
            _gamesScoreService = ServiceProviderFactory.GetRequiredService<IGameScoreService>();
        }

        [Fact]
        void GetNewScore_GivenTwoPlayersInDeuce_ReturnValid()
        {
            // Arrange
            var currentPlayerScore = Constants.Point_Deuce;
            var opponentPlayerScore = Constants.Point_Deuce;

            // Act
            var newScore = _gamesScoreService.GetNewScore(currentPlayerScore, opponentPlayerScore);


            // Assert
            var currentPlayerNewScore = newScore.Item1;
            var opponentPlayerNewScore = newScore.Item2;

            Assert.Equal(currentPlayerNewScore, Constants.Point_Ad);
            Assert.Equal(opponentPlayerNewScore, Constants.Point_DisAd);

            Assert.NotEqual(currentPlayerScore, currentPlayerNewScore);
            Assert.NotEqual(opponentPlayerScore, opponentPlayerNewScore);

        }



    }
}
