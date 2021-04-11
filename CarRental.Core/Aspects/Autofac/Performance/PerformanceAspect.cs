using CarRental.Core.Utilities.Interceptors;
using CarRental.Core.Utilities.IoC;
using Castle.DynamicProxy;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Core.Aspects.Autofac.Performance
{
    /// <summary>
    /// Returns information about the performance of the related method.
    ///If there is a performance weakness in the system, especially in intensive query operations, the system should warn us, for that pupose the PerfomanceAspect can be implemented.
    /// </summary>
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;

        /// <summary>
        /// Calculates the time interval for the operation from start to end. If it exceeds the given time interval it writes the message on the console.
        /// </summary>
        /// <param name="interval">Time period must be given in type of seconds.</param>
        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        /// <summary>
        /// Stopwatch starts before the related invocation(operation).
        /// </summary>
        /// <param name="invocation">Related method.</param>
        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        /// <summary>
        /// If the total minutes of the created stop watch exceeded the given interval, it writes a message on the console window.
        /// </summary>
        /// <param name="invocation"></param>
        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset();
        }
    }
}

