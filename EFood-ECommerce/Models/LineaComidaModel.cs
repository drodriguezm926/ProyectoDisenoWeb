using EFood_ECommerce.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFOOD.Models
{
    public class LineaComidaModel
    {
        public string FoodOptionCode { get; set; }
        public string FoodOptionDescription { get; set; }

        public static List<LineaComidaModel> ObtenerLineasComida()
        {
            try
            {
                using (Entities db = new Entities())
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

    }
}