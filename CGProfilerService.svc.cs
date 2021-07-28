using CyberGlobes.BL.CyberGlobesCore;
using CyberGlobes.BL.CyberGlobesEyeconCore;
using CyberGlobes.BL.CyberGlobesFacebookCore;
using CyberGlobes.BL.CyberGlobesFlickrCore;
using CyberGlobes.BL.CyberGlobesInstagramCore;
using CyberGlobes.BL.CyberGlobesLinkedInCore;
using CyberGlobes.BL.CyberGlobesPiplCore;
using CyberGlobes.BL.CyberGlobesProfilerCore;
using CyberGlobes.BL.CyberGlobesSkypeCore;
using CyberGlobes.BL.CyberglobesTruecallerCore;
using CyberGlobes.BL.CyberGlobesWeLeakInfoCore;
using CyberGlobesDM.FacebookDMs;
using CyberGlobesDM.GeneralsDMs;
using CyberGlobesDM.OKDMs;
using CyberGlobesDM.PiplDMs;
using CyberGlobesDM.ProfilerDMs;
using CyberGlobesDM.SkypeDMs;
using CyberGlobesDM.TelegramDMs;
using CyberGlobesDM.TwitterDMs;
using CyberGlobesDM.WeLeakInfoDMs;
using CyberGlobesInfra;
using CyberGlobesInfra.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

namespace CGServices
{
    [KnownType(typeof(Bitmap))]
    public class CGProfilerService : CGParentController, ICGProfilerService
    {
        private CGGeneralServicesDB.CGGeneralServiceClient generalServiceClient;

        ProfilerBL profilerBL = new ProfilerBL();
        WeLeakInfoBL leakInfoBL = new WeLeakInfoBL();
        DatabaseUtils dataUtilsBL = new DatabaseUtils();
        string type1 = "ProfilerLevel1";

