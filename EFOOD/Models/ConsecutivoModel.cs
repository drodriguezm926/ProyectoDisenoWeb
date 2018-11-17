﻿using EFOOD.App_Data;
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
            using (DB_EfoodEntitie db = new DB_EfoodEntitie())
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
                catch (Exception e) { ErrorLogModel.addError(e); }
            }
        }

        public static string getConsecutivo(string descripcionConsecutivo) {
            try
            {
                //Instancia base datos
                DB_EfoodEntitie db = new DB_EfoodEntitie();
                //Se consulta el currentConsecutive
                var data = (from valor in db.Consecutives
                            where valor.Description == descripcionConsecutivo
                            select valor).SingleOrDefault();
                //Se cambia de formato
                int n = int.Parse(data.CurrentConsecutive);
                //Consecutivo
                string resultado = data.Prefix + n;
                //--Aumenta consecutivo en la base de datos--//
                data.CurrentConsecutive = "" + (n + 1);
                //Actualiza
                db.SaveChanges();
                return resultado;
            }
            catch (Exception e) { ErrorLogModel.addError(e); return null; }
        } 
        
        public static List<ConsecutivoModel> ObtenerConsecutivos()
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                    return (from consecutivo in db.Consecutives
                            select new ConsecutivoModel
                            {
                                ConsecutiveCode = consecutivo.ConsecutiveCode,
                                Description = consecutivo.Description,
                                CurrentConsecutive = consecutivo.CurrentConsecutive,
                                HasPrefix = consecutivo.HasPrefix,
                                Prefix = consecutivo.Prefix,

                            }).ToList();
                }

            }
            catch (Exception x) { return null; }
        }
    }

}