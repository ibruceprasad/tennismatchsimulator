using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreBoardService.Services
{
    public interface IMatchScoreService
    {
        Tuple<int, int, bool> GetNewScore(int currentPlayerMtachScore, int opponetPlayerMatchScore);
    }

    public class MatchScoreService : IMatchScoreService
    {
        public Tuple<int, int, bool> GetNewScore(int currentPlayerMtachScore, int opponetPlayerMatchScore)
        {
            currentPlayerMtachScore++;
            if (currentPlayerMtachScore == 3)
            {
                return Tuple.Create(currentPlayerMtachScore, opponetPlayerMatchScore, true);
            }
            else
            {
                return Tuple.Create(currentPlayerMtachScore, opponetPlayerMatchScore, false);
            }
        }
    }


}
