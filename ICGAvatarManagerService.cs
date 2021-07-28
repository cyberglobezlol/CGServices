using CyberGlobesDM.AvatarManagerDMs;
using CyberGlobesDM.FacebookDMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CGServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICGAvatarManagerService" in both code and config file together.
    [ServiceContract]
    public interface ICGAvatarManagerService
    {
        [OperationContract]
        List<AvatarUserDM> GetAvatarList(string token);

        [OperationContract]
        void UpdateAvatarCookie(string token, int id ,string cookie);

        [OperationContract]
        void PerformLogin(string token, SearchQueryParam searchQueryParam);
    }
}
