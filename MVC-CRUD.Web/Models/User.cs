using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD.Web.Models
{
    public class User
    {
        public Int32 UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
        public String PhoneNo { get; set; }
        public String Company { get; set; }
        public String Designation { get; set; }
    }
}