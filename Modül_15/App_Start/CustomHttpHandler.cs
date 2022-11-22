using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Routing;

namespace Modül_15.App_Start
{
    //IHttpHandler interface ini class içerisine implemente ediyoruz

    public class CustomHttpHandler : IHttpHandler
    {
        public RequestContext _RequestContext { get; set; }
        public CustomHttpHandler(RequestContext RequestContext)
        {
            _RequestContext= RequestContext;
        }
        //Gelen başka bir isteğin http handler ı kullanıp kullanmayacağını belirtiriz
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("<h1 style='Color:#000000'>CustomHttpHandler başarıyla çalıştı.</h1>");
            context.Response.Write("Handler işlenme tarihi" + DateTime.Now.ToString());
            
        }

      
    }
}