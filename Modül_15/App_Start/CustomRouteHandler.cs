using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Modül_15.App_Start
{
    public class CustomRouteHandler : IRouteHandler
    {
        //İmplemente ettiğimiz metodu yazıyoruz. Oluşturmuş olduğumuz handler içine requestContext parametresini gönderiyoruz. Bundan soranki adımda
        //Routeconfig class ı içerisinde yapılandırmamızı yapacağız.
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new CustomHttpHandler(requestContext);
        }
    }
}