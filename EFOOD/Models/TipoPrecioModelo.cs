using EFOOD.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFOOD.Models
{
    public class TipoPrecioModelo
    {
        public string PriceTypeCode { get; set; }
        public string PriceTypeDescription { get; set; }

        public static void AddDB(TipoPrecioModelo modelo)
        {
            using (DB_EfoodEntitie db = new DB_EfoodEntitie())
            {
                try
                {   //Entidades de la base de datos
                    PriceType priceType = new PriceType
                    {
                        PriceTypeCode = ConsecutivoModel.GetConsecutivo("Precios"),
                        PriceTypeDescription = modelo.PriceTypeDescription
                    };
                    db.PriceTypes.Add(priceType);
                    db.SaveChanges(); 
                }
                catch (Exception e) { ErrorLogModel.AddError(e); BitacoraModel.AddLogBook("a", "Anadir", Admin.ObtenerIdUsuario()); }
            }
        }

        public static void EditDB(TipoPrecioModelo modelo)
        {
            try
            {
                using (DB_EfoodEntitie vuelosDB = new DB_EfoodEntitie())
                {
                    var datos = (from valor in vuelosDB.PriceTypes
                                 where valor.PriceTypeCode == modelo.PriceTypeCode
                                 select valor).SingleOrDefault();

                    datos.PriceTypeDescription = modelo.PriceTypeDescription;
                    vuelosDB.SaveChanges();
                }

            }
            catch (Exception x) { ErrorLogModel.AddError(x); BitacoraModel.AddLogBook("e", "Edicion", Admin.ObtenerIdUsuario()); }
        }

        public static List<TipoPrecioModelo> ObtenerTerritorio()
        {
            try
            {
                using (DB_EfoodEntitie vuelosDB = new DB_EfoodEntitie())
                {
                    return (from territorio in vuelosDB.PriceTypes
                            select new TipoPrecioModelo
                            {
                                PriceTypeCode = territorio.PriceTypeCode,
                                PriceTypeDescription = territorio.PriceTypeDescription,
                            }).ToList();
                }

            }
            catch (Exception x) { ErrorLogModel.AddError(x);  return null; }
        }

        public static void DeletetDB(TipoPrecioModelo modelo)
        {
            try
            {
                using (DB_EfoodEntitie vuelosDB = new DB_EfoodEntitie())
                {
                    var datos = (from valor in vuelosDB.PriceTypes
                                 where valor.PriceTypeCode == modelo.PriceTypeCode
                                 select valor).SingleOrDefault();

                    vuelosDB.PriceTypes.Remove(datos);
                    BitacoraModel.AddLogBook("n", "Borrar", Admin.ObtenerIdUsuario());
                    vuelosDB.SaveChanges();
                }

            }
            catch (Exception x) { ErrorLogModel.AddError(x);  }
        }

    }
}