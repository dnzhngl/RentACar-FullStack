using CarRental.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.Extensions
{
    /// <summary>
    /// Extensions for service collections
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Service collection, is the collection that we add dependencies of the project's services.
        /// </summary>
        /// <param name="serviceCollection">Service collection type of IServiceCollection.</param>
        /// <param name="modules">Array of modules type of ICoreModule</param>
        /// <returns></returns>
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection); // creates services of this service collection
        }
    }
}
