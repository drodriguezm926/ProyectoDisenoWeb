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

        public static void AddDB(LineaComidaModel modelo)
        {
            using (DB_EfoodEntitie db = new DB_EfoodEntitie())
            {
                try
                {   //Entidades de la base de datos
                    FoodOption foodOption = new FoodOption
                    {
                        FoodOptionCode = ConsecutivoModel.GetConsecutivo("Líneas de comida"),
                        FoodOptionDescription = modelo.FoodOptionDescription
                    };
                    db.FoodOptions.Add(foodOption);
                    BitacoraModel.AddLogBook("a", "Anadir", Admin.ObtenerIdUsuario());
                    db.SaveChanges();
                }
                catch (Exception e) { ErrorLogModel.AddError(e);  }
            }
        }

        public static void EditDB(LineaComidaModel modelo)
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                    var datos = (from valor in db.FoodOptions
                                 where valor.FoodOptionCode == modelo.FoodOptionCode
                                 select valor).SingleOrDefault();

                    datos.FoodOptionDescription = modelo.FoodOptionDescription;
                    BitacoraModel.AddLogBook("e", "Edicion", Admin.ObtenerIdUsuario());
                    db.SaveChanges();
                }

            }
            catch (Exception x) { ErrorLogModel.AddError(x);  }
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
            catch (Exception x) { ErrorLogModel.AddError(x); return null; }
        }

        public static void DeletetDB(LineaComidaModel modelo)
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                    var datos = (from valor in db.FoodOptions
                                 where valor.FoodOptionCode == modelo.FoodOptionCode
                                 select valor).SingleOrDefault();

                    db.FoodOptions.Remove(datos);
                    BitacoraModel.AddLogBook("n", "Borrar", Admin.ObtenerIdUsuario());
                    db.SaveChanges();
                }

            }
            catch (Exception x) { ErrorLogModel.AddError(x);  }
        }

    }
}