using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetSharp;

namespace EFood_ECommerce.Controllers
{
    public class TwitterController : Controller
    {
        private string _consumerKey = "7rJJpdlyF92nE2cxysRX3DFj2";
        private string _consumerSecret = "KlbZ2GFAaLKuIpi951tpJjcm3rdJ6hkTYe8NGEcI1r1mg4LI74";

        public ActionResult Authorize()
        {
            // Step 1 - Retrieve an OAuth Request Token
            TwitterService service = new TwitterService(_consumerKey, _consumerSecret);

            // This is the registered callback URL
            OAuthRequestToken requestToken = service.GetRequestToken("https://localhost:44336/Twitter/AuthorizeCallback");

            // Step 2 - Redirect to the OAuth Authorization URL
            Uri uri = service.GetAuthorizationUri(requestToken);
            return new RedirectResult(uri.ToString(), false /*permanent*/);
        }

        // This URL is registered as the application's callback at http://dev.twitter.com
        public ActionResult AuthorizeCallback(string oauth_token, string oauth_verifier)
        {
            var requestToken = new OAuthRequestToken { Token = oauth_token };

            try
            {
                // Step 3 - Exchange the Request Token for an Access Token
                TwitterService service = new TwitterService(_consumerKey, _consumerSecret);

                OAuthAccessToken accessToken = service.GetAccessToken(requestToken, oauth_verifier);

                VerifyCredentialsOptions option = new VerifyCredentialsOptions();
                // Step 4 - User authenticates using the Access Token
                service.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);
                TwitterUser user = service.VerifyCredentials(option);





                string[] splited = user.Name.Split(' ');
                string name = splited[0];
                string lastName = splited[1];

                string email = string.Empty;
                if (user.Email == null)
                {
                    email = user.ScreenName;
                }
                else
                {
                    email = user.Email;
                }

                //Se valida si el usuario de Facebook existe, en caso de que no se registra, en caso contrario se agrega a cuenta de correo actual
                Consumidor consumidor = new Consumidor();
                consumidor.ValidarUsuarioTwitter(email, user.Id.ToString(), name, lastName, "");

                //Se agrega los datos del usuario al objeto
                consumidor.codTwitter = user.Id.ToString();
                consumidor.correo = user.Email;
                consumidor.nombre = name;
                consumidor.primerApellido = lastName;
                consumidor.segundoApellido = "";
                consumidor.ProfileURL = user.ProfileImageUrl;

                //Se guarda en sesion datos el usuario
                Session["twitter"] = consumidor;
                return RedirectToAction("Busqueda", "Vuelo");
            }
            catch (Exception e)
            {
                throw;
            }


        }
    }
}