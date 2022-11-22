using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Modül_15.App_Start
{
    public class CustomHttpModule : IHttpModule
    {
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            //Request işlenmeye başladığında çalışan eventdir.
            context.BeginRequest += (new EventHandler(this.Application_BeginRequest));
            //Request bittiğinde başladığında çalışan eventdir.
            context.EndRequest += (new EventHandler(this.Application_BeginRequest));
            //Authentication yapıldığında(Kimlik doğrulama gerçekleştiğinde) çalışan eventdir.
            context.AuthenticateRequest += (new EventHandler(this.Authenticate_Request));
            //Bunları tamamladıktan sonra web config dosyamızda yapılandırmaları yapıyoruz. 31. satıra breakpoint ekleyerek uygulamanın çalışma esnasında nasıl davrandığını görebiliriz.
        }
        public void Application_EndRequest(object sender, EventArgs e)
        {
            //Mongodb üzerine log yazabiliriz.
        }
        public void Application_BeginRequest(object sender, EventArgs e)
        {
            //Mongodb üzerine log yazabiliriz.
        }
        public void Authenticate_Request(object sender, EventArgs e)
        {
            //Mongodb üzerine log yazabiliriz.
        }
    }
}