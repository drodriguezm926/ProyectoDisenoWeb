using EFOOD.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFOOD.Models
{
    public class MediosPagoModel
    {
        public string PaymentProcessorCode { get; set; }
        public string PaymentProcessorName { get; set; }
        public string PaymentProcessorDescription { get; set; }
        public string PaymentProcessorType { get; set; }
        public bool PaymentProcessorStatus { get; set; }
        public bool PaymentProcessorVerify { get; set; }
        public string PaymentProcessorMethod { get; set; }

        public static void addDB(MediosPagoModel modelo)
        {
            using (DB_EfoodEntitie db = new DB_EfoodEntitie())
            {
                try
                {   //Entidades de la base de datos
                    PaymentProcessor newProcessor = new PaymentProcessor();
                    newProcessor.PaymentProcessorCode = ConsecutivoModel.getConsecutivo("Medios de pago");
                    newProcessor.PaymentProcessorName = modelo.PaymentProcessorName;
                    newProcessor.PaymentProcessorDescription = modelo.PaymentProcessorDescription;
                    newProcessor.PaymentProcessorType = modelo.PaymentProcessorType;
                    newProcessor.PaymentProcessorMethod = modelo.PaymentProcessorMethod;
                    newProcessor.PaymentProcessorStatus = false;
                    newProcessor.PaymentProcessorVerify = false;
                    db.PaymentProcessors.Add(newProcessor);
                    BitacoraModel.addLogBook("a", "Anadir", Admin.obtenerIdUsuario());
                    db.SaveChanges();
                }
                catch (Exception e) { ErrorLogModel.addError(e);  }
            }
        }

        /* public static void editDB(TipoPrecioModelo modelo)
         {
             try
             {
                 using (DB_EfoodEntitie vuelosDB = new DB_EfoodEntitie())
                 {
                     var datos = (from valor in vuelosDB.PriceTypes
                                  where valor.PriceTypeCode == modelo.PriceTypeCode
                                  select valor).SingleOrDefault();

                     datos.PriceTypeDescription = modelo.PriceTypeDescription;
                     vuelosDB.SaveChanges();
                 }

             }
             catch (Exception x) { ErrorLogModel.addError(x); BitacoraModel.addLogBook("e", "Edicion", Admin.obtenerIdUsuario());}
         }*/

        public static List<MediosPagoModel> ObtenerMediosDePago()
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                    return (from metodoDePago in db.PaymentProcessors
                            select new MediosPagoModel
                            {
                                PaymentProcessorCode = metodoDePago.PaymentProcessorCode,
                                PaymentProcessorName = metodoDePago.PaymentProcessorName,
                                PaymentProcessorDescription = metodoDePago.PaymentProcessorDescription,
                                PaymentProcessorType = metodoDePago.PaymentProcessorType,
                                PaymentProcessorMethod = metodoDePago.PaymentProcessorMethod,
                                PaymentProcessorStatus = false,
                                PaymentProcessorVerify = false,
                            }).ToList();
                }

            }
            catch (Exception x) { ErrorLogModel.addError(x); return null; }
        }

        /*public static void deletetDB(TipoPrecioModelo modelo)
        {
            try
            {
                using (DB_EfoodEntitie vuelosDB = new DB_EfoodEntitie())
                {
                    var datos = (from valor in vuelosDB.PriceTypes
                                 where valor.PriceTypeCode == modelo.PriceTypeCode
                                 select valor).SingleOrDefault();

                    vuelosDB.PriceTypes.Remove(datos);
                    vuelosDB.SaveChanges();
                }

            }
            catch (Exception x) { ErrorLogModel.addError(x); BitacoraModel.addLogBook("n", "Borrar", Admin.obtenerIdUsuario());}
        }*/
    }
}