using ProjectHelpers.AppData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
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
            using (efooddatabaseEntities db = new efooddatabaseEntities())
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
                    BitacoraModel.AddLogBook("a", "Anadir", Admin.ObtenerIdUsuario());
                }
                catch (Exception e) { ErrorLogModel.AddError(e); }
            }
        }

        public static void EditDB(MediosPagoModel modelo)
         {
             try
             {
                 using (efooddatabaseEntities db = new efooddatabaseEntities())
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
                    BitacoraModel.AddLogBook("e", "Edicion", Admin.ObtenerIdUsuario());
                }

             }
             catch (Exception x) { ErrorLogModel.AddError(x); }
         }

        public static List<MediosPagoModel> ObtenerMediosDePago()
        {
            try
            {
                using (efooddatabaseEntities db = new efooddatabaseEntities())
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
                using (efooddatabaseEntities db = new efooddatabaseEntities())
                {
                    var datos = (from valor in db.PaymentProcessors
                                 where valor.PaymentProcessorCode == modelo.PaymentProcessorCode
                                 select valor).SingleOrDefault();

                    db.PaymentProcessors.Remove(datos);
                    db.SaveChanges();
                    BitacoraModel.AddLogBook("n", "Borrar", Admin.ObtenerIdUsuario());
                }

            }
            catch (Exception x) { ErrorLogModel.AddError(x); }
        }
    }
}