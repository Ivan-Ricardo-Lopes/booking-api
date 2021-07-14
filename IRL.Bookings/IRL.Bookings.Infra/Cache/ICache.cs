using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Bookings.Infra.Cache
{
    public interface ICache
    {
        T Get<T>(string key);
        void Set(string key, object value);
    }
}
