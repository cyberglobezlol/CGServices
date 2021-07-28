using CyberGlobesDM.FacebookDMs;
using CyberGlobesDM.GeneralsDMs;
using CyberGlobesDM.OKDMs;
using CyberGlobesDM.ProfilerDMs;
using CyberGlobesDM.SkypeDMs;
using CyberGlobesDM.TelegramDMs;
using CyberGlobesDM.TwitterDMs;
using System.Collections.Generic;
using System.ServiceModel;

namespace CGServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    [ServiceKnownType(typeof(System.Drawing.Bitmap))]
    [ServiceKnownType(typeof(System.Drawing.Imaging.Metafile))]
    public interface ICGProfilerService
    {
        [OperationContract]
        ProfileAboutDM GetMainProfile(string token, ProfilerQueryParam profilerQueryParam);

        [OperationContract]
        List<Person> GetPiplProfile(string token, string username, string socialID = null);

        [OperationContract]
        TelegramPersonDM GetTelegramProfile(string token, ProfilerQueryParam profilerQueryParam);

        [OperationContract]
        SkypeFullResultDM GetSkypeProfile(string token, ProfilerQueryParam profilerQueryParam);

        [OperationContract]
        MobileLocationDM MobileLocationQuery(string token, string phoneNumber);

        [OperationContract]
        List<LeakDM> GetLeaksProfiles(string token, string target);

        [OperationContract]
        string HashDecryptSearch(string token, string hash);

        [OperationContract]
        TwitterRecoverResultDM TwitterRecoverByUsername(string token, string search);

        [OperationContract]
        FacebookRecoverDM FacebookRecoverByUsername(string token, string search);

        [OperationContract]
        OKUserDM GetOKProfile(string token, ProfilerQueryParam profilerQueryParam);
    }
}
