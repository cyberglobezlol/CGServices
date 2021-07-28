using CyberGlobesDM.FacebookDMs;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text.RegularExpressions;

namespace CGServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICGAvatarManagerService" in both code and config file together.
    [ServiceContract]
    public interface ICGAnalyticsService
    {
        [OperationContract]
        Dictionary<string, List<string>> GetTextNER(string token, string text);

        [OperationContract]
        MatchCollection GetTextEmails(string token, string text);

        [OperationContract]
        List<string> GetTextPhoneNumbers(string token, string text);
    }
}
