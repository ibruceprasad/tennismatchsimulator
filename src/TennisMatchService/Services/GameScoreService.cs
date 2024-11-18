using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
 


namespace ScoreBoardService.Services
{
    public interface IGameScoreService
    {
        Tuple<string, string> GetNewScore(string currentPlayerScore, string opponentPlayerScore);
    }
    public class GameScoreService : IGameScoreService
    {
        public Tuple<string, string> GetNewScore(string currentPlayerScore, string opponentPlayerScore)
        {
            switch (currentPlayerScore)
            {
                case Constants.Point_0:
                    return Tuple.Create(Constants.Point_15, opponentPlayerScore);

                case Constants.Point_15:
                    return Tuple.Create(Constants.Point_30, opponentPlayerScore);

                case Constants.Point_30:
                    return Tuple.Create(Constants.Point_40, opponentPlayerScore);

                case Constants.Point_40 or Constants.Point_Ad or Constants.Point_DisAd or Constants.Point_Deuce:
                    var lst = new List<string>() { Constants.Point_0, Constants.Point_15, Constants.Point_30 };
                    if (opponentPlayerScore == Constants.Point_40 || currentPlayerScore == Constants.Point_Deuce)
                    {
                        return Tuple.Create(Constants.Point_Ad, Constants.Point_DisAd);
                    }
                    else if (lst.Any(x => x == opponentPlayerScore) && currentPlayerScore == Constants.Point_40
                        || currentPlayerScore == Constants.Point_Ad)
                    {
                        return Tuple.Create(Constants.Point_Win, opponentPlayerScore);
                    }
                    else if (currentPlayerScore == Constants.Point_DisAd)
                    {
                        return Tuple.Create(Constants.Point_Deuce, Constants.Point_Deuce);
                    }
                    break;

            }

            return Tuple.Create("", "");
        }

 


    }


}
