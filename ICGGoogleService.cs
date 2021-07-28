using CyberGlobesDM.FacebookDMs;
using CyberGlobesDM.GoogleDMs;
using InstaSharp.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace CGServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICGGoogleService" in both code and config file together.
    [ServiceContract]
    public interface ICGGoogleService
    {
        [OperationContract]
        GoogleSearchDM GetGoogleSearchByQuery(string token, SearchQueryParam searchQueryParam);

        [OperationContract]
        GoogleResultSerpDM GetGoogleSearchDataSerpByQuery(string token, SearchQueryParam searchQueryParam);

        [OperationContract]
        GoogleResultSerpDM GetGoogleSearchImagesSerpByQuery(string token, SearchQueryParam searchQueryParam);

        [OperationContract]
        GoogleSerpNewsResultDM GetGoogleSearchNewsSerpByQuery(string token, SearchQueryParam searchQueryParam);


    }
}
