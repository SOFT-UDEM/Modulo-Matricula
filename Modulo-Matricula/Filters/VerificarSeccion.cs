using Modulo_Matricula.Controllers;
using Modulo_Matricula.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modulo_Matricula.Filters
{
    public class VerificarSeccion : ActionFilterAttribute
    {
        private Usuarios oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                oUsuario = (Usuarios)HttpContext.Current.Session["User"];
                if (oUsuario == null)
                {

                    if (filterContext.Controller is AccesoLoginController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/AccesoLogin/Login");
                    }



                }

            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/AccesoLogin/Login");
            }

        }
    }
}