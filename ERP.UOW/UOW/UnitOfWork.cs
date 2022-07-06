using ERP.Models.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.UOW.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ERPDBContext _context;
        public UnitOfWork(ERPDBContext context)
        {
            _context = context;
            //User = new UserRepository(_context);
        }

        //public IUserRepository User
        //{
        //    get; private set;
        //}

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
