//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PapaBobsMegaChallenge.Persistence
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public System.Guid Id { get; set; }
        public System.Guid CrustId { get; set; }
        public System.Guid SizeId { get; set; }
        public string Toppings { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public int Payment { get; set; }
        public bool Finished { get; set; }
    }
}
