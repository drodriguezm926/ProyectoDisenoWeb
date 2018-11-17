using EFOOD.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFOOD.Models
{
    public class TarjetaCreditoDebitoModel
    {
        public string CardCode { get; set; }
        public string CardDescription { get; set; }

        public static void addDB(TarjetaCreditoDebitoModel modelo)
        {
            using (DB_EfoodEntitie db = new DB_EfoodEntitie())
            {
                try
                {   //Entidades de la base de datos
                    Card newCard = new Card();
                    newCard.CardCode = ConsecutivoModel.getConsecutivo("Tarjetas");
                    newCard.CardDescription = modelo.CardDescription;
                    db.Cards.Add(newCard);
                    BitacoraModel.addLogBook("a", "Anadir", Admin.obtenerIdUsuario());
                    db.SaveChanges();
                }
                catch (Exception e) { ErrorLogModel.addError(e);  }
            }
        }

        public static void editDB(TarjetaCreditoDebitoModel modelo)
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                    var datos = (from valor in db.Cards
                                 where valor.CardCode == modelo.CardCode
                                 select valor).SingleOrDefault();

                    datos.CardDescription = modelo.CardDescription;
                    BitacoraModel.addLogBook("e", "Edicion", Admin.obtenerIdUsuario());
                    db.SaveChanges();
                }

            }
            catch (Exception x) { ErrorLogModel.addError(x); }
        }

        public static List<TarjetaCreditoDebitoModel> obtenerTarjetas()
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                    return (from card in db.Cards
                            select new TarjetaCreditoDebitoModel
                            {
                                CardCode = card.CardCode,
                                CardDescription = card.CardDescription,
                            }).ToList();
                }

            }
            catch (Exception x) { ErrorLogModel.addError(x); return null; }
        }

        public static void deletetDB(TarjetaCreditoDebitoModel modelo)
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                    var datos = (from valor in db.Cards
                                 where valor.CardCode == modelo.CardCode
                                 select valor).SingleOrDefault();

                    db.Cards.Remove(datos);
                    db.SaveChanges();
                }

            }
            catch (Exception x) { ErrorLogModel.addError(x); BitacoraModel.addLogBook("n", "Borrar", Admin.obtenerIdUsuario()); }
        }
    }
}