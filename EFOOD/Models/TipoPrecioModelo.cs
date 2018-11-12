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
                {
                    var numeroConsecutivo = (from valor in db.Consecutives
                                             where valor.Description == "Precio"
                                             select valor).SingleOrDefault();

                    PriceType priceType = new PriceType();
                    priceType.PriceTypeCode = "1";
                    priceType.PriceTypeDescription = modelo.PriceTypeDescription;
                    db.PriceTypes.Add(priceType);
                    db.SaveChanges();
                }
                catch (Exception e) { }
            }
        }
    }
}