//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFOOD.App_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class TicketDiscount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TicketDiscount()
        {
            this.Customers = new HashSet<Customer>();
        }
    
        public string TicketCode { get; set; }
        public string TicketDescription { get; set; }
        public double TicketDiscountPercentage { get; set; }
        public int RemainingTickets { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
