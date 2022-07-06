using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        //IUserRepository User { get; }
        int SaveChanges();
    }
}
