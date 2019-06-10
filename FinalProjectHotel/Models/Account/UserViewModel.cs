using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace FinalProjectHotel.Models.Account
{
    public class UserViewModel
    {
        public List<SelectListItem> Usernames { get; set; }
        public int? userId { get; set; }
        public int? username { get; set; }
    }
}