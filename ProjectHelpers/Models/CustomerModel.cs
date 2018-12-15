﻿using ProjectHelpers.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CustomerModel
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

        public static int ObtenerIdCustomer()
        {
            CustomerModel customer = (CustomerModel)System.Web.HttpContext.Current.Session["Usuario"];

            int id = customer.CustomerID;
            return id;
        }

        private string Encriptar(string cadena)
        {
            byte[] encriptar = new UnicodeEncoding().GetBytes(cadena);
            string resultado = Convert.ToBase64String(encriptar);
            return resultado;
        }

        private string Desencriptar(string cadena)
        {
            byte[] desencriptar = Convert.FromBase64String(cadena);
            string resultado = new UnicodeEncoding().GetString(desencriptar);
            return resultado;
        }

        public static List<CustomerModel> LoginCustomer(string email, string password)
        {
            using (efooddatabaseEntities db = new efooddatabaseEntities())
            {
                return (from customer in db.Customers
                        where customer.Email == email &&
                              customer.ContrasenaEmail == password
                                    
                        select new CustomerModel
                        {
                            Email = customer.Email,
                            ContrasenaEmail = password,
                            CustomerID = customer.CustomerID
                        }).ToList();

            }
        }

        private List<CustomerModel> GetConsumidores()
        {
            List<CustomerModel> consumidores = new List<CustomerModel>();
            using (efooddatabaseEntities vuelosData = new efooddatabaseEntities())
            {
                consumidores = (from cliente in vuelosData.Customers
                                select new CustomerModel
                                {
                                    CustomerID = cliente.CustomerID,
                                    CustomerName = cliente.CustomerName,
                                    CustomerLastname = cliente.CustomerLastname,
                                    Telephone = cliente.Telephone,
                                    Address = cliente.Address, 
                                    Email = cliente.Email, 
                                    TicketCode = cliente.TicketCode, 
                                    RoleID = cliente.RoleID,
                                    ContrasenaEmail = cliente.ContrasenaEmail,
                                    FacebookID = cliente.FacebookID,
                                    TwitterID = cliente.TwitterID
    }).ToList();
            }

            return consumidores;
        }

        private void UpdateFacebook(string email, string codFacebook)
        {
            using (efooddatabaseEntities vuelosData = new efooddatabaseEntities())
            {
                var datos = (from valor in vuelosData.Customers
                             where valor.Email == email
                             select valor).SingleOrDefault();
                datos.FacebookID = codFacebook;
                vuelosData.SaveChanges();
            }
        }

        public void ValidarUsuarioFacebook(string email, string idFacebook, string nombre, string primerApellido, string segundoApellido)
        {
            List<CustomerModel> clientes = GetConsumidores();
            bool userExiste = false;
            foreach (var item in clientes)
            {
                if (item.Email == email)
                {
                    userExiste = true;
                    if (item.FacebookID== null)
                    {
                        UpdateFacebook(email, idFacebook);
                        break;
                    }
                }
            }

            if (!userExiste)
            {
                CustomerModel consumidor = new CustomerModel
                {
                    Email = email,
                    FacebookID = idFacebook,
                    CustomerName = nombre,
                    CustomerLastname = primerApellido,
                    };
                AddFacebookUser(consumidor);
            }
        }

        private int GetConsecutivo()
        {
            //Instancia base datos
            efooddatabaseEntities db = new efooddatabaseEntities();
            //Se consulta el currentConsecutive
            var data = (from valor in db.Customers
                        orderby valor.CustomerID descending
                        select valor.CustomerID);
            //Se cambia de formato
            int n = data.FirstOrDefault();
            n += 1;
            return n;
        }

        private void AddFacebookUser(CustomerModel consumidor)
        {
            using (efooddatabaseEntities vuelosData = new efooddatabaseEntities())
            {
                Customer cliente = new Customer();
                cliente.CustomerID = GetConsecutivo();
                cliente.Email = consumidor.Email;
                cliente.ContrasenaEmail = consumidor.ContrasenaEmail;
                cliente.CustomerName = consumidor.CustomerName;
                cliente.CustomerLastname = consumidor.CustomerLastname;
                cliente.FacebookID = consumidor.FacebookID;


                vuelosData.Customers.Add(cliente);
                vuelosData.SaveChanges();
            }
        }
    }
}