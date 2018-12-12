using ProjectHelpers.AppData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class BitacoraModel
    {
        public int LogID { get; set; }
        public int UserID { get; set; }
        public System.DateTime LogDate { get; set; }
        public string RegCode { get; set; }
        public string LogType { get; set; }
        public string Description { get; set; }
        public string RegDetails { get; set; }
        [Display(Name = "Fecha inicial: ")]
        [Required(ErrorMessage = "Seleccione una fecha inicial.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Fecha final: ")]
        [Required(ErrorMessage = "Seleccione una fecha limite.")]
        public DateTime EndDate { get; set; }


        public virtual User User { get; set; }

        public static void AddLogBook(string tipo, string description, int userID)
        {

            using (efooddatabaseEntities db = new efooddatabaseEntities())
            {
                //try
                //{   //Entidades de la base de datos
                    LogBook log = new LogBook();

                    //Toda la data de la base de datos, se almacena en la lista numeroConsecutivo
                    var numeroConsecutivo = (from valor in db.LogBooks
                                             select valor);

                    //Primary key
                    int code = numeroConsecutivo.Count() + 1;

                    log.LogID = code;
                    log.UserID = userID;
                    log.LogDate = DateTime.Now;
                    log.RegCode = ConsecutivoModel.GetConsecutivo("Bitacoras");
                    log.LogType = tipo;
                    log.Description = description;
                    log.RegDetails = "N/A";
                    log.User = Admin.ObtenerUsuarioUnico(userID);
                    db.LogBooks.Add(log);
                    db.SaveChanges();
                //}
                //catch (Exception e) { ErrorLogModel.addError(e); }
            }
        }

        public static List<BitacoraModel> FiltrarBitacora(BitacoraModel modelo)
        {
            try
            {
                using (efooddatabaseEntities db = new efooddatabaseEntities())
                {
                    var logs = from valor in db.LogBooks

                               select new BitacoraModel
                               {
                                   LogID = valor.LogID,
                                   UserID = valor.UserID,
                                   LogDate = valor.LogDate,
                                   RegCode = valor.RegCode,
                                   LogType = valor.LogType,
                                   Description = valor.Description,
                                   RegDetails = valor.RegDetails
                               };

                    if (modelo.EndDate != DateTime.Parse("01/01/0001 12:00:00 a. m."))
                    {
                        logs = logs.Where(valor => valor.LogDate <= modelo.EndDate);
                    }

                    if (modelo.StartDate != DateTime.Parse("01/01/0001 12:00:00 a. m."))
                    {
                        logs = logs.Where(valor => valor.LogDate >= modelo.StartDate);
                    }

                    if (modelo.UserID != 0)
                    {
                        logs = logs.Where(valor => valor.UserID == modelo.UserID);
                    }

                    if (modelo.LogType != null)
                    {
                        logs = logs.Where(valor => valor.LogType == modelo.LogType);
                    }

                    return logs.ToList();

                    /*return (from valor in db.LogBooks
                            where valor.LogDate >= modelo.StartDate &&
                            valor.LogDate <= modelo.EndDate &&
                            valor.LogType == modelo.LogType &&
                            valor.UserID == modelo.UserID

                            select new BitacoraModel
                            {
                                LogID = valor.LogID,
                                UserID = valor.UserID,
                                LogDate = valor.LogDate,
                                RegCode = valor.RegCode,
                                LogType = valor.LogType,
                                Description = valor.Description,
                                RegDetails = valor.RegDetails

                            }).ToList();*/
                }

            }
            catch (Exception x) {
                ErrorLogModel.AddError(x); return null; }
        }

        public static List<BitacoraModel> CargarErrores()
        {
            try
            {
                using (efooddatabaseEntities db = new efooddatabaseEntities())
                {

                    return (from valor in db.LogBooks
                            select new BitacoraModel
                            {
                                LogID = valor.LogID,
                                UserID = valor.UserID,
                                LogDate = valor.LogDate,
                                RegCode = valor.RegCode,
                                LogType = valor.LogType,
                                Description = valor.Description,
                                RegDetails = valor.RegDetails
                            }).ToList();

                }
                
            }
            catch (Exception x) { ErrorLogModel.AddError(x); return null; }
        }


    }
}