using CyberGlobesDM.WhoIsDMs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CGServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICGWhoIsService" in both code and config file together.
    [ServiceContract]
    public interface ICGWhoIsService
    {
        [OperationContract]
        ObservableCollection<WhoIsDomainDM> GetWhoIsDomainsInfoByEmails(string token, List<string> emails);


        [OperationContract]
        WhoIsDomainDM GetWhoIsDomainInfoByDomain(string token, string domain);
    }
}
