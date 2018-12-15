using Models;
using ProjectHelpers.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TipoPrecioToProduct
    {
        public string PriceTypeCode { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }

        public static void AddDB(TipoPrecioToProduct model)
        {
            using (efooddatabaseEntities db = new efooddatabaseEntities())
            {
                try
                {   //Entidades de la base de datos
                    PriceTypeToProduct priceType = new PriceTypeToProduct
                    {
                        PriceTypeCode = model.PriceTypeCode,
                        ProductCode = model.ProductCode,
                        Price = model.Price
                    };
                    db.PriceTypeToProducts.Add(priceType);
                    db.SaveChanges();
                    BitacoraModel.AddLogBook("a", "Anadir", Admin.ObtenerIdUsuario());
                }   
                catch (Exception e) { ErrorLogModel.AddError(e); }
            }
        }
    }
}
