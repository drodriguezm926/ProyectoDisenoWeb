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
            using (DB_EfoodEntities db = new DB_EfoodEntities())
            {
                try
                {   //Entidades de la base de datos
                    PriceType priceType = new PriceType();
                    priceType.PriceTypeCode = ConsecutivoModel.getConsecutivo("Precios");
                    priceType.PriceTypeDescription = modelo.PriceTypeDescription;
                    db.PriceTypes.Add(priceType);
                    db.SaveChanges(); 
                }
                catch (Exception e) { }
            }
        }

        public static void editDB(TipoPrecioModelo modelo)
        {
            try
            {
                using (DB_EfoodEntities vuelosDB = new DB_EfoodEntities())
                {
                    var datos = (from valor in vuelosDB.PriceTypes
                                 where valor.PriceTypeCode == modelo.PriceTypeCode
                                 select valor).SingleOrDefault();

                    datos.PriceTypeDescription = modelo.PriceTypeDescription;
                    vuelosDB.SaveChanges();
                }

            }
            catch (Exception x) { }
        }

        public static List<TipoPrecioModelo> ObtenerTerritorio()
        {
            try
            {
                using (DB_EfoodEntities vuelosDB = new DB_EfoodEntities())
                {
                    return (from territorio in vuelosDB.PriceTypes
                            select new TipoPrecioModelo
                            {
                                PriceTypeCode = territorio.PriceTypeCode,
                                PriceTypeDescription = territorio.PriceTypeDescription,
                            }).ToList();
                }

            }
            catch (Exception x) { return null; }
        }

        public static void deletetDB(TipoPrecioModelo modelo)
        {
            try
            {
                using (DB_EfoodEntities vuelosDB = new DB_EfoodEntities())
                {
                    var datos = (from valor in vuelosDB.PriceTypes
                                 where valor.PriceTypeCode == modelo.PriceTypeCode
                                 select valor).SingleOrDefault();

                    vuelosDB.PriceTypes.Remove(datos);
                    vuelosDB.SaveChanges();
                }

            }
            catch (Exception x) { }
        }

    }
}