using Microsoft.Extensions.DependencyInjection;
using ScoreBoardService;
using System.Numerics;


var services = new ServiceCollection();

services.AddScoreBoardServiceRegistration();

var provider = services.BuildServiceProvider();

var scoreBoardProcessor  = provider.GetService<IScoreBoardProcessor>();



// Change the name of the players and scores
var matchDetails = new MatchDetails()
{
    Players = new string[2]{ "Sam", "Tom" },
    Points = new[] { 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 1 }
};

 

var finalScoreBoard = scoreBoardProcessor.GetScoreBoard(matchDetails);

if(finalScoreBoard.Errors!= null)
{
    Console.WriteLine("Failed to run the simulator due to the exception ");
    foreach (var error in finalScoreBoard.Errors)
    {
        Console.Write(error.Description);
    }
}


Console.WriteLine("Match ends !!!");

