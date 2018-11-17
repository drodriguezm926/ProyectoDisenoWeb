using EFOOD.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFOOD.Models
{
    public class Admin
    {

        public int UserID { get; set; }
        public string Username { get; set; }
        public bool Status { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswerHash { get; set; }
        public Nullable<int> RoleID { get; set; }

        public static List<Admin> ObtenerAdmin()
        {
            using (DB_EfoodEntitie db = new DB_EfoodEntitie())
            {
                return (from user in db.Users
                        select new Admin
                        {
                            UserID = user.UserID,
                            Username = user.Username,
                            Status = user.Status,
                            PasswordHash = user.PasswordHash,
                            Email = user.Email,
                            SecurityQuestion = user.SecurityQuestion,
                            SecurityAnswerHash = user.SecurityAnswerHash,
                            RoleID = user.RoleID

                        }).ToList();
            }
        }

        public static User obtenerUsuarioUnico(int modelo)
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                    var datos = (from valor in db.Users
                                 where valor.UserID == modelo
                                 select valor).SingleOrDefault();

                    return datos;
                }

            }
            catch (Exception x)
            {
                return null;
            }
        }

        public static List<Admin> LoginUsuario(string usuario, string password)
        {
            using (DB_EfoodEntitie db = new DB_EfoodEntitie())
            {
                return (from user in
                                    db.Users.Where(
                                        o => o.PasswordHash.Equals(password) &&
                                              o.Username.ToLower().Equals(usuario.ToLower()))
                        select new Admin
                        {
                            UserID = user.UserID,
                            Username = user.Username,
                            Status = user.Status,
                            PasswordHash = user.PasswordHash,
                            Email = user.Email,
                            SecurityQuestion = user.SecurityQuestion,
                            SecurityAnswerHash = user.SecurityAnswerHash,
                            RoleID = user.RoleID

                        }).ToList();

            }
        }

        public static bool CambiarContrasena(string contrasenaAnterior, string nuevaContrasena)
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                    var usuario = (from user in
                                        db.Users.Where(
                                            o => o.PasswordHash.Equals(contrasenaAnterior))
                                       select user).First();

                    usuario.PasswordHash = nuevaContrasena;
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool AsignarRol(int idUsuario, int idRol)
        {
            try

            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                    var usuario = (from user in
                                        db.Users.Where(
                                            o => o.UserID.Equals(idUsuario))
                                       select user).First();
                    usuario.RoleID = idRol;
                    db.SaveChanges();
                    
                    return true;
                }


            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        public static int obtenerIdUsuario() {
            EFOOD.Models.Admin usuarios =
                    (EFOOD.Models.Admin)System.Web.HttpContext.Current.Session["Usuario"];

            int ff = usuarios.UserID;
            return ff;
        }

        public static void InsertarUsuario(Admin admin)
        {
            try
            {
                using (DB_EfoodEntitie db = new DB_EfoodEntitie())
                {
                    User user = new User();

                    user.UserID = admin.UserID;
                    user.Username = admin.Username;
                    user.Status = true;
                    user.PasswordHash = admin.PasswordHash;
                    user.Email = admin.Email;
                    user.SecurityQuestion = admin.SecurityQuestion;
                    user.SecurityAnswerHash = admin.SecurityAnswerHash;
                    user.RoleID = 1;

                    db.Users.Add(user);
                    db.SaveChanges();
                    
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}