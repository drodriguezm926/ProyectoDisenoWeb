﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using System.Web.Security;

namespace EFood_ECommerce.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult LoginAction(Customer customer)
        {
            try
            {
                List<Customer> loginCustomer = Customer.LoginCustomer(customer.Email, customer.ContrasenaEmail);

                if (loginCustomer != null)
                {
                    if (loginCustomer.Count > 0)
                    {
                        Session["Usuario"] = loginCustomer.FirstOrDefault();
                        return RedirectToAction("Inicio", "Inicio");
                    }
                    else
                    {
                        AddAlertMessage("Usuario o contraseña incorrectos");
                        return RedirectToAction("Login", "Login");
                    }
                }
                else
                {
                    AddAlertMessage("Usuario o contraseña incorrectos");
                    return RedirectToAction("Login", "Login");
                }
            }
            catch (Exception ex)
            {
                AddAlertMessage("Error, intente mas tarde. Detalles: " + ex.Message);
                return RedirectToAction("Login", "Login");
            }
        }

        private void AddAlertMessage(string message)
        {
            TempData["msg"] = "<script>alert('" + message + "');</script>";
        }

    }
}