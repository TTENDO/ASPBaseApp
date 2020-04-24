using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home.Models
{
    public class User
    {
        public string _id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string createdDate { get; set; }
        public string modifiedDate { get; set; }
    }
}
