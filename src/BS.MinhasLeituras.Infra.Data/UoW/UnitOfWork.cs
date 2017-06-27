using System;
using BS.MinhasLeituras.Infra.Data.Interfaces;
using BS.MinhasLeituras.Infra.Data.Context;

namespace BS.MinhasLeituras.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfwork
    {
        private readonly MinhasLeiturasContext _context;

        private bool _disposed;

        public UnitOfWork(MinhasLeiturasContext context) 
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
