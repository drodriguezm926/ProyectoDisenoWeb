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
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // Limpia la sesion
            return RedirectToAction("Login", "Login");
        }

        public ActionResult LoginAction(CustomerModel customer)
        {
            try
            {
                List<CustomerModel> loginCustomer = CustomerModel.LoginCustomer(customer.Email, customer.ContrasenaEmail);

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

        public ActionResult Registro(CustomerModel customer)
        {
            try
            {
                List<CustomerModel> loginCustomer = CustomerModel.LoginCustomer(customer.Email, customer.ContrasenaEmail);

                if (CustomerModel.ExisteCustomer(customer))
                {
                    AddAlertMessage("El correo ingresado, ya se encuentra registrado.");
                    return RedirectToAction("Registro", "Login");
                }
                else
                {
                    if(customer.ContrasenaEmail != customer.ConfirmaContrasena)
                    {
                        AddAlertMessage("Las contraseñas no coinciden.");
                        return RedirectToAction("Registro", "Login");
                    }
                    else
                    {
                        CustomerModel.AgregarCustomer(customer);
                        AddAlertMessage("Se ha agregado correctamente.");
                        return RedirectToAction("Login", "Login");
                    }
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