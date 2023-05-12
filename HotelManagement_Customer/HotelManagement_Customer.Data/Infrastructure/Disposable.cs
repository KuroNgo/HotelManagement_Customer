using System;

namespace HotelManagement_Customer.Data.Infrastructure
{
    // Interface available, it is allow their used it automatic destroy 
    public class Disposable : IDisposable
    {
        private bool isDisposed;
        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }
            isDisposed = true;
        }

        //Override this to dispose custom object
        protected virtual void DisposeCore()
        {

        }
    }
}
