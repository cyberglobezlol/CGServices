using CyberGlobesDM.FacebookDMs;
using CyberGlobesDM.VKDMs;
using InstaSharp.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace CGServices
{
    [ServiceContract]
    public interface ICGVKService
    {


        [OperationContract]
        VKPostResponseDM GetVKposts(string token, SearchQueryParam searchQueryParam);

        [OperationContract]
        VKAutoCompleteDM SearchForUsersByName(string token, string name);

        [OperationContract]
        void ExportVKToDB(string token, List<CyberGlobesDM.VKDMs.Item> vkResults);

        [OperationContract]
        VKUser SearchForUsersByID(string token, string id);

        [OperationContract]
        VKPostResponseDM GetVKpostsById(string token, SearchQueryParam searchQueryParam);

        [OperationContract]
        VKPostResponseDM GetVKMentionsById(string token, SearchQueryParam searchQueryParam);

        [OperationContract]
        List<CyberGlobesDM.VKDMs.Item> GetInfoById(string token, List<CyberGlobesDM.VKDMs.Item> users, List<CyberGlobesDM.VKDMs.Item> groups);

        [OperationContract]
        VKFriendsDM GetVKFriendsById(string token, SearchQueryParam searchQueryParam);

        [OperationContract]
        VKGroupsDM GetVKGroupsById(string token, SearchQueryParam searchQueryParam);
    }
}
