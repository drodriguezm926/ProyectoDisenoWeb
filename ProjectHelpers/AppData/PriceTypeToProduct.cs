//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectHelpers.AppData
{
    using System;
    using System.Collections.Generic;
    
    public partial class PriceTypeToProduct
    {
        public string PriceTypeCode { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }
    
        public virtual PriceType PriceType { get; set; }
        public virtual Product Product { get; set; }
    }
}
