using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// utiliar notaweb.model e entity
using CardapioDigital.Models;
using CardapioDigital.Entity;

namespace CardapioDigital.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            //conecatar com o usuariomodel
            using (UsuarioModel model = new UsuarioModel())
            {
                Pessoa pessoa = model.Login(form["email"], form["senha"]);

                if (pessoa == null)
                {
                    ViewBag.Mensagem = "Email ou senha incorretas";
                    return View();
                }
                else
                {

                    // manter a sessao do usuario
                    Session["usuario"] = pessoa;
                    Session.Timeout = 60;

                    // Redireciona o tipo pessoa para pagina correta
                    if (pessoa is Professor)
                    {
                        return RedirectToAction("Index", "Disciplina");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Nota");
                    }

                }
            }

        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(FormCollection form)
        {
            Professor p = new Professor();
            p.Nome = form["nome"];
            p.Email = form["email"];
            p.Senha = form["senha"];
            p.Titulo = form["titulo"];

            using (ProfessorModel model = new ProfessorModel())
            {
                model.Create(p);
                return RedirectToAction("Index");
            }


        }

    }
}