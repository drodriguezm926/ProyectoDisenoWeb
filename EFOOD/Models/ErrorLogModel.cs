using EFOOD.App_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFOOD.Models
{
    public class ErrorLogModel
    {

        #region variables
        public int LogID { get; set; }
        public System.DateTime LogDate { get; set; }
        public string ErrCode { get; set; }
        public string Description { get; set; }

        [Display(Name = "Fecha inicial: ")]
        [Required(ErrorMessage = "Seleccione una fecha inicial.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Fecha final: ")]
        [Required(ErrorMessage = "Seleccione una fecha limite.")]
        public DateTime EndDate { get; set; }

        #endregion

        public static void addError(Exception x) {

            using (DB_EfoodEntitie db = new DB_EfoodEntitie())
            {
                try
                {   //Entidades de la base de datos
                    ErrorLog error = new ErrorLog();

                    //Toda la data de la base de datos, se almacena en la lista numeroConsecutivo
                    var numeroConsecutivo = (from valor in db.ErrorLogs
                                             select valor);

                    //Primary key
                    int code = numeroConsecutivo.Count() + 1;

                    error.LogID = code;
                    error.LogDate = DateTime.Now;
                    error.ErrCode = x.HResult.ToString();
                    error.Description = x.Message;
                    db.ErrorLogs.Add(error);
                    db.SaveChanges(); 
                }
                catch (Exception e) { }
            }
        }

        public static List<ErrorLogModel> FiltrarErrores(ErrorLogModel modelo)
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                        return (from valor in db.ErrorLogs
                                where valor.LogDate >= modelo.StartDate &&
                                valor.LogDate <= modelo.EndDate
                                select new ErrorLogModel
                                {
                                    LogID = valor.LogID,
                                    LogDate = valor.LogDate,
                                    ErrCode = valor.ErrCode,
                                    Description = valor.Description
                                }).ToList();
           
                }

            }
            catch (Exception x) { ErrorLogModel.addError(x); return null; }
        }

        public static List<ErrorLogModel> cargarErrores()
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                    
                        return (from valor in db.ErrorLogs
                                select new ErrorLogModel
                                {
                                    LogID = valor.LogID,
                                    LogDate = valor.LogDate,
                                    ErrCode = valor.ErrCode,
                                    Description = valor.Description
                                }).ToList();
                    
                }

            }
            catch (Exception x) { ErrorLogModel.addError(x); return null; }
        }
    }
}