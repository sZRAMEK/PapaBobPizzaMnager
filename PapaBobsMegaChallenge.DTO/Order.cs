using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobsMegaChallenge.DTO
{
    public class Order
    {
        public Guid SizeId { get; set; }
        public Guid CrustId { get; set; }
        public string ToppingIds { get; set; }
        public PaymentMethod paymentMethod { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public bool Finished { get; set; }
    }

    public enum PaymentMethod {Cash, Credit};
}
