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


        public static void AddDB(ProductoModel modelo)
        {
            using (efooddatabaseEntities db = new efooddatabaseEntities())
            {
                try
                {   //Entidades de la base de datos
                    Product product = new Product
                    {
                        ProductCode = ConsecutivoModel.GetConsecutivo("Productos"),
                        ProductDescription = modelo.ProductDescription,
                        FoodOptionCode = modelo.FoodOptionCode,
                        ProductContent = modelo.ProductContent,
                        ProductImage = modelo.ProductImage
                    };
                    db.Products.Add(product);
                    db.SaveChanges();
                }
                catch (Exception e) { ErrorLogModel.AddError(e); BitacoraModel.AddLogBook("a", "Anadir", Admin.ObtenerIdUsuario()); }
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
                    datos.ProductImage = null; BitacoraModel.AddLogBook("e", "Edicion", Admin.ObtenerIdUsuario());
                    db.SaveChanges();
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
                    return (from productos in db.Products
                            where productos.FoodOptionCode == modelo.FoodOptionCode
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


        public static void DeletetDB(ProductoModel modelo)
        {
            try
            {
                using (efooddatabaseEntities db = new efooddatabaseEntities())
                {
                    var datos = (from valor in db.Products
                                 where valor.ProductCode == modelo.ProductCode
                                 select valor).SingleOrDefault();


                    BitacoraModel.AddLogBook("n", "Borrar", Admin.ObtenerIdUsuario());
                    db.SaveChanges();
                   
                }

            }
            catch (Exception x) {
                

                ErrorLogModel.AddError(x); BitacoraModel.AddLogBook("n", "Borrar", Admin.ObtenerIdUsuario());;
            }
        }
    }
}