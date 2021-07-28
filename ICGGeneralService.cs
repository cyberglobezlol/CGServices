using CyberGlobesDM.GeneralsDMs;
using CyberGlobesInfra;
using System.ServiceModel;

namespace CGServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICGGeneralService
    {
        [OperationContract]
        string IsLoginAuthorize(string UserName, string UserPassword, string macAddress, string token);
        [OperationContract]
        SocialUser GetSocialUser(string socialType, string company, string token, int avatarId);
        [OperationContract]
        CyberglobesSysUser GetCyberglobesUser(string userName, string passWord, string token);
        [OperationContract]
        void WriteToLog(string action, string search, string token);
        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
        [OperationContract]
        void UpdateCookie(string cookie, int id, string token,string AccesstokenSecret);
        [OperationContract]
        void UpdateSkypeToken(string skypeToken, string skypeRefreshToken, string skypeAccessToken, int rowId, string token);
        //[OperationContract]
        //bool LocatorAppVerifyMAC(string hash, string nonce);


    }
}
