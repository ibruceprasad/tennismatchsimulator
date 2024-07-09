using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreBoardService
{
    public interface ISetScoreService
    {
        void UpdateNewScore(List<int[]> currentSetScore, int currentPlayer, int opponetPlayer);
        bool IsSetCompleted(List<int[]> currentSetScore, int currentPlayer, int opponetPlayer);
    }

    public class SetScoreService : ISetScoreService
    {
        public void UpdateNewScore(List<int[]> currentSetScore, int currentPlayer, int opponetPlayer)
        {
            var currentSet = currentSetScore.Last();

            var isSetCompleted = IsSetCompleted(currentSetScore, currentPlayer, opponetPlayer);
            
            if(isSetCompleted)
            {
                var newSet = new int[2] { 0, 0 };
                newSet[currentPlayer] = 1;
                currentSetScore.Add(newSet);
            }
            else
            {
                currentSet[currentPlayer]++;
            }
        }

        public bool IsSetCompleted(List<int[]> currentSetScore, int currentPlayer, int opponetPlayer)
        {
            var currentSet = currentSetScore.Last();
            if ((currentSet[currentPlayer] == 6 && Math.Abs(currentSet[currentPlayer]  - currentSet[opponetPlayer]) >= 2) 
                                                    || currentSet[currentPlayer] == 7)
            {
                return true;    
            }
            else
            {
                return false;
            }
        }
    }
}

     