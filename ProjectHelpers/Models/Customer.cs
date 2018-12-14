using ProjectHelpers.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHelpers.Models
{
    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastname { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string TicketCode { get; set; }
        public Nullable<int> RoleID { get; set; }

        /*public static List<Customer> LoginUsuario(string usuario, string password)
        {
            using (efooddatabaseEntities db = new efooddatabaseEntities())
            {
                var log = from user in
                                    db.Users.Where(
                                        o => o.PasswordHash.Equals(password) &&
                                              o.Username.ToLower().Equals(usuario.ToLower()))
                          select new Customer
                          {
                              CustomerID = user.UserID,
                              CustomerName = user.Username,
                              CustomerLastname = user.Status,
                              PasswordHash = user.PasswordHash,
                              Email = user.Email,
                              SecurityQuestion = user.SecurityQuestion,
                              SecurityAnswerHash = user.SecurityAnswerHash,
                              RoleID = user.RoleID

                          };

                return log.ToList();

            }
        }*/

    }
}
