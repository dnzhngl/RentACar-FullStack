using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.CrossCuttingConcerns.Caching
{
    /// <summary>
    /// It is an interface for different types of caching mechanism to use.
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// Gets data from cache that has the given key and in the specified type.
        /// </summary>
        /// <typeparam name="T">Type of the entity must be specified.</typeparam>
        /// <param name="key"></param>
        /// <returns>Returns data from cache of type generic.</returns>
        T Get<T>(string key);
        /// <summary>
        /// Gets data from cache that has the given key.
        /// </summary>
        /// <param name="key">Key (namee) of the cache.</param>
        /// <returns>Returns the object yhat has the given key.</returns>
        object Get(string key);
        /// <summary>
        /// It add to cache.
        /// </summary>
        /// <param name="key">Name of the cache</param>
        /// <param name="data">Data of the type of object to be cached.</param>
        /// <param name="duration">How many minutes will it be stored on the cache.</param>
        void Add(string key, object data, int duration);
        /// <summary>
        /// Looks for whether there is related data or not on the cache.
        /// </summary>
        /// <param name="key">Name of the cache.</param>
        /// <returns>Return true if found any, else returns false.</returns>
        bool IsAdd(string key);
        /// <summary>
        /// Removes from cache.
        /// </summary>
        /// <param name="key">Name of the cache.</param>
        void Remove(string key);
        /// <summary>
        /// Removes those that have a specific pattern in their key from the cache.
        /// </summary>
        /// <param name="pattern"></param>
        void RemoveByPattern(string pattern);
    }
}
