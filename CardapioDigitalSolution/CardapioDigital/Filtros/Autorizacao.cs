using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace CardapioDigital.Filtros
{
    public class Autorizacao : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            //verifica se existe uma sessao usuario, se for igual a null nao existe usuario autenticado e volta para home
            if (actionContext.HttpContext.Session["usuario"] == null)
            {
                actionContext.HttpContext.Response.Redirect("/home/index");
            }
            else
            {
                base.OnActionExecuting(actionContext);
            }
        }
    }
}