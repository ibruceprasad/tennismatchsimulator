using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ScoreBoardService.Services;
using ScoreBoardServices;

namespace ScoreBoardService
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddServiceRegistration(this IServiceCollection services)
        {
            services.AddTransient<IScoreBoard, ScoreBoardProcessor>();
            services.AddTransient<IGameScoreService, GameScoreService>();
            services.AddTransient<ISetScoreService, SetScoreService>();
            services.AddTransient<IMatchScoreService, MatchScoreService>();
            return services;
        }
    }
}
