using EFOOD.Models;
using EFood_ECommerce.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFood_ECommerce.Models
{
    public class ProductoModel
    {

        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public string FoodOptionCode { get; set; }
        public string ProductContent { get; set; }
        public string ProductImage { get; set; }
        public HttpPostedFileBase Archivo { get; set; }

        public static List<ProductoModel> ObtenerProductos()
        {
            try
            {
                using (Entities db = new Entities())
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

    }
}