using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        IList<T> GetByTimePeriod(long fromTime, long dateTimeOffset);
    }
}
