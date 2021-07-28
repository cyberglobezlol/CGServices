using CyberGlobesDM.FacebookDMs;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.ServiceModel;

namespace CGServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICGYoutubeService
    {

        [OperationContract]
        SearchListResponse YouTubeListRequest(string token, SearchQueryParam searchQueryParam);
        //SearchListResponse YouTubeListRequest();



    }
}
