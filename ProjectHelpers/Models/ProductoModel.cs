using ProjectHelpers.AppData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Models
{
    public class ProductoModel
    {
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public string FoodOptionCode { get; set; }
        public string ProductContent { get; set; }
        public string ProductImage { get; set; }
        public HttpPostedFileBase Archivo { get; set; }


        public static void AddDB(ProductoModel modelo, string idTipoDeProducto,double precio)
        {
            using (efooddatabaseEntities db = new efooddatabaseEntities())
            {
                try
                {
                    string codigoDeProducto = ConsecutivoModel.GetConsecutivo("Productos");
                    //Entidades de la base de datos
                    Product product = new Product
                    {
                        ProductCode = codigoDeProducto,
                        ProductDescription = modelo.ProductDescription,
                        FoodOptionCode = modelo.FoodOptionCode,
                        ProductContent = modelo.ProductContent,
                        ProductImage = modelo.ProductImage
                    };
                    db.Products.Add(product);
                    db.SaveChanges();

                    PriceTypeToProduct priceToProduct = new PriceTypeToProduct
                    {
                        PriceTypeCode = idTipoDeProducto,
                        ProductCode = codigoDeProducto,
                        Price = precio
                    };
                    db.PriceTypeToProducts.Add(priceToProduct);
                    db.SaveChanges();
                    BitacoraModel.AddLogBook("a", "Anadir", Admin.ObtenerIdUsuario());
                }
                catch (Exception e) { ErrorLogModel.AddError(e);  }
            }
        }

        public static void EditDB(ProductoModel modelo)
        {
            try
            {
                using (efooddatabaseEntities db = new efooddatabaseEntities())
                {
                    var datos = (from valor in db.Products
                                 where valor.ProductCode == modelo.ProductCode
                                 select valor).SingleOrDefault();

                    datos.ProductDescription = modelo.ProductDescription;
                    datos.FoodOptionCode = modelo.FoodOptionCode;
                    datos.ProductContent = modelo.ProductContent;
                    //datos.ProductImage = null; 
                    db.SaveChanges();
                    BitacoraModel.AddLogBook("e", "Edicion", Admin.ObtenerIdUsuario());
                }

            }
            catch (Exception x) { ErrorLogModel.AddError(x);  }
        }

        public static List<ProductoModel> ObtenerProductos()
        {
            try
            {
                using (efooddatabaseEntities db = new efooddatabaseEntities())
                {
                    return (from productos in db.Products
                            select new ProductoModel
                            {
                                ProductCode = productos.ProductCode,
                                ProductDescription = productos.ProductDescription,
                                FoodOptionCode = productos.FoodOptionCode,
                                ProductContent = productos.ProductContent,
                                ProductImage = productos.ProductImage
                            }).ToList();
                }

            }
            catch (Exception x) { ErrorLogModel.AddError(x); return null; }
        }


        public static List<ProductoModel> ObtenerProductosFiltrados(ProductoModel modelo)
        {
            try
            {
                using (efooddatabaseEntities db = new efooddatabaseEntities())
                {
                    var logs = from productos in db.Products
                              select new ProductoModel
                              {
                                  ProductCode = productos.ProductCode,
                                  ProductDescription = productos.ProductDescription,
                                  FoodOptionCode = productos.FoodOptionCode,
                                  ProductContent = productos.ProductContent,
                                  ProductImage = productos.ProductImage
                              };

                    if (modelo.FoodOptionCode != null)
                    {
                        logs = logs.Where(producto => producto.FoodOptionCode == modelo.FoodOptionCode);
                    }

                    return logs.ToList();
                }

            }
            catch (Exception x) { ErrorLogModel.AddError(x); return null; }
        }


        public static void DeletetDB(ProductoModel modelo)
        {
            try
            {
                using (efooddatabaseEntities db = new efooddatabaseEntities())
                {
                    var datos = (from valor in db.Products
                                 where valor.ProductCode == modelo.ProductCode
                                 select valor).SingleOrDefault();
                    db.Products.Remove(datos);
                    db.SaveChanges();
                    BitacoraModel.AddLogBook("n", "Borrar", Admin.ObtenerIdUsuario());
                }

            }
            catch (Exception x) {
                

                ErrorLogModel.AddError(x); ;
            }
        }
    }
}