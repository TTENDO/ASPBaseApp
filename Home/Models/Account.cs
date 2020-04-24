using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home.Models
{
    public class Account
    {
        public string _id { get; set; }
        public string userId { get; set; }
        public decimal balance { get; set; }
        public string createdDate { get; set; }
        public string modifiedDate { get; set; }
    }
}
