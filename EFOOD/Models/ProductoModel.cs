﻿using EFOOD.App_Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EFOOD.Models
{
    public class ProductoModel
    {
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public string FoodOptionCode { get; set; }
        public string ProductContent { get; set; }
        public string ProductImage { get; set; }
        public HttpPostedFileBase Archivo { get; set; }


        public static void addDB(ProductoModel modelo)
        {
            using (DB_EfoodEntitie db = new DB_EfoodEntitie())
            {
                try
                {   //Entidades de la base de datos
                    Product product = new Product();
                    product.ProductCode = ConsecutivoModel.getConsecutivo("Productos");
                    product.ProductDescription = modelo.ProductDescription;
                    product.FoodOptionCode = modelo.FoodOptionCode;
                    product.ProductContent = modelo.ProductContent;
                    product.ProductImage = modelo.ProductImage;
                    db.Products.Add(product);
                    db.SaveChanges();
                }
                catch (Exception e) { ErrorLogModel.addError(e); }
            }
        }

        public static void editDB(ProductoModel modelo)
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                    var datos = (from valor in db.Products
                                 where valor.ProductCode == modelo.ProductCode
                                 select valor).SingleOrDefault();

                    datos.ProductDescription = modelo.ProductDescription;
                    datos.FoodOptionCode = modelo.FoodOptionCode;
                    datos.ProductContent = modelo.ProductContent;
                    datos.ProductImage = null;
                    db.SaveChanges();
                }

            }
            catch (Exception x) { ErrorLogModel.addError(x); }
        }

        public static List<ProductoModel> ObtenerProductos()
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
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
            catch (Exception x) { ErrorLogModel.addError(x); return null; }
        }


        public static List<ProductoModel> ObtenerProductosFiltrados(ProductoModel modelo)
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
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
            catch (Exception x) { ErrorLogModel.addError(x); return null; }
        }

        public static void deletetDB(ProductoModel modelo)
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                    var datos = (from valor in db.Products
                                 where valor.ProductCode == modelo.ProductCode
                                 select valor).SingleOrDefault();

                    db.Products.Remove(datos);
                    db.SaveChanges();
                }

            }
            catch (Exception x) { ErrorLogModel.addError(x); }
        }
    }
}