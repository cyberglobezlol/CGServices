using CyberGlobesDM.TwitterDMs;
using System.Collections.Generic;
using System.ServiceModel;
using TweetSharp;

namespace CGServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICGTwitterService
    {


        [OperationContract]
        TwitterSearchResult TwitterSearch(string token, SearchOptions twitterSearchOptions , bool includeAnalytics);

        [OperationContract]
        bool TwitterSearchByInterval(string token, string Interval);

        [OperationContract]
        TwitterTrendsDM ListClosestTrendsLocations(string token, ListClosestTrendsLocationsOptions listClosestTrendsLocationsOptions);

        [OperationContract]
        IEnumerable<TwitterStatus> ListTweetsOnUserTimeline(string token, ListTweetsOnUserTimelineOptions listTweetsOnUserTimelineOptions , bool includeAnalytics);

        [OperationContract]
        long[] CalcMutualFollowings(string token, long[] selectedTwitterUserIdList);

        [OperationContract]
        long[] CalcMutualFollowers(string token, long[] selectedTwitterUserIdList);

        [OperationContract]
        TwitterCursorListDM ListFriends(string token, ListFriendsOptions listFriendsOptions);
        [OperationContract]
        TwitterCursorListDM ListFollowers(string token, ListFollowersOptions listFollowersOptions);
        [OperationContract]
        TwitterCursorList<TwitterUser> ListUserProfilesFor(string token, ListUserProfilesForOptions listUserProfilesForOptions);
        [OperationContract]
        TwitterUser GetUserProfileFor(string token, GetUserProfileForOptions getUserProfileForOptions);
        [OperationContract]
        void ExportTwitterToDB(string token, List<TwitterStatus> twitterSearchResult);

        // TODO: Add your service operations here
        [OperationContract]
        List<TwitterUser> CalcMutualFollowersFull(string token, List<TwitterUser> selectedTwitterUserIdList);
        [OperationContract]
        List<TwitterUser> CalcMutualFollowingsFull(string token, List<TwitterUser> selectedTwitterUserIdList);    
        [OperationContract]
        List<TwitterUser> SearchForUsersByName(string token, SearchForUserOptions selectedTwitterUserIdList);

    }
}

