using EFOOD.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFOOD.Models
{
    public class ConsecutivoModel
    {
        public int ConsecutiveCode { get; set; }
        public string Description { get; set; }
        public string CurrentConsecutive { get; set; }
        public bool HasPrefix { get; set; }
        public string Prefix { get; set; }

        public static void addDB(ConsecutivoModel consecutivoM)
        {
            using (DB_EfoodEntities db = new DB_EfoodEntities())
            {
                try
                {
                    //Toda la data de la base de datos, se almacena en la lista numeroConsecutivo
                    var numeroConsecutivo = (from valor in db.Consecutives
                                             select valor);

                    //Primary key
                    int code = numeroConsecutivo.Count() + 1;

                    //Tabla base de datos
                    Consecutive consecutive = new Consecutive();

                    //Dando valor al objeto
                    consecutive.ConsecutiveCode = code;
                    consecutive.Description = consecutivoM.Description;
                    consecutive.CurrentConsecutive = consecutivoM.CurrentConsecutive;
                    consecutive.HasPrefix = consecutivoM.HasPrefix;
                    consecutive.Prefix = consecutivoM.Prefix;

                    //Se agrega el objeto a la base de datos
                    db.Consecutives.Add(consecutive);
                    //Commit a la base de datos
                    db.SaveChanges();
                }
                catch (Exception e) { }
            }
        }

        public static string getConsecutivo(string descripcionConsecutivo) {
                    //Instancia base datos
                    DB_EfoodEntities db = new DB_EfoodEntities();
                    //Se consulta el currentConsecutive
                    var data = (from valor in db.Consecutives
                                 where valor.Description == descripcionConsecutivo
                                select valor).SingleOrDefault();
                    //Se cambia de formato
                    int n = int.Parse(data.CurrentConsecutive);
                    //Consecutivo
                    string resultado = data.Prefix + n;
                    //--Aumenta consecutivo en la base de datos--//
                    data.CurrentConsecutive = "" + (n+1);
                    //Actualiza
                    db.SaveChanges();
            return resultado;
        } 

        /*
        public static List<Territorio> ObtenerLineasComida()
        {
            try
            {
                using (vuelosEntities vuelosDB = new vuelosEntities())
                {
                    return (from territorio in vuelosDB.Pais
                            select new Territorio
                            {
                                codPais = territorio.codPais,
                                nombre_pais = territorio.nombre_pais,
                                rutaImagen = territorio.rutaImagen

                            }).ToList();
                }

            }
            catch (Exception x) { return null; }
        }*/
    }

}