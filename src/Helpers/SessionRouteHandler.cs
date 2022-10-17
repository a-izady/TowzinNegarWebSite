using System.Web;
using System.Web.Routing;

namespace Kendo.Mvc.Examples
{
    // enable sessionState for Grid WebApi demo
    public class SessionRouteHandler : IRouteHandler
    {
        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            return new SessionControllerHandler(requestContext.RouteData);
        }
    }
}