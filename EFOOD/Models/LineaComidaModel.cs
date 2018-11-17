using EFOOD.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFOOD.Models
{
    public class LineaComidaModel
    {
        public string FoodOptionCode { get; set; }
        public string FoodOptionDescription { get; set; }

        public static void addDB(LineaComidaModel modelo)
        {
            using (DB_EfoodEntities db = new DB_EfoodEntities())
            {
                try
                {   //Entidades de la base de datos
                    FoodOption foodOption = new FoodOption();
                    foodOption.FoodOptionCode = ConsecutivoModel.getConsecutivo("Líneas de comida");
                    foodOption.FoodOptionDescription = modelo.FoodOptionDescription;
                    db.FoodOptions.Add(foodOption);
                    db.SaveChanges();
                }
                catch (Exception e) { }
            }
        }

        public static void editDB(LineaComidaModel modelo)
        {
            try
            {
                using (DB_EfoodEntities db = new DB_EfoodEntities())
                {
                    var datos = (from valor in db.FoodOptions
                                 where valor.FoodOptionCode == modelo.FoodOptionCode
                                 select valor).SingleOrDefault();

                    datos.FoodOptionDescription = modelo.FoodOptionDescription;
                    db.SaveChanges();
                }

            }
            catch (Exception x) { }
        }

        public static List<LineaComidaModel> ObtenerLineasComida()
        {
            try
            {
                using (DB_EfoodEntities db = new DB_EfoodEntities())
                {
                    return (from valor in db.FoodOptions
                            select new LineaComidaModel
                            {
                                FoodOptionCode = valor.FoodOptionCode,
                                FoodOptionDescription = valor.FoodOptionDescription,
                            }).ToList();
                }

            }
            catch (Exception x) { return null; }
        }

        public static void deletetDB(LineaComidaModel modelo)
        {
            try
            {
                using (DB_EfoodEntities db = new DB_EfoodEntities())
                {
                    var datos = (from valor in db.FoodOptions
                                 where valor.FoodOptionCode == modelo.FoodOptionCode
                                 select valor).SingleOrDefault();

                    db.FoodOptions.Remove(datos);
                    db.SaveChanges();
                }

            }
            catch (Exception x) { }
        }

    }
}