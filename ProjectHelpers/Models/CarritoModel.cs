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
        public class ConsultaCarrito
        {
            public int CartID { get; set; }
            public string ProductCode { get; set; }
            public string DescriptionCarrito { get; set; }
            public string ProductDescription { get; set; }
            public double PrecioUnitario { get; set; }
            public int Quantity { get; set; }
            public double Total { get; set; }
            public string ProductImage { get; set; }
        }

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

                var precio = (from valor in db.PriceTypeToProducts
                             where valor.ProductCode == modelo.ProductCode
                             select valor).SingleOrDefault();


                try
                {
                    //Entidades de la base de datos
                    ProductToCar agregarACarro = new ProductToCar
                    {
                        CartID = Carrito,
                        ProductCode = modelo.ProductCode,
                        Quantity = log.Quantity + 1,
                    };
                    db.ProductToCars.Add(agregarACarro);
                    db.SaveChanges();
                    
                    log.Quantity = log.Quantity + 1;
                    log.Total = log.Total + precio.Price;
                    db.SaveChanges();
                    //BitacoraModel.AddLogBook("a", "Anadir", Customer.ObtenerIdCustomer());
                }
                catch (Exception e) { ErrorLogModel.AddError(e); }
            }
        }

        public static List<ConsultaCarrito> CargarCarrito(int idCarrito)
        {
            try
            {
                using (efooddatabaseEntities db = new efooddatabaseEntities())
                {

                    var log = from carrito in db.Payments
                              join productosEnCarrito in db.ProductToCars on carrito.CartID equals productosEnCarrito.CartID
                              join productos in db.Products on productosEnCarrito.ProductCode equals productos.ProductCode
                              join preciosProducto in db.PriceTypeToProducts on productos.ProductCode equals preciosProducto.ProductCode
                              where carrito.CartID == idCarrito

                              select new ConsultaCarrito
                              {
                                  CartID = carrito.CartID,
                                  ProductCode = productos.ProductCode,
                                  DescriptionCarrito = carrito.Description,
                                  ProductDescription = productos.ProductDescription,
                                  PrecioUnitario = preciosProducto.Price,
                                  Quantity = productosEnCarrito.Quantity,
                                  Total = carrito.Total,
                                  ProductImage = productos.ProductImage
                              };

                    return log.ToList();

                }

            }
            catch (Exception x) { ErrorLogModel.AddError(x); return null; }
        }


    }
}
