using ProjectHelpers.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastname { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string TicketCode { get; set; }
        public Nullable<int> RoleID { get; set; }
        public string ContrasenaEmail { get; set; }
        public string FacebookID { get; set; }
        public string TwitterID { get; set; }

        public static List<Customer> LoginCustomer(string email, string password)
        {
            using (efooddatabaseEntities db = new efooddatabaseEntities())
            {
                return (from customer in db.Customers
                        where customer.Email == email &&
                              customer.ContrasenaEmail == password
                                    
                        select new Customer
                        {
                            Email = customer.Email,
                            ContrasenaEmail = password
                        }).ToList();

            }
        }
    }
}
