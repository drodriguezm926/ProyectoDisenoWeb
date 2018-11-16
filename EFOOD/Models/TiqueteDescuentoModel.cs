using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFOOD.Models
{
    public class TiqueteDescuentoModel
    {
        public string TicketCode { get; set; }
        public string TicketDescription { get; set; }
        public double TicketDiscountPercentage { get; set; }
        public int RemainingTickets { get; set; }
    }
}