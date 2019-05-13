using System;

namespace DistroGuide.App_Domain.Services
{
    public interface ICacheService
    {
        bool Has(string name);
        void NewUpdatable<T>(string name, int intervalInMinutes, Func<T> funcUpdateData)
        where T : new();
        T GetData<T>(string name);
    }
}