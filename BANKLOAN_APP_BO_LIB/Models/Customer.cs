using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BANKLOAN_APP_BO_LIB.Models
{
    public class Customer
    {
        public int CustomerId {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string KycStatus { get; set; } //default-pending
    
    }
}
