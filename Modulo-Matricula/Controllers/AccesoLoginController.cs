using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modulo_Matricula.Controllers
{
    public class AccesoLoginController : Controller
    {
        // GET: AccesoLogin
        public ActionResult Login()
        {
            return View();
        }



        // Metodo post para capturar el User y el Password....

        [HttpPost]
        public ActionResult Login(string email, string pass)
        {
            try
            {

                //abrimos coneccion a la base de datos...

                using (bdsistemaEntities db = new bdsistemaEntities())
                {
                    //declaramos la variable que captura los datos del los imput...

                    var oUser = (from d in db.Usuarios
                                 where d.Usuario == email.Trim() && d.Contrasena == pass.Trim()
                                 select d).FirstOrDefault();


                    //validamos la informacion 

                    if (oUser == null)
                    {
                        ViewBag.Error = "Usuario o contraseña invalida";
                        return View();
                    }


                    // cramos el filtro para bloquear el paso a las demas páginas...
                    Session["User"] = oUser;

                }

                // si todo sale bien retornamos  a la pagina de inicio...
                return RedirectToAction("Index", "Home");
            }



            //en caso de error mandamos un mensaje...

            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }




    }
}