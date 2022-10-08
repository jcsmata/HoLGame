using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.DATA.Infrastructure
{
    public class UnitOfWork<T> : IDisposable, IUnitOfWork<T> where T : DbContext, new()
    {
        private readonly IDbFactory<T> dbFactory;
        private T context;
        private bool _disposed = false;

        public UnitOfWork(IDbFactory<T> dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public T Context
        {
            get { return context ?? (context = dbFactory.Init()); }
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
        public Task<int> CommitAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}
