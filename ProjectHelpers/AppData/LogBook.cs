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
    
    public partial class LogBook
    {
        public int LogID { get; set; }
        public int UserID { get; set; }
        public System.DateTime LogDate { get; set; }
        public string RegCode { get; set; }
        public string LogType { get; set; }
        public string Description { get; set; }
        public string RegDetails { get; set; }
    
        public virtual User User { get; set; }
    }
}
