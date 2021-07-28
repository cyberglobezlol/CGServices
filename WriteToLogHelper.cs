using CyberGlobes.BL.CyberGlobesCore;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;

namespace CGServices
{
    public class WriteToLogHelper <T>
    {
        private static volatile WriteToLogHelper<T> instance;
        private static object syncRoot = new Object();

        public static WriteToLogHelper<T> Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new WriteToLogHelper<T>();
                    }
                }

                return instance;
            }
        }
        public Func<string, bool> WriteToLog = x =>
        {
            string userAgent = WebOperationContext.Current.IncomingRequest.Headers["User-Agent"];
            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            string ip = endpoint.Address;
            DatabaseUtils.Instance.WriteToLog("Facebook", x, userAgent, ip);
            return true;
        };
    }
}