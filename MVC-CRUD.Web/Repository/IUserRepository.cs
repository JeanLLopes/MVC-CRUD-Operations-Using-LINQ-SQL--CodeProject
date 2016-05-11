using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_CRUD.Web.Models;

namespace MVC_CRUD.Web.Repository
{
    interface IUserRepository:IDisposable
    {
        List<Data.User> GetUsers();
        Data.User GetUserByID(int userId);
        void InsertUser(Data.User user);
        void DeleteUser(int userId);
        void UpdateUser(Data.User user);
        void Save();
    }
}
