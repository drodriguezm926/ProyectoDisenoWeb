using Facebook;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFood_ECommerce.Controllers
{
    public class FacebookController : Controller
    {
        //private const string FacebookAppID = "2212305545708654";
        //private const string FacebookAppSecret = "5a35c224b314ead674be0ba1c1bae54f";

        private const string FacebookAppID = "515218262288295";
        private const string FacebookAppSecret = "b68a6fbce062f71e49980f5cf8c5f2ac";

        #region Facebook Authentication

        private Uri RediredtUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url)
                {
                    Query = null,
                    Fragment = null,
                    Path = Url.Action("FacebookCallback")
                };
                return uriBuilder.Uri;
            }
        }

        [AllowAnonymous]
        public ActionResult Facebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = FacebookAppID,
                client_secret = FacebookAppSecret,
                redirect_uri = RediredtUri.AbsoluteUri,
                response_type = "code",
                scope = "email"
            });
            return Redirect(loginUrl.AbsoluteUri);
        }


        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = FacebookAppID,
                client_secret = FacebookAppSecret,
                redirect_uri = RediredtUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;

            Session["AccessToken"] = accessToken;

            fb.AccessToken = accessToken;

            dynamic me = fb.Get("me?fields=link,id,first_name,currency,last_name,email,gender,locale,timezone,verified,picture,age_range");

            string email = me.email;

            //Se valida si el usuario de Facebook existe, en caso de que no se registra, en caso contrario se agrega a cuenta de correo actual
            CustomerModel consumidor = new CustomerModel();
            consumidor.ValidarUsuarioFacebook(email, me.id, me.first_name, me.last_name, "");

            //Se agrega los datos del usuario al objeto
            consumidor.FacebookID = me.id;
            consumidor.Email = me.email;
            consumidor.CustomerName = me.first_name;
            consumidor.CustomerLastname = me.last_name;
            consumidor.Telephone = "";
            consumidor.Address = "";
            consumidor.ContrasenaEmail = "";
            

            //Se guarda en sesion datos el usuario
            Session["facebook"] = consumidor;

            return RedirectToAction("Inicio", "Inicio");
        }

        #endregion

    }
}