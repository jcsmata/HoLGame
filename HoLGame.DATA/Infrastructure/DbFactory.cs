using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.DATA.Infrastructure
{
    public class DbFactory<T> : Disposable, IDbFactory<T> where T : DbContext, new()
    {
        private T dbContext;

        public DbFactory(T context)
        {
            dbContext = context;
        }

        public T Init()
        {
            return dbContext;
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