        public CGProfilerService()
        {
            InitTokens();
        }
        private void InitTokens()
        {
            try
            {
                SocialUser socialUser = null;
                CGGeneralServicesDB.CGGeneralServiceClient generalServiceClient = null;
                if (!CyberGlobesConst.IsLoaclSocialUserEnabled())
                {
                    generalServiceClient = new CGGeneralServicesDB.CGGeneralServiceClient();
                }

                if (CyberGlobesConst.IsLoaclSocialUserEnabled())
                {
                    socialUser = DatabaseUtils.Instance.GetSocialUser("Facebook", CyberGlobesConst.Company(), 0);
                }
                else
                {

                    socialUser = generalServiceClient?.GetSocialUser("Facebook", CyberGlobesConst.Company(), systemCostantToken, 0);
                }

                if (socialUser != null)
                {
                    FacebookSettingHelper.FacebookAccessToken = StringCipher.Decrypt(socialUser.Accesstoken, CyberGlobesConst.CipherPassword);
                    FacebookSettingHelper.FacebookCookie = StringCipher.Decrypt(socialUser.Cookie, CyberGlobesConst.CipherPassword);
                    FacebookSettingHelper.AvatarUid = StringCipher.Decrypt(socialUser.AvatarUid, CyberGlobesConst.CipherPassword);
                }
                if (CyberGlobesConst.IsLoaclSocialUserEnabled())
                {
                    socialUser = DatabaseUtils.Instance.GetSocialUser("Pipl", CyberGlobesConst.Company(), 0);
                }
                else
                {

                    socialUser = generalServiceClient?.GetSocialUser("Pipl", CyberGlobesConst.Company(), systemCostantToken, 0);
                }
                if (socialUser != null)
                {
                    PiplSettingHelper.PiplAccesstoken = StringCipher.Decrypt(socialUser.Accesstoken, CyberGlobesConst.CipherPassword);
                }

                if (CyberGlobesConst.IsLoaclSocialUserEnabled())
                {
                    socialUser = DatabaseUtils.Instance.GetSocialUser("TrueCaller", CyberGlobesConst.Company(), 0);
                }
                else
                {
                    socialUser = generalServiceClient?.GetSocialUser("TrueCaller", CyberGlobesConst.Company(), systemCostantToken, 0);
                }
                if (socialUser != null)
                {
                    TrueCallerHelper.TrueCallerAccesstoken = StringCipher.Decrypt(socialUser.Accesstoken, CyberGlobesConst.CipherPassword);
                }

                if (CyberGlobesConst.IsLoaclSocialUserEnabled())
                {
                    socialUser = DatabaseUtils.Instance.GetSocialUser("Skype", CyberGlobesConst.Company(), 0);
                }
                else
                {
                    socialUser = generalServiceClient?.GetSocialUser("Skype", CyberGlobesConst.Company(), systemCostantToken, 0);
                }
                if (socialUser != null)
                {
                    SkypeHelper.AccessToken = StringCipher.Decrypt(socialUser.Accesstoken, CyberGlobesConst.CipherPassword);
                    SkypeHelper.RefreshToken = StringCipher.Decrypt(socialUser.AccesstokenSecret, CyberGlobesConst.CipherPassword);
                    SkypeHelper.SkypeToken = StringCipher.Decrypt(socialUser.Cookie, CyberGlobesConst.CipherPassword);
                    SkypeHelper.DatabaseRowId = socialUser.Id;
                }


                if (CyberGlobesConst.IsLoaclSocialUserEnabled())
                {
                    socialUser = DatabaseUtils.Instance.GetSocialUser("Instagram", CyberGlobesConst.Company(), 0);
                }
                else
                {
                    generalServiceClient = new CGGeneralServicesDB.CGGeneralServiceClient();
                    socialUser = generalServiceClient?.GetSocialUser("Instagram", CyberGlobesConst.Company(), systemCostantToken, 0);
                }

                if (socialUser != null)
                {
                    InstagramSettingHelper.InstagramAccessToken = StringCipher.Decrypt(socialUser.Accesstoken, CyberGlobesConst.CipherPassword);
                    InstagramSettingHelper.InstagramCookie = StringCipher.Decrypt(socialUser.Cookie, CyberGlobesConst.CipherPassword);
                    InstagramSettingHelper.AvatarIdDB = socialUser.Id;

                }


                if (CyberGlobesConst.IsLoaclSocialUserEnabled())
                {
                    socialUser = DatabaseUtils.Instance.GetSocialUser("LinkedIn", CyberGlobesConst.Company(), 0);
                }
                else
                {
                    generalServiceClient = new CGGeneralServicesDB.CGGeneralServiceClient();
                    socialUser = generalServiceClient?.GetSocialUser("LinkedIn", CyberGlobesConst.Company(), systemCostantToken, 0);
                }

                if (socialUser != null)
                {
                    LinkedInSettingHelper.LinkedInCookie = StringCipher.Decrypt(socialUser.Cookie, CyberGlobesConst.CipherPassword);
                    LinkedInSettingHelper.AvatarIdDB = socialUser.Id;

                }


                if (CyberGlobesConst.IsLoaclSocialUserEnabled())
                {
                    socialUser = DatabaseUtils.Instance.GetSocialUser("Flickr", CyberGlobesConst.Company(), 0);
                }
                else
                {
                    generalServiceClient = new CGGeneralServicesDB.CGGeneralServiceClient();
                    socialUser = generalServiceClient?.GetSocialUser("Flickr", CyberGlobesConst.Company(), systemCostantToken, 0);
                }

                if (socialUser != null)
                {
                    FlickrSettingHelper.FlickrAccessToken = StringCipher.Decrypt(socialUser.Accesstoken, CyberGlobesConst.CipherPassword);
                    FlickrSettingHelper.AvatarIdDB = socialUser.Id;

                }

                if (CyberGlobesConst.IsLoaclSocialUserEnabled())
                {
                    socialUser = DatabaseUtils.Instance.GetSocialUser("Eyecon", CyberGlobesConst.Company(), 0);
                }
                else
                {
                    generalServiceClient = new CGGeneralServicesDB.CGGeneralServiceClient();
                    socialUser = generalServiceClient?.GetSocialUser("Eyecon", CyberGlobesConst.Company(), systemCostantToken, 0);
                }

                if (socialUser != null)
                {
                    EyeconSettingHelper.EyeconEAuth = StringCipher.Decrypt(socialUser.Accesstoken, CyberGlobesConst.CipherPassword);
                    EyeconSettingHelper.EyeconEAuthV = StringCipher.Decrypt(socialUser.AccesstokenSecret, CyberGlobesConst.CipherPassword);
                    EyeconSettingHelper.EyeconEAuthC = StringCipher.Decrypt(socialUser.Cookie, CyberGlobesConst.CipherPassword);
                    EyeconSettingHelper.AvatarIdDB = socialUser.Id;

                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        //public ProfileAboutDM GetMainProfile(string token, string phoneNumber, string uid)
        //{
        //    if (dataUtilsBL.IsAuthorizeRequest(type1, token))
        //    {
        //        return profilerBL.GetMainProfile(phoneNumber, uid);
        //    }
        //    return null;
        //}

        public ProfileAboutDM GetMainProfile(string token, ProfilerQueryParam profilerQueryParam)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                ProfileAboutDM profileAboutDM = profilerBL.GetMainProfile(profilerQueryParam);

                if (!string.IsNullOrEmpty(profilerQueryParam.PhoneNumber))
                {
                    try
                    {

                       CGEnrichmentServices.ICGEnrichmentService CGEnrichmentService = new CGEnrichmentServices.CGEnrichmentServiceClient();
                        if (CyberGlobesConst.IsInstagramEnabled())
                        {
                            CyberGlobesDM.InstagramDMs.InstagramAddressBookDM instagramAddressBookDM = CGEnrichmentService.InstagramAddressBook(profilerQueryParam.PhoneNumber);
                            ProfilerBL.InstagramAddressBookMerge(profileAboutDM, instagramAddressBookDM);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                //if (!string.IsNullOrEmpty(profileAboutDM.SkypeToken) && !string.IsNullOrEmpty(profileAboutDM.SkypeRefreshToken) && !string.IsNullOrEmpty(profileAboutDM.SkypeAccessToken) && profileAboutDM.SkypeDatabaseRowId != 0)
                //{
                //    if (!CyberGlobesConst.IsLoaclSocialUserEnabled())
                //    {
                //        // generalServiceClient.UpdateSkypeToken(profileAboutDM.SkypeToken, profileAboutDM.SkypeRefreshToken, profileAboutDM.SkypeAccessToken,profileAboutDM.SkypeDatabaseRowId,token);
                //    }
                //    else
                //    {
                //        DatabaseUtils.Instance.UpdateSkypeToken(profileAboutDM.SkypeToken, profileAboutDM.SkypeRefreshToken, profileAboutDM.SkypeAccessToken, profileAboutDM.SkypeDatabaseRowId);
                //    }
                //}
                return profileAboutDM;
            }
            return null;
        }

        public List<LeakDM> GetLeaksProfiles(string token, string target)
        {
            List<LeakDM> outputResults = new List<LeakDM>();

            WeLeakInfoPersonDM result = null;
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {

                CGLeakServices.CGLeakServiceClient leakServiceClient = new CGLeakServices.CGLeakServiceClient();
                result = leakServiceClient.GetLeaksProfiles("", target);


                if (result != null && result.Total > 0 && result.Data != null && result.Data.Length > 0)
                {
                    foreach (var item in result.Data)
                    {
                        LeakDM p = new LeakDM();
                        p.Address = item.Address;
                        p.Database = item.Database;
                        p.DateofBirth = item.DateofBirth;
                        p.Email = item.Email;
                        p.FirstLast = item.FirstLast;
                        p.FirstName = item.FirstName;
                        p.Hash = item.Hash;
                        p.LastIPAddress = item.LastIPAddress;
                        p.Password = item.Password;
                        p.Phone = item.Phone;
                        p.RegisteredIPAddress = item.RegisteredIPAddress;
                        p.Salt = item.Salt;
                        p.Username = item.Username;
                        //p.Origin = "LMI";

                        outputResults.Add(p);
                    }
                }
            }
            return outputResults;
        }

        public string HashDecryptSearch(string token, string hash)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return leakInfoBL.HashSearch(hash);
            }
            return string.Empty;
        }

        public TwitterRecoverResultDM TwitterRecoverByUsername(string token, string search)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return profilerBL.SearchTwitterRecoveryByUsername(search);
            }
            return null;
        }

