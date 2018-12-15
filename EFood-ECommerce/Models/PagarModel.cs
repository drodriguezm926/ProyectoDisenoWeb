using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Net.Http.Formatting;

namespace EFood_ECommerce.Models
{
    public class PagarModel
    {
        public int codTarjeta { get; set; }
        public string portador { get; set; }
        public string numeroTarjeta { get; set; }
        public string tipoTarjeta { get; set; }
        public string marcaTarjeta { get; set; }
        public System.DateTime fechaExpiracion { get; set; }
        public string cvv { get; set; }
        public Nullable<decimal> saldo_disponible { get; set; }
        public Nullable<decimal> limite_credito { get; set; }
        public string codUsuario { get; set; }

        public static string actualizarMontoPut(PagarModel tarjeta, string mensaje)
        {
            //Se conecta a WS
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:50747/");

            var request = clienteHttp.PutAsync("api/Tarjetas/5", tarjeta, new JsonMediaTypeFormatter()).Result;
            var resultado = request.Content.ReadAsStringAsync().Result;

            if (request.IsSuccessStatusCode)
            {

                return "OK";
            }
            else
            {
                mensaje = resultado.ToString();
                return mensaje;
            }
        }
    }
}