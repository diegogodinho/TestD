using Domain.Contracts.Service;
using Service;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Configuration
{
    public static class Dependencyinjector
    {
        public static void InjectDependenciesService(this IServiceCollection services)
        {            
            services.AddScoped<ITagService, TagService>();
        }
    }
}
