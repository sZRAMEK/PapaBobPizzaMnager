using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobsMegaChallenge.DTO
{
    public class PizzaInformations
    {
        public Guid Id { get; set; }
        public string Size { get; set; }
        public string Crust { get; set; }
        public string Toppings { get; set; }
    }
}
