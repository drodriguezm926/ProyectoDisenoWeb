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

        public static void AddDB(TarjetaCreditoDebitoModel modelo)
        {
            using (DB_EfoodEntitie db = new DB_EfoodEntitie())
            {
                try
                {   //Entidades de la base de datos
                    Card newCard = new Card
                    {
                        CardCode = ConsecutivoModel.GetConsecutivo("Tarjetas"),
                        CardDescription = modelo.CardDescription
                    };
                    db.Cards.Add(newCard);
                    BitacoraModel.AddLogBook("a", "Anadir", Admin.ObtenerIdUsuario());
                    db.SaveChanges();
                }
                catch (Exception e) { ErrorLogModel.AddError(e);  }
            }
        }

        public static void EditDB(TarjetaCreditoDebitoModel modelo)
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                    var datos = (from valor in db.Cards
                                 where valor.CardCode == modelo.CardCode
                                 select valor).SingleOrDefault();

                    datos.CardDescription = modelo.CardDescription;
                    BitacoraModel.AddLogBook("e", "Edicion", Admin.ObtenerIdUsuario());
                    db.SaveChanges();
                }

            }
            catch (Exception x) { ErrorLogModel.AddError(x); }
        }

        public static List<TarjetaCreditoDebitoModel> ObtenerTarjetas()
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
            catch (Exception x) { ErrorLogModel.AddError(x); return null; }
        }

        public static void DeletetDB(TarjetaCreditoDebitoModel modelo)
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
            catch (Exception x) { ErrorLogModel.AddError(x); BitacoraModel.AddLogBook("n", "Borrar", Admin.ObtenerIdUsuario()); }
        }
    }
}