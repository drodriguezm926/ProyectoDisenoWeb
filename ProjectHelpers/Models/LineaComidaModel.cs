using ProjectHelpers.AppData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class LineaComidaModel
    {
        public string FoodOptionCode { get; set; }
        public string FoodOptionDescription { get; set; }

        public static void AddDB(LineaComidaModel modelo)
        {
            using (efooddatabaseEntities db = new efooddatabaseEntities())
            {
                try
                {   //Entidades de la base de datos
                    FoodOption foodOption = new FoodOption
                    {
                        FoodOptionCode = ConsecutivoModel.GetConsecutivo("Líneas de comida"),
                        FoodOptionDescription = modelo.FoodOptionDescription
                    };
                    db.FoodOptions.Add(foodOption);
                    db.SaveChanges();
                    BitacoraModel.AddLogBook("a", "Anadir", Admin.ObtenerIdUsuario());
                }
                catch (Exception e) { ErrorLogModel.AddError(e);  }
            }
        }

        public static void EditDB(LineaComidaModel modelo)
        {
            try
            {
                using (efooddatabaseEntities db = new efooddatabaseEntities())
                {
                    var datos = (from valor in db.FoodOptions
                                 where valor.FoodOptionCode == modelo.FoodOptionCode
                                 select valor).SingleOrDefault();

                    datos.FoodOptionDescription = modelo.FoodOptionDescription;
                    db.SaveChanges();
                    BitacoraModel.AddLogBook("e", "Edicion", Admin.ObtenerIdUsuario());
                }

            }
            catch (Exception x) { ErrorLogModel.AddError(x);  }
        }

        public static List<LineaComidaModel> ObtenerLineasComida()
        {
            try
            {
                using (efooddatabaseEntities db = new efooddatabaseEntities())
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
                using (efooddatabaseEntities db = new efooddatabaseEntities())
                {
                    var datos = (from valor in db.FoodOptions
                                 where valor.FoodOptionCode == modelo.FoodOptionCode
                                 select valor).SingleOrDefault();

                    db.FoodOptions.Remove(datos);
                    db.SaveChanges();
                    BitacoraModel.AddLogBook("n", "Borrar", Admin.ObtenerIdUsuario());
                }

            }
            catch (Exception x) { ErrorLogModel.AddError(x);  }
        }

    }
}