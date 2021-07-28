using CyberGlobesDM.FacebookDMs;
using CyberGlobesDM.GeneralsDMs;
using CyberGlobesInfra;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System;


namespace CGServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICGDBReports" in both code and config file together.
    [ServiceContract]
    public interface ICGDBReportsService
    {

        [OperationContract]
        CyberGlobes.DAL.CyberglobesDataSet.TwitterPostDataTable GetTwitterPostDataTable(string TwitterId, string Name, string ScreenName, DateTime? FromdDate , DateTime? ToDate, string Text, string Language, string Location, string FriendsCout, string FollowersCount, string Latitude, string Longitude, string UploadMethod, string UploadUser);

        [OperationContract]
        int TwitterPostsCountRows(string TwitterId, string Name, string ScreenName, DateTime? FromdDate, DateTime? ToDate, string Text, string Language, string Location, string FriendsCout, string FollowersCount, string Latitude, string Longitude, string UploadMethod, string UploadUser);
    }
}
