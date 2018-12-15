using ProjectHelpers.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CarritoModel
    {
        public int CartID { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public string Description { get; set; }

        public static bool ExisteEnCarrito(ProductoModel modelo, int Carrito)
        {
            using (efooddatabaseEntities db = new efooddatabaseEntities())
            {
                var log = (from valor in db.ProductToCars
                           where valor.ProductCode == modelo.ProductCode
                           select valor).SingleOrDefault();
                if(log != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void AddProductDB(ProductoModel modelo, int Carrito)
        {
            using (efooddatabaseEntities db = new efooddatabaseEntities())
            {
                var log = (from valor in db.Payments
                           where valor.CartID == Carrito
                           select valor).SingleOrDefault();


                try
                {
                    //Entidades de la base de datos
                    ProductToCar agregarACarro = new ProductToCar
                    {
                        CartID = Carrito,
                        ProductCode = modelo.ProductCode,
                        Quantity = log.Quantity + 1
                    };
                    db.ProductToCars.Add(agregarACarro);
                    db.SaveChanges();
                    //BitacoraModel.AddLogBook("a", "Anadir", Customer.ObtenerIdCustomer());
                }
                catch (Exception e) { ErrorLogModel.AddError(e); }
            }
        }
    }
}
