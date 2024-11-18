using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ScoreBoardService.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ScoreBoardService
{
    public class ScoreBoardProcessor : IScoreBoard
    {

        private readonly IGameScoreService _gamesScoreService;
        private readonly ISetScoreService _setScoreService;
        private readonly IMatchScoreService _matchScoreService;


        public ScoreBoardProcessor(IGameScoreService gameScoreService,
                                   ISetScoreService setScoreService,
                                   IMatchScoreService matchScoreService)
        {
            _gamesScoreService = gameScoreService;
            _setScoreService = setScoreService;
            _matchScoreService = matchScoreService;
        }

  

        public ScoreBoard GetScoreBoard(MatchDetails matchDetails)
        {
            var scoreBoard = new ScoreBoard();
            bool startNewGame = true;


            // 1 . Validate input points
            var result = ValidateInputPoints(matchDetails);
            if(result is not null)
            {
                var errors = scoreBoard?.Errors ?? new List<Error>();
                errors.Add(result);
                scoreBoard.Errors = errors;
                return scoreBoard;
            }


            // Loop through each points
            for (int i = 0; i < matchDetails.Points.Length; i++)
            {
                if(startNewGame)
                {
                    scoreBoard.GameBoard = new string[2] { "0", "0" };
                    startNewGame = false;
                }
                    
                var currentPlayer = matchDetails.Points[i];
                var opponetPlayer = Convert.ToInt32((!Convert.ToBoolean(currentPlayer)));

                var currentPlayerScore  = scoreBoard.GameBoard[currentPlayer];
                var opponentPlayerScore = scoreBoard.GameBoard[opponetPlayer];

                // 1. Update Game
                PopulateBoardWithGameDetails(scoreBoard, currentPlayer, opponetPlayer);
 

                if(scoreBoard.GameBoard.Any(x=>x.Equals(Constants.Point_Win)))
                {
                    
                    // 2. Update the Set Board
                    _setScoreService.UpdateNewScore(scoreBoard.SetBoard, currentPlayer, opponetPlayer);


                    // Reset(clean) the GameBoard
                    startNewGame = true;


                    // 3. Update the MatchBoard if the current set completed
                    var isSetCompleted = _setScoreService.IsSetCompleted(scoreBoard.SetBoard, currentPlayer, opponetPlayer);
                    if (isSetCompleted)
                    {
                        var currentPlayerMatchScore = scoreBoard.MatchBoard[currentPlayer];
                        var opponetPlayerMatchScore = scoreBoard.MatchBoard[opponetPlayer];

                        var newMatchDetails = _matchScoreService
                            .GetNewScore(currentPlayerMatchScore, opponetPlayerMatchScore);
                        scoreBoard.MatchBoard[currentPlayer] = newMatchDetails.Item1;
                        scoreBoard.MatchBoard[opponetPlayer] = newMatchDetails.Item2;
                        scoreBoard.IsMatchFinished = newMatchDetails.Item3;
                    }
                }

                // 4. Print ScoreBoard after every point
                PrintScoreBoard(scoreBoard, i, currentPlayer, matchDetails.Players);

                // 5. 
                if (scoreBoard.IsMatchFinished)
                    break;
            }

            return scoreBoard;
        }


        private void PopulateBoardWithGameDetails(ScoreBoard board, int currentPlayer, int opponentPlayer)
        {
            var currentPlayerScore = board.GameBoard[currentPlayer];
            var opponentPlayerScore = board.GameBoard[opponentPlayer];
            var newScore = _gamesScoreService.GetNewScore(currentPlayerScore, opponentPlayerScore);
            var scores = new string[] { newScore.Item1, newScore.Item2 };
            if (scores.Any(x => x == string.Empty))
            {
                var error = board?.Errors ?? new List<Error>();
                error.Add(new Error() { Description = "Invalid points" });
                board.Errors = error;
            }
            board.GameBoard[currentPlayer] = scores[0];
            board.GameBoard[opponentPlayer] = scores[1];
        }


        private Error ValidateInputPoints(MatchDetails matchDetails)
        {
            Error? error = default!;

            // Validation - The input points should be either be 0 or 1
            var result = matchDetails.Points.All(x => (x == 0 || x == 1));
            if (result == false)
            {
                error = new Error() { Description = "Invalid points entered" };
                return error;
            }
            return error;
        }


        private void PrintScoreBoard(ScoreBoard scoreBoard, int point, int currentPlayer, string[] players)
        {
            Console.WriteLine($"Point {point}: {players[currentPlayer]} wins");
            Console.WriteLine($"Current Game  Score: {scoreBoard.GameBoard[0]} - {scoreBoard.GameBoard[1]}");
            Console.WriteLine($"Current Set   Score: {scoreBoard.SetBoard.Last()[0]} - {scoreBoard.SetBoard.Last()[1]}");
            Console.WriteLine($"Current Match Score: {scoreBoard.MatchBoard[0]} sets to {scoreBoard.MatchBoard[1]}");
            Console.WriteLine("\n\n");
            Console.Out.Flush();
        }
    }
}
