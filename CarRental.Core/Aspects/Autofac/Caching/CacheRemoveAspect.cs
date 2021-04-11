using CarRental.Core.CrossCuttingConcerns.Caching;
using CarRental.Core.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using CarRental.Core.Utilities.Interceptors;

namespace CarRental.Core.Aspects.Autofac.Caching
{
    /// <summary>
    /// When data manipulated( etc. add, update, remove operations), cache remover should run.
    /// </summary>
    public class CacheRemoveAspect :  MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>(); //Microsoft.Extensions.DependencyInjection
        }
        /// <summary>
        /// When the given invocation(operation) returns succes, this will runs and removes dtaa from cache.
        /// </summary>
        /// <param name="invocation">Related operation/method.</param>
        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
