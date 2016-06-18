using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotaWeb.Filtros;
using NotaWeb.Models;

namespace NotaWeb.Controllers
{
    public class NotaController : Controller
    {
        // GET: Nota
        [Autorizacao]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Relatorio(int id)
        {
            using (NotaModel model = new NotaModel())
            {
                return View(model.Relatorio(id));
            }
            
        }


    }
}