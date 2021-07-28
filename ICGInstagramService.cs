using CyberGlobesDM.FacebookDMs;
using InstaSharp.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace CGServices
{
    [ServiceContract]
    public interface ICGInstagramService
    {

       [OperationContract]
        List<UserInfo> SearchInstagramUsersByName(string token, string instagramNameSearch, bool v);

        [OperationContract]
        InstaSharp.Models.Responses.MediasResponse GetInstagramPost(string token, SearchQueryParam searchQueryParam);
        [OperationContract]
        InstaSharp.Models.Responses.MediasResponse GetInstagramPostByUser(string token, SearchQueryParam searchQueryParam);

        [OperationContract]
        InstaSharp.Models.User GetInstagramProfileInfoByUserID(string token, string UserId);
        [OperationContract]
        void ExportInstagramToDB(string token, List<InstaSharp.Models.Media> instagramResults);
        [OperationContract]
        List<InstaSharp.Models.UserInfo> GetFollowers(string token, string id);
        [OperationContract]
        List<InstaSharp.Models.UserInfo> GetFollowings(string token, string id);
        [OperationContract]
        InstaSharp.Models.UserInfo GetInstagramUserInfo(string token, string UserId);
    }
}
