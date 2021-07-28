using CyberGlobes.BL.CyberGlobesCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CGServices
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //  ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback +=
                (senderx, cert, chain, error) =>
                {

                    if (error == System.Net.Security.SslPolicyErrors.None)
                    {
                        return true;
                    }
                    else
                    {
                        if (cert.Issuer == "CN=WIN-66CDGUSALFI.Cyberglobes.VPN" && ((System.Net.HttpWebRequest)senderx).Host == "84.110.37.131:8800")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                };


        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
           
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            string userAgent = ((System.Web.HttpApplication)sender).Request.UserAgent;
            string ip = ((System.Web.HttpApplication)sender).Request.UserHostAddress;
           
                string action = ((System.Web.HttpApplication)sender).Request.Headers["SOAPAction"];
                if (!string.IsNullOrEmpty(action) && !action.Contains("WriteToLog"))
                {
                    DatabaseUtils.Instance.WriteToLog(action, "Guardian", userAgent, ip);

                }
            
            //string userAgent = WebOperationContext.Current.IncomingRequest.Headers["User-Agent"];
            //OperationContext context = OperationContext.Current;
            //MessageProperties prop = context.IncomingMessageProperties;
            //RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            //string ip = endpoint.Address;
            //DatabaseUtils.Instance.WriteToLog("Facebook", x, userAgent, ip);
            //return true;
            //CGServices.WriteToLogHelper<object>.Instance.WriteToLog("stat");
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}