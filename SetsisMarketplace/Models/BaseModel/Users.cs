using System;
using System.Linq;

namespace MarketplaceUI.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string NameSurname { get; set; }
        public string Password { get; set; }
        public string Company { get; set; }
        public string State { get; set; }
    }
}
