using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_CRUD.Web.Data
{
    public class MVCDBContext : DbContext
    {
        public DbSet<Models.User> Users { get; set; }
    }
}