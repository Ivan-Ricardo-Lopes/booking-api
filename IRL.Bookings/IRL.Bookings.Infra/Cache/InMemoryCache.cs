using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Bookings.Infra.Cache
{    
    public class InMemoryCache : ICache
    {
        private MemoryCache _memoryCache;

        public InMemoryCache(MemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }
        public void Set(string key, object value)
        {
            _memoryCache.Set(key, value);
        }

    }
}
