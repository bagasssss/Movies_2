using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Movies.Infra
{
    public class MovieHeaderFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //var movieAppHeader = actionContext.Request.Headers.Contains("MovieApp");
            //if (!movieAppHeader)
            //{
            //    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            //    return;
            //}

            //base.OnActionExecuting(actionContext);
        }
    }
}