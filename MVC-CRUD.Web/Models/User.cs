using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_CRUD.Web.Models
{
    public class User
    {
        public Int32 UserId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public String Address { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public String PhoneNo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public String Company { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public String Designation { get; set; }
    }
}