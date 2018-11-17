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
            using (DB_EfoodEntitie db = new DB_EfoodEntitie())
            {
                try
                {   //Entidades de la base de datos
                    FoodOption foodOption = new FoodOption();
                    foodOption.FoodOptionCode = ConsecutivoModel.getConsecutivo("Líneas de comida");
                    foodOption.FoodOptionDescription = modelo.FoodOptionDescription;
                    db.FoodOptions.Add(foodOption);
                    BitacoraModel.addLogBook("a", "Anadir", Admin.obtenerIdUsuario());
                    db.SaveChanges();
                }
                catch (Exception e) { ErrorLogModel.addError(e);  }
            }
        }

        public static void editDB(LineaComidaModel modelo)
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                    var datos = (from valor in db.FoodOptions
                                 where valor.FoodOptionCode == modelo.FoodOptionCode
                                 select valor).SingleOrDefault();

                    datos.FoodOptionDescription = modelo.FoodOptionDescription;
                    BitacoraModel.addLogBook("e", "Edicion", Admin.obtenerIdUsuario());
                    db.SaveChanges();
                }

            }
            catch (Exception x) { ErrorLogModel.addError(x);  }
        }

        public static List<LineaComidaModel> ObtenerLineasComida()
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                    return (from valor in db.FoodOptions
                            select new LineaComidaModel
                            {
                                FoodOptionCode = valor.FoodOptionCode,
                                FoodOptionDescription = valor.FoodOptionDescription,
                            }).ToList();
                }

            }
            catch (Exception x) { ErrorLogModel.addError(x); return null; }
        }

        public static void deletetDB(LineaComidaModel modelo)
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                    var datos = (from valor in db.FoodOptions
                                 where valor.FoodOptionCode == modelo.FoodOptionCode
                                 select valor).SingleOrDefault();

                    db.FoodOptions.Remove(datos);
                    BitacoraModel.addLogBook("n", "Borrar", Admin.obtenerIdUsuario());
                    db.SaveChanges();
                }

            }
            catch (Exception x) { ErrorLogModel.addError(x);  }
        }

    }
}