using CyberGlobes.BL.CyberGlobesCore;
using CyberGlobes.BL.CyberGlobesWhoIsCore;
using CyberGlobesDM.WhoIsDMs;
using CyberGlobesInfra.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CGServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CGWhoIsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CGWhoIsService.svc or CGWhoIsService.svc.cs at the Solution Explorer and start debugging.
    public class CGWhoIsService : ICGWhoIsService
    {
        string type1 = "ProfilerLevel1";
        DatabaseUtils dataUtilsBL = new DatabaseUtils();

        public ObservableCollection<WhoIsDomainDM> GetWhoIsDomainsInfoByEmails(string token, List<string> emails)
        {
            ObservableCollection<WhoIsDomainDM> collectionWhoIsDomain = new ObservableCollection<WhoIsDomainDM>();
            WhoIsBL whoIsBL = new WhoIsBL();
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                if (emails != null && emails.Count > 0)
                {
                    collectionWhoIsDomain = whoIsBL.GetWhoIsDomainsByEmails(emails);
                }
            }
            return collectionWhoIsDomain;
        }

        public WhoIsDomainDM GetWhoIsDomainInfoByDomain(string token, string domain)
        {
            WhoIsDomainDM whoIsDomain = new WhoIsDomainDM();
            WhoIsBL whoIsBL = new WhoIsBL();
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                if (!string.IsNullOrEmpty(domain) && ValidateUtils.IsValidDomain(domain))
                {
                    whoIsDomain = whoIsBL.GetWhoIsInfoFromDomain(domain);
                }
            }
            return whoIsDomain;
        }
    }
}
