using Microsoft.Extensions.DependencyInjection;
using ScoreBoardService.Services;
using ScoreBoardService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisMatchSimulator.Test
{
    public static class ServiceProviderFactory
    {
        public static IServiceProvider CreateServiceCollection()
        {
            var services = new ServiceCollection();
            services.AddTransient<IScoreBoardProcessor, ScoreBoardProcessor>();
            services.AddTransient<IGameScoreService, GameScoreService>();
            services.AddTransient<ISetScoreService, SetScoreService>();
            services.AddTransient<IMatchScoreService, MatchScoreService>();

            return services.BuildServiceProvider();
        }

        public static T GetRequiredService<T>()
        {
            var provider = CreateServiceCollection();
            return provider.GetRequiredService<T>();
        }

    }
}
 