        public FacebookRecoverDM FacebookRecoverByUsername(string token, string search)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return profilerBL.SearchFacebookRecoveryByUsername(search);
            }
            return null;
        }

        public List<Person> GetPiplProfile(string token, string username, string socialID = null)
        {
            List<Person> outputResult = new List<Person>();

            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                List<PersonExtend> input = profilerBL.GetPiplProfile(username, socialID);

                if (input != null)
                {
                    foreach (var item in input)
                    {
                        Person p = new Person();
                        if (item.Match != null)
                        {
                            p.Match = ((float)item.Match).ToString("P0");   
                        }
                        else
                        {
                            p.Match = "Unknown";
                        }
                        
                        p.AllAddresses = item.AllAddresses;
                        p.AllEducations = item.AllEducations;
                        p.AllEmails = item.AllEmails;
                        p.AllEthnicities = item.AllEthnicities;
                        p.AllJobs = item.AllJobs;
                        p.AllLanguages = item.AllLanguages;
                        p.AllNames = item.AllNames;
                        p.AllOriginCountries = item.AllOriginCountries;
                        p.AllPhones = item.AllPhones;
                        p.AllUrls = item.AllUrls;
                        p.AllUserIDs = item.AllUserIDs;
                        p.AllUsernames = item.AllUsernames;
                        //p.DOB = item.DOB;
                        p.InputString = item.InputString;
                        p.IsPossiblePerson = item.IsPossiblePerson;
                        p.AllRelationships = item.AllRelationships;
                        p.Gender = item.Gender?.ToString();
                        p.ImageUrl = item.ImageUrl;
                        p.DateRange = item.DOB?.DateRange?.ToString();

                        outputResult.Insert(0, p); //reverse order
                        //outputResult.Add(p);
                    }
                }
            }
            return outputResult;
        }

        public SkypeFullResultDM GetSkypeProfile(string token, ProfilerQueryParam profilerQueryParam)
        {
            SkypeFullResultDM skypeFullResultDM = new SkypeFullResultDM();
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                if (!string.IsNullOrEmpty(profilerQueryParam.PhoneNumber) && (ValidateUtils.IsEmailValid(profilerQueryParam.PhoneNumber) && !ValidateUtils.IsValidPhone(profilerQueryParam.PhoneNumber)))
                {
                    if (CyberGlobesConst.IsSkypeEnabled())
                    {
                        CGSkypeServices.CGSkypeServiceClient skypeServiceClient = new CGSkypeServices.CGSkypeServiceClient();
                        skypeFullResultDM = skypeServiceClient.GetSkypeProfiles("", profilerQueryParam.PhoneNumber);
                    }
                }
            }
            return skypeFullResultDM;
        }

        public TelegramPersonDM GetTelegramProfile(string token, ProfilerQueryParam profilerQueryParam)
        {
            TelegramPersonDM telegramResult = new TelegramPersonDM();
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                if (!string.IsNullOrEmpty(profilerQueryParam.PhoneNumber) && ValidateUtils.IsValidPhone(profilerQueryParam.PhoneNumber))
                {
                    if (CyberGlobesConst.IsTelegramEnabled())
                    {
                        CGTelegramServices.CGTelegramServiceClient telegramServiceClient = new CGTelegramServices.CGTelegramServiceClient();
                        telegramResult = telegramServiceClient.GetTelegramProfiles("", profilerQueryParam.PhoneNumber);
                    }
                }
            }
            return telegramResult;
        }

        public OKUserDM GetOKProfile(string token, ProfilerQueryParam profilerQueryParam)
        {
            OKUserDM okUserDMResult = new OKUserDM();
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                if (!string.IsNullOrEmpty(profilerQueryParam.PhoneNumber) && (ValidateUtils.IsValidPhone(profilerQueryParam.PhoneNumber) || ValidateUtils.IsEmailValid(profilerQueryParam.PhoneNumber)))
                {
                    if (CyberGlobesConst.IsSkypeEnabled())
                    {
                        CGOKServices.CGOKServiceClient cGOKServiceClient = new CGOKServices.CGOKServiceClient();
                        okUserDMResult = cGOKServiceClient.GetOKProfiles("", profilerQueryParam.PhoneNumber);
                    }
                }
            }
            return okUserDMResult;
        }

        public MobileLocationDM MobileLocationQuery(string token, string phoneNumber)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return profilerBL.MobileLocationQuery(phoneNumber);
            }
            return null;
        }

        public int MobileLocationRemainingQueryCheck(string token)
        {
            if (dataUtilsBL.IsAuthorizeRequest(type1, token))
            {
                return profilerBL.MobileLocationRemainingQueryCheck();
            }
            return 0;
        }
    }
}
