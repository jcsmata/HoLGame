using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.DATA.Infrastructure
{
    public interface IDbFactory<T> : IDisposable where T : DbContext
    {
        T Init();
    }
}
