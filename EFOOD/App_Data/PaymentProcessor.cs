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
    
    public partial class PaymentProcessor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PaymentProcessor()
        {
            this.Cards = new HashSet<Card>();
        }
    
        public string PaymentProcessorCode { get; set; }
        public string PaymentProcessorName { get; set; }
        public string PaymentProcessorDescription { get; set; }
        public string PaymentProcessorType { get; set; }
        public bool PaymentProcessorStatus { get; set; }
        public bool PaymentProcessorVerify { get; set; }
        public string PaymentProcessorMethod { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Card> Cards { get; set; }
    }
}
