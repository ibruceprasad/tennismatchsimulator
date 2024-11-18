using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreBoardService
{
    public interface IScoreBoard    
    {
        public ScoreBoard GetScoreBoard(MatchDetails match);
    }

 
    public class MatchDetails
    {
        public string[] Players { get; set; } = new string[2] { "Player 1", "Player 2" };
        public int[] Points { get; set; } = new int[] { };
    }

    public class ScoreBoard
    {
        public string[] GameBoard { get;   set; } = new string[2] { "0", "0" };
        public List<int[]> SetBoard { get;   set; } = new List<int[]>() { new int[2] { 0, 0 } } ;
        public int[] MatchBoard { get;   set; }   = new int[2] { 0, 0 };
        public bool IsMatchFinished { get;  set; } = false;
        public List<Error>? Errors { get;  set; } = null;
    }

    public class Error
    {
        public string? Description {  get; set; }
    }
}
