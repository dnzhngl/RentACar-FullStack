using CarRental.Core.CrossCuttingConcerns.Caching;
using CarRental.Core.CrossCuttingConcerns.Caching.Microsoft;
using CarRental.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CarRental.Core.DependencyResolvers
{
    /// <summary>
    /// It involves IoC injections that are related with the Core layer.
    /// It loads general dependencies for the project.
    /// </summary>
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            // Cache
            services.AddMemoryCache();  // Microsoft's Cache
            services.AddSingleton<ICacheManager, MemoryCacheManager>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>(); // PerformanceAspect
        }
    }
}
