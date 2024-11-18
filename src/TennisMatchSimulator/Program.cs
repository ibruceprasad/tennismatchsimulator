using Microsoft.Extensions.DependencyInjection;
using ScoreBoardService;
 
var services = new ServiceCollection();

// Registration of all services
services.AddServiceRegistration();
var provider = services.BuildServiceProvider();
var scoreBoardProcessor  = provider.GetService<IScoreBoard>();


// Note:
// Change the name of the player and scores here before starting the application
var matchDetails = new MatchDetails()
{
    Players = new string[2]{ "Sam", "Tom" },
    Points = new[] { 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 1 }
};

// Pass the match details to get the final score board
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

