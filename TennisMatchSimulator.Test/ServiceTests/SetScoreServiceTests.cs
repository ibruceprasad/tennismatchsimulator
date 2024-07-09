using ScoreBoardService;
using ScoreBoardService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisMatchSimulator.Test.ServiceTests
{
    public class SetScoreServiceTests
    {
        private readonly ISetScoreService _setScoreService;

        public SetScoreServiceTests()
        {
            _setScoreService = ServiceProviderFactory.GetRequiredService<ISetScoreService>();
        }

        [Fact]
        public void IsSetCompleted_ValidateSetCompleted()
        {
            // Arrange
            var currentSetScore1 = new List<int[]> { new int[] { 6, 6 } };
            var currentSetScore2 = new List<int[]> { new int[] { 7, 6 } };
            var currentSetScore3 = new List<int[]> { new int[] { 5, 6 } };
            var currentSetScore4 = new List<int[]> { new int[] { 4, 6 } };

            // Act
            var status1 = _setScoreService.IsSetCompleted(currentSetScore1, 1, 0);
            var status2 = _setScoreService.IsSetCompleted(currentSetScore2, 0, 1);
            var status3 = _setScoreService.IsSetCompleted(currentSetScore3, 1, 0);
            var status4 = _setScoreService.IsSetCompleted(currentSetScore4, 1, 0);


            // Asset 
            Assert.False(status1);
            Assert.True(status2);
            Assert.False(status3);
            Assert.True(status4);
        }


        [Fact]
        public void UpdateNewScore_GivenCurrentSetBoardAndCurrentMatch_ReturnsUpdatedSetBoard()
        {

            // Arrange
            var currentSetScore1 = new List<int[]> { new int[] { 6, 6 } };
            var currentSetScore2 = new List<int[]> { new int[] { 7, 6 } };
            var currentSetScore3 = new List<int[]> { new int[] { 5, 6 } };
            var currentSetScore4 = new List<int[]> { new int[] { 4, 6 } };

            // Act
            _setScoreService.UpdateNewScore(currentSetScore1, 1, 0);
            _setScoreService.UpdateNewScore(currentSetScore2, 0, 1);
            _setScoreService.UpdateNewScore(currentSetScore3, 1, 0);
            _setScoreService.UpdateNewScore(currentSetScore4, 1, 0);

            // Asset 
            Assert.Equal(currentSetScore1.Count, 1);
            Assert.Equal(currentSetScore1.Last()[0], 6);
            Assert.Equal(currentSetScore1.Last()[1], 7);

            // Assert 
            Assert.Equal(currentSetScore2.Count, 2);
            Assert.Equal(currentSetScore2.Last()[0], 1);
            Assert.Equal(currentSetScore2.Last()[1], 0);

            //Assert
            Assert.Equal(currentSetScore3.Count, 1);
            Assert.Equal(currentSetScore3.Last()[0], 5);
            Assert.Equal(currentSetScore3.Last()[1], 7);

            //Assert
            Assert.Equal(currentSetScore4.Count, 2);
            Assert.Equal(currentSetScore4.Last()[0], 0);
            Assert.Equal(currentSetScore4.Last()[1], 1);

        }


    }
}
