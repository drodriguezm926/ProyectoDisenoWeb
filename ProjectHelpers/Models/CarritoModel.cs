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
                           where valor.ProductCode == modelo.ProductCode &&
                                 valor.CartID == Carrito
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
                        Quantity = 1,
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

        public static void DeleteProductDB(ProductoModel modelo, int Carrito)
        {
            using (efooddatabaseEntities db = new efooddatabaseEntities())
            {
                try
                {
                    var log = (from valor in db.Payments
                               where valor.CartID == Carrito
                               select valor).SingleOrDefault();

                    var precio = (from valor in db.PriceTypeToProducts
                                  where valor.ProductCode == modelo.ProductCode
                                  select valor).SingleOrDefault();

                    var productoAEliminar = (from producto in db.ProductToCars
                                             where producto.CartID == Carrito &&
                                                   producto.ProductCode == modelo.ProductCode
                                             select producto).SingleOrDefault();

                    log.Quantity = log.Quantity - productoAEliminar.Quantity;
                    log.Total = log.Total - (precio.Price * productoAEliminar.Quantity);
                    db.SaveChanges();

                    
                    db.ProductToCars.Remove(productoAEliminar);
                    db.SaveChanges();
                    //BitacoraModel.AddLogBook("a", "Anadir", Customer.ObtenerIdCustomer());
                    
                }
                catch (Exception e) { ErrorLogModel.AddError(e); }
            }
        }

        public static void DeleteAllCarritoDB(int Carrito)
        {
            using (efooddatabaseEntities db = new efooddatabaseEntities())
            {
                try
                {
                    var productToCar = (from productos in db.ProductToCars
                                        where productos.CartID == Carrito
                                        select productos).SingleOrDefault();

                    var carrito = (from carro in db.Payments
                                   where carro.CartID == Carrito
                                   select carro).SingleOrDefault();

                    db.ProductToCars.Remove(productToCar);
                    db.SaveChanges();

                    carrito.Quantity = 0;
                    carrito.Total = 0;
                    db.SaveChanges();
                    //BitacoraModel.AddLogBook("a", "Anadir", Customer.ObtenerIdCustomer());

                }
                catch (Exception e) { ErrorLogModel.AddError(e); }
            }
        }

        public static void DeleteAllPedido(int Carrito)
        {
            using (efooddatabaseEntities db = new efooddatabaseEntities())
            {
                try
                {
                    var productToCar = (from productos in db.ProductToCars
                                        where productos.CartID == Carrito
                                        select productos);

                    var carrito = (from carro in db.Payments
                                   where carro.CartID == Carrito
                                   select carro).SingleOrDefault();
                    foreach (var item in productToCar)
                    {
                        db.ProductToCars.Remove(item);
                    }
                    db.SaveChanges();

                    carrito.Quantity = 0;
                    carrito.Total = 0;
                    db.SaveChanges();
                    //BitacoraModel.AddLogBook("a", "Anadir", Customer.ObtenerIdCustomer());

                }
                catch (Exception e) { ErrorLogModel.AddError(e); }
            }
        }

        public static void EditProductDB(ProductoModel modelo, int Carrito)
        {
            using (efooddatabaseEntities db = new efooddatabaseEntities())
            {
                try
                {
                    var log = (from valor in db.Payments
                               where valor.CartID == Carrito
                               select valor).SingleOrDefault();

                    var precio = (from valor in db.PriceTypeToProducts
                                  where valor.ProductCode == modelo.ProductCode
                                  select valor).SingleOrDefault();

                    var productoAEditar = (from producto in db.ProductToCars
                                           where producto.CartID == Carrito &&
                                                 producto.ProductCode == modelo.ProductCode
                                           select producto).SingleOrDefault();

                    int valorACalcular = productoAEditar.Quantity - modelo.cantidad;

                    if (modelo.cantidad == 0)
                    {
                        DeleteProductDB(modelo, Carrito);
                    } 
                    else if (valorACalcular < 0)
                    {
                        // Si la resta del valor actual menos la cantidad nueva ingresada da valores negativo,
                        // este significa que esta agregando más productos.
                        log.Quantity = log.Quantity + Math.Abs(valorACalcular);
                        log.Total = log.Total + (precio.Price * Math.Abs(valorACalcular));
                        db.SaveChanges();
                    }
                    else if (valorACalcular > 0)
                    {
                        // Si la resta del valor actual menos la cantidad nueva ingresada da valores positivos,
                        // este significa que están eliminando productos.
                        log.Quantity = log.Quantity - Math.Abs(valorACalcular);
                        log.Total = log.Total - (precio.Price * Math.Abs(valorACalcular));
                        db.SaveChanges();
                    }

                    if(modelo.cantidad != 0)
                    {
                        productoAEditar.Quantity = modelo.cantidad;
                        db.SaveChanges();
                    }
                    
                    //BitacoraModel.AddLogBook("a", "Anadir", Customer.ObtenerIdCustomer());

                }
                catch (Exception e) { ErrorLogModel.AddError(e); }
            }
        }


    }
}
