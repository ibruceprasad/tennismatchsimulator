using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ScoreBoardService.Services;

namespace ScoreBoardService
{
    public static class ScoreBoardServicesRegistration
    {
        public static IServiceCollection AddScoreBoardServiceRegistration(this IServiceCollection services)
        {
            services.AddTransient<IScoreBoardProcessor, ScoreBoardProcessor>();
            services.AddTransient<IGameScoreService, GameScoreService>();
            services.AddTransient<ISetScoreService, SetScoreService>();
            services.AddTransient<IMatchScoreService, MatchScoreService>();
            return services;
        }
    }
}
