using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using CrossCutting.Infra.Exceptions;

namespace DistroGuide.Domain.Services.Impl.Cache
{
    public class TimeStampWrapper
    {
        public DateTime Timestamp { get; set; }
        public object Item { get; set; }
    }
    public class InMemoryCacheService : ICacheService
    {
        private static ConcurrentDictionary<string, TimeStampWrapper> cachedItems;

        public InMemoryCacheService()
        {
            if (cachedItems == null)
                cachedItems = new ConcurrentDictionary<string, TimeStampWrapper>();
        }

        public T GetData<T>(string name)
        {
            if (!Has(name))
                throw new BusinessException($"Cache: '{name}' is not a known cache name");

            var wrapper = cachedItems[name];
            if (wrapper.Item.GetType() == typeof(T))
                return (T)wrapper.Item;

            throw new BusinessException($"Cache: '{name}' is not from type {typeof(T)}");
        }

        public bool Has(string name)
        {
            return cachedItems.ContainsKey(name);
        }

        public void NewUpdatable<T>(string name, int intervalInMinutes, Func<T> funcUpdateData)
        where T : new()
        {
            if (Has(name))
                throw new BusinessException($"Cache: The name '{name}' is already being used by the cache");

            var wrappedItem = new TimeStampWrapper
            {
                Timestamp = DateTime.Now,
                Item = new T()
            };

            cachedItems.TryAdd(name, wrappedItem);

            var task = new Task(async () =>
            {
                while (true)
                {
                    cachedItems[name].Item = funcUpdateData();
                    // TODO: The code inside the task must automatically update the intervalInMinutes
                    await Task.Delay(intervalInMinutes * 60000);
                }
            });

            task.Start();
        }
    }
}
