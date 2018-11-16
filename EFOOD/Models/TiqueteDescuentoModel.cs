using EFOOD.App_Data;
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

        public static void addDB(TiqueteDescuentoModel modelo)
        {
            using (DB_EfoodEntities db = new DB_EfoodEntities())
            {
                try
                {   //Entidades de la base de datos
                    TicketDiscount newTicketDiscount = new TicketDiscount();
                    newTicketDiscount.TicketCode = ConsecutivoModel.getConsecutivo("Tiquetes de descuento");
                    newTicketDiscount.TicketDescription = modelo.TicketDescription;
                    newTicketDiscount.TicketDiscountPercentage = modelo.TicketDiscountPercentage;
                    newTicketDiscount.RemainingTickets = modelo.RemainingTickets;
                    db.TicketDiscounts.Add(newTicketDiscount);
                    db.SaveChanges();
                }
                catch (Exception e) { }
            }
        }

        public static void editDB(TiqueteDescuentoModel modelo)
        {
            try
            {
                using (DB_EfoodEntities db = new DB_EfoodEntities())
                {
                    var datos = (from valor in db.TicketDiscounts
                                 where valor.TicketCode == modelo.TicketCode
                                 select valor).SingleOrDefault();

                    datos.TicketDescription = modelo.TicketDescription;
                    datos.TicketDiscountPercentage = modelo.TicketDiscountPercentage;
                    datos.RemainingTickets = modelo.RemainingTickets;
                    db.SaveChanges();
                }

            }
            catch (Exception x) { }
        }

        public static List<TiqueteDescuentoModel> ObtenerTiquetesDescuento()
        {
            try
            {
                using (DB_EfoodEntities db = new DB_EfoodEntities())
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
            catch (Exception x) { return null; }
        }

        public static void deletetDB(TiqueteDescuentoModel modelo)
        {
            try
            {
                using (DB_EfoodEntities db = new DB_EfoodEntities())
                {
                    var datos = (from valor in db.TicketDiscounts
                                 where valor.TicketCode == modelo.TicketCode
                                 select valor).SingleOrDefault();

                    db.TicketDiscounts.Remove(datos);
                    db.SaveChanges();
                }

            }
            catch (Exception x) { }
        }
    }
}