using CyberGlobes.BL.CyberGlobesCore;
using CyberGlobes.BL.CyberGlobesFacebookCore;
using CyberGlobes.BL.CyberGlobesPiplCore;
using CyberGlobes.BL.CyberglobesTruecallerCore;
using CyberGlobes.BL.CyberGlobesTwitterCore;
using CyberGlobes.DAL.CyberglobesDataSetTableAdapters;
using CyberGlobesDM.CustomAttributes;
using CyberGlobesDM.FacebookDMs;
using CyberGlobesDM.GeneralsDMs;
using CyberGlobesDM.TwitterDMs;
using CyberGlobesInfra;
using CyberGlobesInfra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using TweetSharp;

namespace CGServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CGDBReports" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CGDBReports.svc or CGDBReports.svc.cs at the Solution Explorer and start debugging.
    public class CGDBReportsService : CGParentController , ICGDBReportsService
    {
        TwitterPostTableAdapter twitterPostTableAdapter = new TwitterPostTableAdapter();
        public CyberGlobes.DAL.CyberglobesDataSet.TwitterPostDataTable GetTwitterPostDataTable(string TwitterId, string Name, string ScreenName, DateTime? FromdDate, DateTime? ToDate, string Text, string Language, string Location, string FriendsCout, string FollowersCount, string Latitude, string Longitude, string UploadMethod, string UploadUser)
        {
            
            CyberGlobes.DAL.CyberglobesDataSet.TwitterPostDataTable twitterPostDataTable = twitterPostTableAdapter.GetDataByTwitterPost(TwitterId,Name,ScreenName, FromdDate, ToDate , Text,Language, Location,FriendsCout, FollowersCount,Latitude,Longitude,UploadMethod,UploadUser);
            return twitterPostDataTable;
        }

        public int TwitterPostsCountRows(string TwitterId, string Name, string ScreenName, DateTime? FromdDate, DateTime? ToDate, string Text, string Language, string Location, string FriendsCout, string FollowersCount, string Latitude, string Longitude, string UploadMethod, string UploadUser)
        {
            int? twitterCount = (Int32)twitterPostTableAdapter.ScalarCountRows(TwitterId, Name, ScreenName, FromdDate, ToDate, Text, Language, Location, FriendsCout, FollowersCount, Latitude, Longitude, UploadMethod, UploadUser);
            return twitterCount.GetValueOrDefault();
        }


    }
}
