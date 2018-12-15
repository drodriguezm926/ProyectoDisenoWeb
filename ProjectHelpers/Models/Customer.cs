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
        public string ConfirmaContrasena { get; set; }
        public string FacebookID { get; set; }
        public string TwitterID { get; set; }

        public static int ObtenerIdCustomer()
        {
            Customer customer = (Customer)System.Web.HttpContext.Current.Session["Usuario"];

            int id = customer.CustomerID;
            return id;
        }

        public static void AgregarCustomer(Customer newCustomer)
        {
            using (efooddatabaseEntities db = new efooddatabaseEntities())
            {
                try
                {   //Entidades de la base de datos
                    ProjectHelpers.AppData.Customer customer = new ProjectHelpers.AppData.Customer
                    {
                        CustomerID = newCustomer.CustomerID,
                        CustomerName = newCustomer.CustomerName,
                        CustomerLastname = newCustomer.CustomerLastname,
                        Telephone = newCustomer.Telephone,
                        Address = "No indica",
                        Email = newCustomer.Email,
                        ContrasenaEmail = newCustomer.ContrasenaEmail
                    };
                    db.Customers.Add(customer);
                    db.SaveChanges();

                    Payment payment = new Payment
                    {
                        CartID = newCustomer.CustomerID,
                        Quantity = 0,
                        Total = 0,
                        Description = "Carrito de " + newCustomer.CustomerName
                    };
                    db.Payments.Add(payment);
                    db.SaveChanges();
                }
                catch (Exception e) { ErrorLogModel.AddError(e); }
            }
        }

        public static bool ExisteCustomer(Customer modelo)
        {
            using (efooddatabaseEntities db = new efooddatabaseEntities())
            {
                var log = (from valor in db.Customers
                           where valor.Email == modelo.Email
                           select valor).SingleOrDefault();
                if (log != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

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
                            ContrasenaEmail = password,
                            CustomerID = customer.CustomerID,
                            CustomerName = customer.CustomerName,
                            CustomerLastname = customer.CustomerLastname
                        }).ToList();

            }
        }


    }
}
