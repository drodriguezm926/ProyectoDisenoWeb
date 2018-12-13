using ProjectHelpers.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class TiqueteDescuentoModel
    {
        public string TicketCode { get; set; }
        public string TicketDescription { get; set; }
        public double TicketDiscountPercentage { get; set; }
        public int RemainingTickets { get; set; }

        public static void AddDB(TiqueteDescuentoModel modelo)
        {
            using (efooddatabaseEntities db = new efooddatabaseEntities())
            {
                try
                {   //Entidades de la base de datos
                    TicketDiscount newTicketDiscount = new TicketDiscount
                    {
                        TicketCode = ConsecutivoModel.GetConsecutivo("Tiquetes de descuento"),
                        TicketDescription = modelo.TicketDescription,
                        TicketDiscountPercentage = modelo.TicketDiscountPercentage,
                        RemainingTickets = modelo.RemainingTickets
                    };
                    db.TicketDiscounts.Add(newTicketDiscount);
                    db.SaveChanges();
                    BitacoraModel.AddLogBook("a", "Anadir", Admin.ObtenerIdUsuario());
                }
                catch (Exception e) { ErrorLogModel.AddError(e);  }
            }
        }

        public static void EditDB(TiqueteDescuentoModel modelo)
        {
            try
            {
                using (efooddatabaseEntities db = new efooddatabaseEntities())
                {
                    var datos = (from valor in db.TicketDiscounts
                                 where valor.TicketCode == modelo.TicketCode
                                 select valor).SingleOrDefault();

                    datos.TicketDescription = modelo.TicketDescription;
                    datos.TicketDiscountPercentage = modelo.TicketDiscountPercentage;
                    datos.RemainingTickets = modelo.RemainingTickets;
                    db.SaveChanges();
                    BitacoraModel.AddLogBook("e", "Edicion", Admin.ObtenerIdUsuario());
                }

            }
            catch (Exception x) { ErrorLogModel.AddError(x);  }
        }

        public static List<TiqueteDescuentoModel> ObtenerTiquetesDescuento()
        {
            try
            {
                using (efooddatabaseEntities db = new efooddatabaseEntities())
                {
                    return (from tiquetes in db.TicketDiscounts
                            select new TiqueteDescuentoModel
                            {
                                TicketCode = tiquetes.TicketCode,
                                TicketDescription = tiquetes.TicketDescription,
                                TicketDiscountPercentage = tiquetes.TicketDiscountPercentage,
                                RemainingTickets = tiquetes.RemainingTickets
                            }).ToList();
                }

            }
            catch (Exception x) { ErrorLogModel.AddError(x);  return null; }
        }

        public static void DeletetDB(TiqueteDescuentoModel modelo)
        {
            try
            {
                using (efooddatabaseEntities db = new efooddatabaseEntities())
                {
                    var datos = (from valor in db.TicketDiscounts
                                 where valor.TicketCode == modelo.TicketCode
                                 select valor).SingleOrDefault();

                    db.TicketDiscounts.Remove(datos);
                    db.SaveChanges();
                    BitacoraModel.AddLogBook("n", "Borrar", Admin.ObtenerIdUsuario());
                }

            }
            catch (Exception x) { ErrorLogModel.AddError(x);  }
        }
    }
}