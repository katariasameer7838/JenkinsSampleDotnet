using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Nagarro.BookEvents.Main.Models
{
    public class LoginModel
    {
        [DisplayName("Email Id")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}