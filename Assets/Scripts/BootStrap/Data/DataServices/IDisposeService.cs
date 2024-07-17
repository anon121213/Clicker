using System;

namespace BootStrap.Data.DataServices
{
    public interface IDisposeService
    {
        void AddDisposableObject(IDisposable presentor);
    }
}