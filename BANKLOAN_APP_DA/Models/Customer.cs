using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKLOAN_APP_DA_LIB.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string KycStatus { get; set; } //default-pending
        public override string ToString()
        {
            return string.Format($"{CustomerId,10}{Name,20}{Email,20}{Phone,15}{Address,30}{Password,15}{KycStatus,15}");
        }
    }
}
