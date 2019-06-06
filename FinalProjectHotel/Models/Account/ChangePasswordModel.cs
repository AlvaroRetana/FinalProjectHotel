using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProjectHotel.Models.Account
{
    public class ChangePasswordModel
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmNewPassword { get; set; }

    }
}