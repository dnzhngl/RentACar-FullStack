using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.Utilities.IoC
{
    /// <summary>
    /// IoC Container interface for the different types of containers to be implement.
    /// It loads general dependencies.
    /// </summary>
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
