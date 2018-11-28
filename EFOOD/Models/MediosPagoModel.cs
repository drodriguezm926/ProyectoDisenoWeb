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

        public static void AddDB(MediosPagoModel modelo)
        {
            using (DB_EfoodEntitie db = new DB_EfoodEntitie())
            {
                try
                {   //Entidades de la base de datos
                    PaymentProcessor newProcessor = new PaymentProcessor
                    {
                        PaymentProcessorCode = ConsecutivoModel.GetConsecutivo("Medios de pago"),
                        PaymentProcessorName = modelo.PaymentProcessorName,
                        PaymentProcessorDescription = modelo.PaymentProcessorDescription,
                        PaymentProcessorType = modelo.PaymentProcessorType,
                        PaymentProcessorMethod = modelo.PaymentProcessorMethod,
                        PaymentProcessorStatus = false,
                        PaymentProcessorVerify = false
                    };
                    db.PaymentProcessors.Add(newProcessor);
                    db.SaveChanges();
                }
                catch (Exception e) { ErrorLogModel.AddError(e); }
            }
        }

        public static void EditDB(MediosPagoModel modelo)
         {
             try
             {
                 using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                 {
                     var datos = (from valor in db.PaymentProcessors
                                  where valor.PaymentProcessorCode == modelo.PaymentProcessorCode
                                  select valor).SingleOrDefault();
                    
                    datos.PaymentProcessorName = modelo.PaymentProcessorName;
                    datos.PaymentProcessorDescription = modelo.PaymentProcessorDescription;
                    datos.PaymentProcessorType = modelo.PaymentProcessorType;
                    datos.PaymentProcessorMethod = modelo.PaymentProcessorMethod;
                    datos.PaymentProcessorStatus = false;
                    datos.PaymentProcessorVerify = false;
                    db.SaveChanges();
                 }

             }
             catch (Exception x) { ErrorLogModel.AddError(x); }
         }

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
            catch (Exception x) { ErrorLogModel.AddError(x); return null; }
        }

        public static void DeletetDB(MediosPagoModel modelo)
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                    var datos = (from valor in db.PaymentProcessors
                                 where valor.PaymentProcessorCode == modelo.PaymentProcessorCode
                                 select valor).SingleOrDefault();

                    db.PaymentProcessors.Remove(datos);
                    db.SaveChanges();
                }

            }
            catch (Exception x) { ErrorLogModel.AddError(x); }
        }
    }
}