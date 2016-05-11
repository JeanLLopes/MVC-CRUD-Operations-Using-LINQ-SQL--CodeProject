using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MVC_CRUD.Web.Data;

namespace MVC_CRUD.Web.Repository
{
    public class UserRepository:IUserRepository
    {

        private readonly MVCEntities _context = new MVCEntities();

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserByID(int userId)
        {
            return _context.Users.Find(userId);
        }

        public void InsertUser(User user)
        {
            _context.Users.Add(user);
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            _context.Users.Remove(user);
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }







        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}