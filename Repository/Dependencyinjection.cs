using Domain.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.Configuration
{
    public static class Dependencyinjection
    {
        public static void InjectDependenciesRepository(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            services.AddScoped<ITagRepository, TagRepository>();
        }
    }
}
