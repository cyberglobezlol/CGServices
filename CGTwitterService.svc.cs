using CyberGlobes.BL.CyberGlobesCore;
using CyberGlobes.BL.CyberGlobesFacebookCore;
using CyberGlobes.BL.CyberGlobesPiplCore;
using CyberGlobes.BL.CyberglobesTruecallerCore;
using CyberGlobes.BL.CyberGlobesTwitterCore;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CGTwitterService : CGParentController, ICGTwitterService
    {
        DatabaseUtils dataUtilsBL = new DatabaseUtils();
        string type1 = "TwitterLevel1";
        TwitterBL twitterBL = new TwitterBL();
        
      

        public TwitterSearchResult TwitterSearch(string token, SearchOptions twitterSearchOptions , bool includeAnalytics)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return twitterBL.TwitterSearch(twitterSearchOptions , includeAnalytics);
            }
            return null;
        }

        public bool TwitterSearchByInterval(string token ,string Interval)
        {
            if (token == "IntervalIsTheLifeOrNotok")
            {
                return twitterBL.TwitterSearchByInterval(Interval);
            }
            return false;

        }

        public void ExportTwitterToDB(string token, List<TwitterStatus> twitterSearchResult)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                twitterBL.ExportTwitterToDB(twitterSearchResult,"Manual");
            }
        }

        public TwitterUser GetUserProfileFor(string token, GetUserProfileForOptions getUserProfileForOptions)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return twitterBL.GetUserProfileFor(getUserProfileForOptions);
            }
            return null;
        }

        public IEnumerable<TwitterStatus> ListTweetsOnUserTimeline(string token, ListTweetsOnUserTimelineOptions listTweetsOnUserTimelineOptions, bool includeAnalytics)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token) || token == CyberGlobesConst.DefualtToken)
            {
                return twitterBL.ListTweetsOnUserTimeline(listTweetsOnUserTimelineOptions , includeAnalytics);

            }
            return null;
        }

        public TwitterTrendsDM ListClosestTrendsLocations(string token, ListClosestTrendsLocationsOptions listClosestTrendsLocationsOptions)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return twitterBL.ListClosestTrendsLocations(listClosestTrendsLocationsOptions);

            }
            return null;
        }

        public long[] CalcMutualFollowings(string token, long[] selectedTwitterUserIdList)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return twitterBL.CalcMutualFollowings(selectedTwitterUserIdList);

            }
            return null;
        }

        public long[] CalcMutualFollowers(string token, long[] selectedTwitterUserIdList)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return twitterBL.CalcMutualFollowers(selectedTwitterUserIdList);
            }
            return null;
        }

        public List<TwitterUser> CalcMutualFollowersFull(string token, List<TwitterUser> selectedTwitterUserIdList)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return twitterBL.CalcMutualFollowersFull(selectedTwitterUserIdList);
            }
            return null;
        }
        public List<TwitterUser> CalcMutualFollowingsFull(string token, List<TwitterUser> selectedTwitterUserIdList)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return twitterBL.CalcMutualFollowingsFull(selectedTwitterUserIdList);
            }
            return null;
        }

        public TwitterCursorListDM ListFriends(string token, ListFriendsOptions listFriendsOptions)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return twitterBL.ListFriends(listFriendsOptions);
            }
            return null;
        }

        public TwitterCursorListDM ListFollowers(string token, ListFollowersOptions listFollowersOptions)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return twitterBL.ListFollowers(listFollowersOptions);
            }
            return null;
        }

        public TwitterCursorList<TwitterUser> ListUserProfilesFor(string token, ListUserProfilesForOptions listUserProfilesForOptions)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return twitterBL.ListUserProfilesFor(listUserProfilesForOptions);
            }
            return null;
        }

        public List<TwitterUser> SearchForUsersByName(string token, SearchForUserOptions selectedTwitterUserIdList)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return twitterBL.SearchForUsersByName(selectedTwitterUserIdList);
            }
            return null;
        }


        static CGTwitterService()
        {
            InitTokens();
        }
        private static void InitTokens()
        {
            try
            {
                SocialUser socialUser = null;
                if (CyberGlobesConst.IsLoaclSocialUserEnabled())
                {
                    socialUser = DatabaseUtils.Instance.GetSocialUser("Twitter", CyberGlobesConst.Company(),0);
                }
                else
                {
                    CGGeneralServicesDB.CGGeneralServiceClient generalServiceClient = new CGGeneralServicesDB.CGGeneralServiceClient();
                    socialUser = generalServiceClient?.GetSocialUser("Twitter", CyberGlobesConst.Company(), systemCostantToken,0);
                }

                if (socialUser != null)
                {
                    TwitterSettingHelper.AppToken = StringCipher.Decrypt(socialUser.Accesstoken, CyberGlobesConst.CipherPassword);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
