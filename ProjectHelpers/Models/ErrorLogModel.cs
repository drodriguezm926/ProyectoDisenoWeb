using ProjectHelpers.AppData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Models
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

        public static void AddError(Exception x)
        {
            using (efooddatabaseEntities db = new efooddatabaseEntities())
            {
                try
                {   //Entidades de la base de datos
                    ErrorLog error = new ErrorLog();

                    //Toda la data de la base de datos, se almacena en la lista de errores
                    var errores = (from valor in db.ErrorLogs
                                             select valor);

                    //Primary key
                    int code = errores.Count() + 1;

                    error.LogID = code;
                    error.LogDate = DateTime.Now;
                    error.ErrCode = x.HResult.ToString();
                    error.Description = "Ha ocurrido un error. Mensaje: "+x.Message + ". StackTrace: " + x.StackTrace + 
                        ". InnerException: "+ (x.InnerException != null ? x.InnerException.Message : "");
                    db.ErrorLogs.Add(error);
                    db.SaveChanges(); 
                }
                catch (Exception ex)
                {
                    string error = "Ha ocurrido un error. Detalles: " + ex.Message;
                    AddError(ex);
                }
            }
        }

        public static List<ErrorLogModel> FiltrarErrores(ErrorLogModel modelo)
        {
            try
            {
                using (efooddatabaseEntities db = new efooddatabaseEntities())
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
            catch (Exception x) { ErrorLogModel.AddError(x); return null; }
        }

        public static List<ErrorLogModel> CargarErrores()
        {
            try
            {
                using (efooddatabaseEntities db = new efooddatabaseEntities())
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
            catch (Exception x) { ErrorLogModel.AddError(x); return null; }
        }
    }
}