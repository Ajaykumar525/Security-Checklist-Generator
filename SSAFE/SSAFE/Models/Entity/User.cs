using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSAFE.Models.Entity
{
    public class User
    {
        public IList<UserData> users { get; set; }

    }
}