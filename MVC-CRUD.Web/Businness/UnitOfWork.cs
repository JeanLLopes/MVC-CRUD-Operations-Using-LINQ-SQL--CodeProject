using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using MVC_CRUD.Web.Data;

namespace MVC_CRUD.Web.Businness
{
    public class UnitOfWork : IDisposable
    {
        private MVCEntities _context = new MVCEntities();
        private GenericRepository<User> _useRepository;
        private Boolean _disposed = false;

        #region
        //INITIALIZER
        public GenericRepository<User> UseRepository
        {
            get
            {
                if (_useRepository == null)
                {
                    _useRepository = new GenericRepository<User>(_context);

                    return _useRepository;
                }
                return null;
            }
        } 
#endregion


        public void Save()
        {
            _context.SaveChanges();
        }






        protected virtual void Dispose(bool _disposed)
        {
            if (!this._disposed)
            {
                if (_disposed)
                {
                    _context.Dispose();
                }
            }

            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}