using EFOOD.App_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFOOD.Models
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

        public static void addLogBook(string tipo, string description, int userID)
        {

            using (DB_EfoodEntitie db = new DB_EfoodEntitie())
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
                    log.RegCode = ConsecutivoModel.getConsecutivo("Bitacoras");
                    log.LogType = "n";
                    log.Description = description;
                    log.RegDetails = "N/A";
                    log.User = Admin.obtenerUsuarioUnico(userID);
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
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {

                    return (from valor in db.LogBooks
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

                            }).ToList();
                }

            }
            catch (Exception x) { ErrorLogModel.addError(x); return null; }
        }

        public static List<BitacoraModel> cargarErrores()
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
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
            catch (Exception x) { ErrorLogModel.addError(x); return null; }
        }


    }
}