using System;
using System.Collections.Generic;

namespace BootStrap.Data
{
    public class DisposeService: IDisposable, IDisposeService
    {
        private List<IPresentor> _disposibleObjects = new();

        public void AddDisposableObject(IPresentor presentor)
        {
            _disposibleObjects.Add(presentor);   
        }
            
        public void Dispose()
        {
            foreach (IPresentor presentor in _disposibleObjects)
            {
                presentor.Disable();
            }
        }
    }
}