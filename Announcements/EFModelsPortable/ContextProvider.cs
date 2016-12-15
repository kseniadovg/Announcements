using EFModels;
using System;

namespace EFModels
{
    public class ContextProvider : IContextProvider,IDisposable
    {
        private volatile Context context = null;
        private static object sync = new Object();

        public Context GetContext()
        {
            if (context == null)
            {
                lock (sync)
                {
                    if (context == null)
                    {
                        context = new Context();
                    }
                }
            }

            return context;
        }

        #region IDisposable

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }                
                disposedValue = true;
            }
        }        
        
        void IDisposable.Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
