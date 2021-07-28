using CyberGlobesDM.FacebookDMs;
using CyberGlobesDM.GeneralsDMs;
using CyberGlobesInfra;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace CGServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICGFacebookService
    {
        [OperationContract]
        List<string> GetCheckFriendship(string token, string uid, List<string> friendsUidList);

        [OperationContract]
        FacebookUserDM GetFacebookUser(string token, string uid, int avatarId);
        [OperationContract]
        FacebookPageLikesAndCommentsDM GetFacebookPageComments(string token, string pageID, FacebookPostTypesEnums facebookPostTypesEnums, int avatarId, int? monthsToRetrieve = null, FacebookCursors facebookCursors = null);

        [OperationContract]
        List<FacebookUserDM> GetFacebookUsersInfo(string token, List<string> usersIdsTemp, string fields, int avatarId, int? savedID);

        [OperationContract]
        FacebookPageLikesAndCommentsDM GetFacebookPageLikes(string token, string pageID, FacebookPostTypesEnums facebookPostTypesEnums, int avatarId, int? monthsToRetrieve = null, FacebookCursors facebookCursors = null);

        [OperationContract]
        FacebookContainerDM<FacebookUserDM> GetFacebookPostLikes(string token, string postID, int avatarId, int? savedID, FacebookCursors facebookCursors = null );

        [OperationContract]
        List<FacebookUserDM> ExtractTaggedFriends(string token, string sourceUid, int avatarId, int? savedID);

        [OperationContract]
        FacebookContainerDM<FacebookGroupDM> GetUserGroupsList(string token, FacebookUserResultDM facebookUsersParticipantsList, string fetchAction, string userId, string name, string participantAnchorType, string relationshipStatus, FacebookPageTypeAndAction facebookPageTypeAndAction, string additionalFields, int avatarId);

        [OperationContract]
        FacebookContainerDM<FacebookPageDM> GetUserPagesList(string token, FacebookUserResultDM facebookUsersParticipantsList, string fetchAction, string userId, string name, string participantAnchorType, string relationshipStatus, FacebookPageTypeAndAction facebookPageTypeAndAction, string additionalFields, int avatarId);

        [OperationContract]
        FacebookContainerDM<FacebookUserEventDM> GetUserEventsList(string token, SearchQueryParam searchQueryParam, int avatarId);

        [OperationContract]
        FacebookContainerDM<FacebookPlaceDM> GetFacebookPlaces(string token, SearchQueryParam searchQueryParam, int avatarId);

        [OperationContract]
        object GetFacebookAlbums(string token, string uid, int avatarId);

        [OperationContract]
        List<FacebookAlbumDM> GetFacebookAlbumsData(string token, string uid, int avatarId);

        [OperationContract]
        dynamic GetFacebookPhotos(string token, dynamic id, dynamic jsonPhotos, int avatarId);

        [OperationContract]
        FacebookContainerDM<FacebookPhotoDM> GetFacebookUserPhotos(string token, SearchQueryParam searchQueryParam , string albumID, int avatarId);

        [OperationContract]
        FacebookCommantsDM GetFacebookCommentByPost(string token, string id, int avatarId);

        [OperationContract]
        FacebookUserResultDM GetUsersParticipantsList(string token, FacebookUserResultDM facebookUsersParticipantsList, string fetchAction, string userId, string name, string participantAnchorType, string relationshipStatus, FacebookPageTypeAndAction facebookPageTypeAndAction, string additionalFields, int avatarId, int? savedID);

        [OperationContract]
        List<string> ExtractBlockFriends(string token, string sourceUid, string targetUid, int avatarId);

        [OperationContract]
        FacebookContainerDM<FacebookEventDM> GetFacebookEvents(string token, SearchQueryParam searchQueryParam, string name, int avatarId);

        [OperationContract]
        FacebookContainerDM<FacebookGroupDM> GetFacebookGroups(string token, SearchQueryParam searchQueryParam, int avatarId);

        [OperationContract]
        FacebookContainerDM<FacebookUserDM> GetFacebookUsersByName(string token, SearchQueryParam searchQueryParam, int avatarId);

        [OperationContract]
        FacebookContainerDM<FacebookPageDM> GetFacebookPages(string token, SearchQueryParam searchQueryParam, int avatarId);

        [OperationContract]
        FacebookContainerDM<FacebookPostDM> GetFacebookPosts(string token, SearchQueryParam searchQueryParam, int avatarId);

        [OperationContract]
        FacebookUserDM FriendfinderMobile(string token, string media, int avatarId);

        [OperationContract]
        FacebookUserDM FacebookContactPerson(string token, string media, int avatarId);

        [OperationContract]
        List<FacebookPostDM> GetFacebookPostByUidSequence(string token, SearchQueryParam searchQueryParam, List<string> uidList, int avatarId);

        [OperationContract]
        FacebookContainerDM<FacebookPostDM> GetFacebookPostByUid(string token, SearchQueryParam searchQueryParam, int avatarId);

        [OperationContract]
        FacebookCommantsDM GetFacebookPostComments(string token, string postID, int avatarId, FacebookCursors facebookCursors = null);

        [OperationContract]
        List<FacebookAutoComplateDM> FBAutoComplete(string token, string search, int avatarId);

        [OperationContract]
        string WebScopeIDConverter(string token, string ScopeID, int avatarId);

        [OperationContract]
        FacebookUserDM GetFacebookType(string token, string text, int avatarId);

        [OperationContract]
        List<FacebookUserDM> CalculateUsersInfo(string token, List<string> usersIds , string fields , int avatarId);

        [OperationContract]
        void ExportFacebookPostToDB(string token, List<FacebookPostDM> facebookResult);

        [OperationContract]
        void ExportFacebookPageToDB(string token, List<FacebookPageDM> facebookResult);

        [OperationContract]
        void ExportFacebookPlaceToDB(string token, List<FacebookPlaceDM> facebookResult);

        [OperationContract]
        void ExportFacebookGroupToDB(string token, List<FacebookGroupDM> facebookResult);

        [OperationContract]
        void ExportFacebookEventToDB(string token, List<FacebookEventDM> facebookResult);

        [OperationContract]
        void ExportFacebookUserToDB(string token, List<FacebookUserDM> facebookResult);

        [OperationContract]
        void ExportPotentialUserToDB(string token, List<FacebookPotentialTargetDM> facebookPotentialUser);

        [OperationContract]
        string GetTokenParams(CyberGlobesDM.GeneralsDMs.SocialUser user, string token);

        [OperationContract]
        string UpdateToken(int id, string accessToken, string token);

        [OperationContract]
        List<SavedDatabaseNames> GetSavedUsersNames(string token, string user);

        [OperationContract]
        List<FacebookUserDM> GetSavedUsersFromDB(string token, List<int> IDs);

        [OperationContract]
        List<FacebookPotentialTargetDM> GetSavedPotentialTargets(string token, string user);

        [OperationContract]
        List<FacebookUserDM> GetSavedUsersFromParentIdDB(string token, List<string> parentIds);

        [OperationContract]
        int SaveUsersIDs(string token, int userId, string userName, string txtSaveName, System.DateTime date);

        [OperationContract]
        void DeleteUsersIDs(string token, int? savedID);
        
        [OperationContract]
        void SaveFacebookUsers(string token, List<FacebookUserDM> facebookResult, int savedID);

        [OperationContract]
        void DeleteSavedUsersFromDB(string token, List<int> IDs);

    }



    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
