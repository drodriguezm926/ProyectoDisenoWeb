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

        public static void addDB(TipoPrecioModelo modelo)
        {
            using (DB_EfoodEntitie db = new DB_EfoodEntitie())
            {
                try
                {   //Entidades de la base de datos
                    PriceType priceType = new PriceType();
                    priceType.PriceTypeCode = ConsecutivoModel.getConsecutivo("Precios");
                    priceType.PriceTypeDescription = modelo.PriceTypeDescription;
                    db.PriceTypes.Add(priceType);
                    db.SaveChanges(); 
                }
                catch (Exception e) { ErrorLogModel.addError(e); }
            }
        }

        public static void editDB(TipoPrecioModelo modelo)
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
            catch (Exception x) { ErrorLogModel.addError(x); }
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
            catch (Exception x) { ErrorLogModel.addError(x);  return null; }
        }

        public static void deletetDB(TipoPrecioModelo modelo)
        {
            try
            {
                using (DB_EfoodEntitie vuelosDB = new DB_EfoodEntitie())
                {
                    var datos = (from valor in vuelosDB.PriceTypes
                                 where valor.PriceTypeCode == modelo.PriceTypeCode
                                 select valor).SingleOrDefault();

                    vuelosDB.PriceTypes.Remove(datos);
                    vuelosDB.SaveChanges();
                }

            }
            catch (Exception x) { ErrorLogModel.addError(x); }
        }

    }
}