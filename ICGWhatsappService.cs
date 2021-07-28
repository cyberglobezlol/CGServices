using CyberGlobesDM.GeneralsDMs;
using CyberGlobesDM.WhatsAppDMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CGServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICGWhatsappService" in both code and config file together.
    [ServiceContract]
    public interface ICGWhatsappService
    {
        [OperationContract]
        WhatsAppPersonDM GetWhatsappUser(string token, ProfilerQueryParam profilerQueryParam);

    }
}
