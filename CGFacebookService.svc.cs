using CyberGlobes.BL.CyberGlobesCore;
using CyberGlobes.BL.CyberGlobesFacebookCore;
using CyberGlobesDM.FacebookDMs;
using CyberGlobesDM.GeneralsDMs;
using CyberGlobesInfra;
using CyberGlobesInfra.Utils;
using System;
using System.Collections.Generic;
using System.Net;

namespace CGServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CGFacebookService : CGParentController, ICGFacebookService
    {
        private CGGeneralServicesDB.CGGeneralServiceClient generalServiceClient;

        FacebookBL facebookBL = new FacebookBL();
        DatabaseUtils dataUtilsBL = new DatabaseUtils();
        string type1 = "FBLevel1";
        string type2 = "FBLevel2";
        string type3 = "FBLevel3";

        public FacebookUserDM GetFacebookUser(string token, string uid, int avatarId)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                return facebookBL.GetFacebookUser(uid);
            }
            return null;
        }

        public FacebookPageLikesAndCommentsDM GetFacebookPageComments(string token, string pageID, FacebookPostTypesEnums facebookPostTypesEnums, int avatarId, int? monthsToRetrieve = null, FacebookCursors facebookCursors = null)
        {
            //if (facebookPageLikesDM!=null && facebookPageLikesDM.paging != null && !string.IsNullOrEmpty(facebookPageLikesDM.paging.next))
            //{
            //    //facebookPageLikesDM.afterCursor = System.Web.HttpUtility.ParseQueryString(facebookPageLikesDM.paging.next).Get("after");
            //    facebookPageLikesDM.afterCursor = facebookPageLikesDM.paging.cursors.after;
            //}
            //WriteToLogHelper<FacebookUserDM>.Instance.WriteToLog("GetFacebookPageComments " + pageID);
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                FacebookPageLikesAndCommentsDM facebookPageLikesAndComments = facebookBL.GetFacebookPageComments(pageID, facebookPostTypesEnums, monthsToRetrieve, facebookCursors);
                serverRemoveValues(facebookPageLikesAndComments);
                return facebookPageLikesAndComments;
            }
            return null;

        }

        public FacebookPageLikesAndCommentsDM GetFacebookPageLikes(string token, string pageID, FacebookPostTypesEnums facebookPostTypesEnums, int avatarId, int? monthsToRetrieve = null, FacebookCursors facebookCursors = null)
        {

            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                FacebookPageLikesAndCommentsDM r = facebookBL.GetFacebookPageLikes(pageID, facebookPostTypesEnums, monthsToRetrieve, facebookCursors);
                serverRemoveValues(r);
                return r;
            }
            return null;

        }

        public List<string> GetCheckFriendship(string token, string uid, List<string> friendsUidList)
        {

            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens();
                List<string> r = facebookBL.CheckFriendship(uid,friendsUidList);
                serverRemoveValues(r);
                return r;
            }
            return null;

        }

        public FacebookContainerDM<FacebookUserDM> GetFacebookPostLikes(string token, string postID, int avatarId, int? savedID = null, FacebookCursors facebookCursors = null)
        {

            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                FacebookContainerDM<FacebookUserDM> r = facebookBL.GetFacebookPostLikes(postID, facebookCursors, savedID);
                serverRemoveValues(r);
                return r;
            }
            return null;
        }

        public List<FacebookUserDM> ExtractTaggedFriends(string token, string sourceUid, int avatarId, int? savedID = null)
        {

            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                FacebookTagsContienerDM facebookTagsContienerDM = facebookBL.ExtractTaggedFriends(sourceUid, savedID);
                if (!CyberGlobesConst.IsLoaclSocialUserEnabled())
                {
                    generalServiceClient.UpdateCookie(facebookTagsContienerDM.CookieString, facebookTagsContienerDM.Rowid, "getMeInside1", facebookTagsContienerDM.AccesstokenSecret);
                }
                else
                {
                    DatabaseUtils.Instance.UpdateCookie(facebookTagsContienerDM.CookieString, facebookTagsContienerDM.Rowid, facebookTagsContienerDM.AccesstokenSecret);
                }
                return facebookTagsContienerDM.CollectionFacebookUserDM;
            }
            return null;
        }

        public FacebookCommantsDM GetFacebookPostComments(string token, string postID, int avatarId, FacebookCursors facebookCursors = null)
        {

            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                FacebookCommantsDM r = facebookBL.GetFacebookPostComments(postID, facebookCursors);
                serverRemoveValues(r);
                return r;
            }
            return null;

        }

        public dynamic GetFacebookAlbums(string token, string uid, int avatarId)
        {

            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                dynamic r = facebookBL.GetFacebookAlbums(uid);
                serverRemoveValues(r);
                return r;
            }
            return null;
        }

        public List<FacebookAlbumDM> GetFacebookAlbumsData(string token, string uid, int avatarId)
        {

            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                dynamic r = facebookBL.GetFacebookAlbumsData(uid);
                serverRemoveValues(r);
                return r;
            }
            return null;
        }

        public dynamic GetFacebookPhotos(string token, dynamic id, dynamic jsonPhotos, int avatarId)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                dynamic r = facebookBL.GetFacebookPhotos(id, jsonPhotos);
                serverRemoveValues(r);
                return r;
            }

            return null;
        }

        public FacebookContainerDM<FacebookPhotoDM> GetFacebookUserPhotos(string token, SearchQueryParam searchQueryParam , string albumID, int avatarId)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                FacebookContainerDM<FacebookPhotoDM> r = facebookBL.GetFacebookPhotos(searchQueryParam , albumID);
                serverRemoveValues(r);
                return r;
            }
            return null;
        }

        public FacebookContainerDM<FacebookPlaceDM> GetFacebookPlaces(string token, SearchQueryParam searchQueryParam, int avatarId)
        {

            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                FacebookContainerDM<FacebookPlaceDM> r = facebookBL.GetFacebookPlaces(searchQueryParam);
                serverRemoveValues(r);
                return r;
            }
            return null;

        }

        public FacebookCommantsDM GetFacebookCommentByPost(string token, string id, int avatarId)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                return facebookBL.GetFacebookCommentByPost(id);
            }
            return null;

        }

        public FacebookUserResultDM GetUsersParticipantsList(string token, FacebookUserResultDM facebookUsersParticipantsList, string fetchAction, string userId, string name, string participantAnchorType, string relationshipStatus, FacebookPageTypeAndAction facebookPageTypeAndAction, string additionalFields, int avatarId, int? savedID = null)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                FacebookUserResultDM r = null;
                

                if (fetchAction == "attending" || fetchAction == "unsure" || fetchAction == "declined" || fetchAction == "not_replied")
                {
                    r = facebookBL.GetUsersParticipantsFQLList(facebookUsersParticipantsList, fetchAction, userId, name, participantAnchorType, relationshipStatus, facebookPageTypeAndAction, additionalFields, savedID);
                }
                else if(fetchAction == "members")
                {
                    //r = facebookBL.GetUsersParticipantsYogaList(facebookUsersParticipantsList, fetchAction, userId, name, participantAnchorType, relationshipStatus, facebookPageTypeAndAction, additionalFields, savedID);
                    r = facebookBL.GetGroupParticipantsList(facebookUsersParticipantsList, fetchAction, userId, name, participantAnchorType, relationshipStatus, facebookPageTypeAndAction, additionalFields, savedID);
                }
                else
                {
                    r = facebookBL.GetUsersParticipantsList(facebookUsersParticipantsList, fetchAction, userId, name, participantAnchorType, relationshipStatus, facebookPageTypeAndAction, additionalFields, savedID);
                }
                serverRemoveValues(r);
                return r;
            }
            return null;
        }

        public FacebookContainerDM<FacebookGroupDM> GetUserGroupsList(string token, FacebookUserResultDM facebookUsersParticipantsList, string fetchAction, string userId, string name, string participantAnchorType, string relationshipStatus, FacebookPageTypeAndAction facebookPageTypeAndAction, string additionalFields, int avatarId)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);

                FacebookContainerDM<FacebookGroupDM> r = facebookBL.GetUsersGroupsFQLList(userId, name, participantAnchorType, relationshipStatus, facebookPageTypeAndAction, additionalFields);
                serverRemoveValues(r);
                return r;
            }
            return null;

        }

        public FacebookContainerDM<FacebookPageDM> GetUserPagesList(string token, FacebookUserResultDM facebookUsersParticipantsList, string fetchAction, string userId, string name, string participantAnchorType, string relationshipStatus, FacebookPageTypeAndAction facebookPageTypeAndAction, string additionalFields, int avatarId)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);

                FacebookContainerDM<FacebookPageDM> r = facebookBL.GetUsersPagesFQLList(userId, name, participantAnchorType, relationshipStatus, facebookPageTypeAndAction, additionalFields);
                serverRemoveValues(r);
                return r;
            }
            return null;

        }

        public FacebookContainerDM<FacebookUserEventDM> GetUserEventsList(string token, SearchQueryParam searchQueryParam, int avatarId)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);

                FacebookContainerDM<FacebookUserEventDM> r = facebookBL.GetUserEventsList(searchQueryParam);
                serverRemoveValues(r);
                return r;
            }
            return null;

        }


        public List<FacebookUserDM> GetFacebookUsersInfo(string token, List<string> usersIdsTemp, string fields, int avatarId, int? savedID = null)
        {

            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                List<FacebookUserDM> r = facebookBL.GetFacebookUsersInfo(usersIdsTemp, fields, savedID);
                serverRemoveValues(r);
                return r;
            }

            return null;
        }

        public List<string> ExtractBlockFriends(string token, string sourceUid, string targetUid, int avatarId)
        {

            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                List<string> r = facebookBL.ExtractBlockFriends(sourceUid, targetUid);
                serverRemoveValues(r);
                return r;
            }

            return null;
        }

        public FacebookContainerDM<FacebookEventDM> GetFacebookEvents(string token, SearchQueryParam searchQueryParam, string name, int avatarId)
        {

            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                //FacebookContainerDM<FacebookGroupDM> r = facebookBL.GetFacebookEvents(searchQueryParam,name);
                FacebookContainerDM<FacebookEventDM> r = facebookBL.GetFacebookEventsGraphQL(searchQueryParam);
                serverRemoveValues(r);
                return r;
            }
            return null;

        }
        public FacebookContainerDM<FacebookGroupDM> GetFacebookGroups(string token, SearchQueryParam searchQueryParam, int avatarId)
        {

            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                //FacebookContainerDM<FacebookGroupDM> r = facebookBL.GetFacebookGroups(searchQueryParam);
                FacebookContainerDM<FacebookGroupDM> r = facebookBL.GetFacebookGroupsGraphQL(searchQueryParam);
                //FacebookContainerDM<FacebookGroupDM> r = facebookBL.GetFacebookGroupsUber(searchQueryParam);

                serverRemoveValues(r);
                return r;
            }

            return null;

        }
        public FacebookContainerDM<FacebookUserDM> GetFacebookUsersByName(string token, SearchQueryParam searchQueryParam, int avatarId)
        {

            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {

                InitTokens(avatarId);
                //FacebookContainerDM<FacebookUserDM> r = facebookBL.GetFacebookUsersByName(searchQueryParam);
                FacebookContainerDM<FacebookUserDM> r = facebookBL.GetFacebookUsersGraphQL(searchQueryParam);
                serverRemoveValues(r);
                return r;
            }
            return null;

        }
        public FacebookContainerDM<FacebookPageDM> GetFacebookPages(string token, SearchQueryParam searchQueryParam, int avatarId)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                //FacebookContainerDM<FacebookPageDM> r = facebookBL.GetFacebookPages(searchQueryParam);
                FacebookContainerDM<FacebookPageDM> r = facebookBL.GetFacebookPagesGraphQL(searchQueryParam);

                serverRemoveValues(r);
                return r;
            }
            return null;

        }
        public FacebookContainerDM<FacebookPostDM> GetFacebookPosts(string token, SearchQueryParam searchQueryParam, int avatarId)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                FacebookContainerDM<FacebookPostDM> r = facebookBL.GetFacebookPosts(searchQueryParam);
                serverRemoveValues(r);
                return r;
            }
            return null;
        }

        public FacebookUserDM FriendfinderMobile(string token, string media, int avatarId)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                return facebookBL.FriendfinderMobile(media);
            }
            return null;
        }
        public FacebookUserDM FacebookContactPerson(string token, string media, int avatarId)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                return facebookBL.FacebookContactPerson(media);
            }
            return null;

        }

        public List<FacebookPostDM> GetFacebookPostByUidSequence(string token, SearchQueryParam searchQueryParam, List<string> uidList, int avatarId)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                return facebookBL.GetFacebookPostByUidSequence(searchQueryParam, uidList);
            }
            return null;
        }
        public FacebookContainerDM<FacebookPostDM> GetFacebookPostByUid(string token, SearchQueryParam searchQueryParam, int avatarId)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                FacebookContainerDM<FacebookPostDM> r = facebookBL.GetFacebookPostByUid(searchQueryParam);
                serverRemoveValues(r);
                return r;
            }
            return null;
        }

        public List<FacebookAutoComplateDM> FBAutoComplete(string token, string search, int avatarId)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                return facebookBL.FBAutoComplete(search);
            }
            return null;

        }

        public string WebScopeIDConverter(string token, string ScopeID, int avatarId)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                return facebookBL.WebScopeIDConverter(ScopeID);
            }
            return null;

        }

        public string GetTokenParams(SocialUser user, string token)
        {
            if (token == "getMeInside1")
            {
                return facebookBL.GetEncryptedFacebookLoginHeaders(user);
            }
            else
            {
                return null;
            }
        }

        public string UpdateToken(int id, string accessToken, string token)
        {
            if (token == "getMeInside1")
            {
                return facebookBL.UpdateTokenInformation(id, accessToken);
            }
            else
            {
                return null;
            }
        }

        public FacebookUserDM GetFacebookType(string token, string text, int avatarId)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                return facebookBL.GetFacebookType(text);
            }
            return null;
        }

        public List<FacebookUserDM> CalculateUsersInfo(string token , List<string> usersIds , string fields, int avatarId)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                InitTokens(avatarId);
                List<FacebookUserDM> r = facebookBL.CalculateUsersInfo(usersIds , string.Empty, FacebookPageTypeAndAction.Defualt, null, fields);
                return r;
            }
            return null;
        }

        public List<SavedDatabaseNames> GetSavedUsersNames(string token , string user)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                List<SavedDatabaseNames> r = facebookBL.GetSavedUsersNames(user);
                return r;
            }
            return null;
        }

        public List<FacebookPotentialTargetDM> GetSavedPotentialTargets(string token, string user)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                List<FacebookPotentialTargetDM> r = facebookBL.GetSavedPotentialTargets(user);
                serverRemoveValues(r);
                return r;
            }
            return null;
        }

        public List<FacebookUserDM> GetSavedUsersFromParentIdDB(string token, List<string> parentIds)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                List<FacebookUserDM> r = facebookBL.GetSavedUsersFromParentIdDB(parentIds);
                serverRemoveValues(r);
                return r;
            }

            return null;

        }

        public List<FacebookUserDM> GetSavedUsersFromDB(string token, List<int> IDs)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                List<FacebookUserDM> r = facebookBL.GetSavedUsersFromDB(IDs);
                serverRemoveValues(r);
                return r;
            }

            return null;

        }

        public void DeleteSavedUsersFromDB(string token, List<int> IDs)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                facebookBL.DeleteSavedUsersFromDB(IDs);
            }
        }

        public int SaveUsersIDs(string token, int userId, string userName, string txtSaveName, DateTime date)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                int savedID = facebookBL.SaveUsersIDs(userId, userName, txtSaveName, date);
                //serverRemoveValues(r);
                //return r;
                return savedID;
            }

            return -1;
        }

        public void DeleteUsersIDs(string token, int? savedID)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                facebookBL.DeleteUsersIDs(savedID);
                //serverRemoveValues(r);
                //return r
            }
        }

        public void SaveFacebookUsers(string token, List<FacebookUserDM> facebookResult, int savedID)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                FacebookExport<FacebookUserDM> facebookExport = new FacebookExport<FacebookUserDM>();
                facebookExport.ExportFacebookToDB(facebookResult, "Manual", savedID);
            }
        }

        public void ExportFacebookPostToDB(string token, List<FacebookPostDM> facebookResult)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                FacebookExport<FacebookPostDM> facebookExport = new FacebookExport<FacebookPostDM>();
                facebookExport.ExportFacebookToDB(facebookResult, "Manual");
            }
        }

        public void ExportPotentialUserToDB(string token, List<FacebookPotentialTargetDM> facebookPotentialUser)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                FacebookExport<FacebookPotentialTargetDM> facebookExport = new FacebookExport<FacebookPotentialTargetDM>();
                facebookExport.ExportFacebookToDB(facebookPotentialUser, "Taget");
            }
        }

        public void ExportFacebookPageToDB(string token, List<FacebookPageDM> facebookResult)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                FacebookExport<FacebookPageDM> facebookExport = new FacebookExport<FacebookPageDM>();
                facebookExport.ExportFacebookToDB(facebookResult, "Manual");
            }
        }
        public void ExportFacebookPlaceToDB(string token, List<FacebookPlaceDM> facebookResult)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                FacebookExport<FacebookPlaceDM> facebookExport = new FacebookExport<FacebookPlaceDM>();
                facebookExport.ExportFacebookToDB(facebookResult, "Manual");
            }
        }
        public void ExportFacebookGroupToDB(string token, List<FacebookGroupDM> facebookResult)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                FacebookExport<FacebookGroupDM> facebookExport = new FacebookExport<FacebookGroupDM>();
                facebookExport.ExportFacebookToDB(facebookResult, "Manual");
            }
        }
        public void ExportFacebookEventToDB(string token, List<FacebookEventDM> facebookResult)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                FacebookExport<FacebookEventDM> facebookExport = new FacebookExport<FacebookEventDM>();
                facebookExport.ExportFacebookToDB(facebookResult, "Manual");
            }
        }
        public void ExportFacebookUserToDB(string token, List<FacebookUserDM> facebookResult)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                FacebookExport<FacebookUserDM> facebookExport = new FacebookExport<FacebookUserDM>();
                facebookExport.ExportFacebookToDB(facebookResult, "Manual");
            }
        }

        public CGFacebookService()
        {
            generalServiceClient = new CGGeneralServicesDB.CGGeneralServiceClient();
            //InitTokens();
        }
        private void InitTokens(int avatarId=0)
        {
            try
            {

                SocialUser socialUser = null;
                if (CyberGlobesConst.IsLoaclSocialUserEnabled())
                {
                    socialUser = DatabaseUtils.Instance.GetSocialUser("Facebook", CyberGlobesConst.Company(), avatarId);
                }
                else
                {
                    //TODO: Active
                    socialUser = generalServiceClient?.GetSocialUser("Facebook", CyberGlobesConst.Company(), systemCostantToken, avatarId);
                }

                if (socialUser != null)
                {
                    FacebookSettingHelper.FacebookAccessToken = StringCipher.Decrypt(socialUser.Accesstoken, CyberGlobesConst.CipherPassword);
                    FacebookSettingHelper.FacebookCookie = StringCipher.Decrypt(socialUser.Cookie, CyberGlobesConst.CipherPassword);
                    FacebookSettingHelper.AvatarUid = StringCipher.Decrypt(socialUser.AvatarUid, CyberGlobesConst.CipherPassword);
                    FacebookSettingHelper.AvatarCompany = socialUser.Company;
                    FacebookSettingHelper.AvatarIdDB = socialUser.Id;
                    try
                    {
                        FacebookSettingHelper.AccesstokenSecret = StringCipher.Decrypt(socialUser.AccesstokenSecret, CyberGlobesConst.CipherPassword);

                    }
                    catch (Exception ex)
                    {
                        DatabaseUtils.Instance.WriteToLog("Facebook InitTokens1", ex.Message);
                    }

                }

            }
            catch (Exception ex)
            {
                DatabaseUtils.Instance.WriteToLog("Facebook InitTokens2", ex.Message);
                //throw;
            }

        }

    }
}
