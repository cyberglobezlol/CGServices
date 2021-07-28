using CyberGlobesDM.FacebookDMs;
using CyberGlobesDM.WeiboDMs;
using System.Collections.Generic;
using System.ServiceModel;

namespace CGServices
{
    [ServiceContract]
    public interface ICGWeiboService
    {
        [OperationContract]
        IEnumerable<Blog> SearchBlogs(string token, SearchQueryParam weiboQueryParams);


    }
}
