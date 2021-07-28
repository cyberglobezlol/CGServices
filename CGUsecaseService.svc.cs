using CyberGlobes.BL.CyberglobesUsecaseCore;
using CyberGlobes.DAL;
using CyberGlobesDM.FacebookDMs;
using CyberGlobesDM.GeneralsDMs;
using CyberGlobesDM.UsecaseDMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CGServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CGUsecaseService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CGUsecaseService.svc or CGUsecaseService.svc.cs at the Solution Explorer and start debugging.
    public class CGUsecaseService : ICGUsecaseService
    {
        UsecaseBL usecaseBL = new UsecaseBL();

        public CyberGlobes.DAL.UsecaseDataSet.CyberglobesClientUsersDataTable GetCyberglobesClientUsersDataTableByCaseId(int usecaseId)
        {
            return usecaseBL.GetClientUsersDataTable(usecaseId);
        }

        public CyberGlobes.DAL.UsecaseDataSet.CyberglobesClientUsersDataTable GetCyberglobesClientUsersDataTableByOrganzation(string organization, int usecaseId)
        {
            return usecaseBL.GetClientUsersDataTable(organization, usecaseId);
        }

        public CyberGlobes.DAL.UsecaseDataSet.AnalystUserDataTable GetAnalystUserTable(int usecaseId)
        {
            return usecaseBL.GetAnalystUserTable(usecaseId);
        }
        public string SetAnalystUserTable(CyberGlobes.DAL.UsecaseDataSet.AnalystUserDataTable data)
        {

            return usecaseBL.SetAnalystUserTable(data);
        }

        public int InsertAnalystUserTable(string UserName, string pass)
        {
            return usecaseBL.InsertAnalystUserTable(UserName, pass);
        }

        public string DeleteAnalystUserManagerTable(int Id)
        {
            return usecaseBL.DeleteAnalystUserTable(Id);
        }

        public CyberGlobes.DAL.UsecaseDataSet.UsecaseManagerDataTable GetUsecaseManagerTable()
        {
            return usecaseBL.GetUsecaseManagerTable();
        }
        public string SetUsecaseManagerTable(CyberGlobes.DAL.UsecaseDataSet.UsecaseManagerDataTable data)
        {

            return usecaseBL.SetUsecaseManagerTable(data);
        }

        public int InsertUsecaseManagerTable(string usecaseName, string description, DateTime? dateStart, int priority)
        {

            return usecaseBL.InsertUsecaseManagerTable(usecaseName, description, dateStart, priority);
        }

        public string InsertAnalystUsecaseConnectionTable(int usecaseId, int ClientUserID, DateTime? connectionDate)
        {

            return usecaseBL.InsertAnalystUsecaseConnectionTable(usecaseId, ClientUserID, connectionDate);
        }

        public string DeleteUsecaseManagerTable(int Id)
        {
            return usecaseBL.DeleteUsecaseManagerTable(Id);
        }

        public CyberGlobes.DAL.UsecaseDataSet.DocumentManagerDataTable GetDocumentsManagerTable(int usecaseId)
        {
            return usecaseBL.GetDocumentsManagerTable(usecaseId);
        }

        public string SetDocumentsManagerTable(CyberGlobes.DAL.UsecaseDataSet.DocumentManagerDataTable data)
        {

            return usecaseBL.SetDocumentsManagerTable(data);
        }

        public string InsertDocumentManagerTable(string documentName, byte[] fileData, string fileName, string extension, int usecaseId)
        {

            return usecaseBL.InsertDocumentManagerTable(documentName, fileData, fileName, extension, usecaseId);
        }

        public string DeleteDocumentManagerTable(int Id)
        {
            return usecaseBL.DeleteDocumentManagerTable(Id);
        }

        public DocumentDM GetDocumentManagerByIdTable(int Id)
        {
            return usecaseBL.GetDocumentManagerByIdTable(Id);
        }

        public int InsertProfileAboutTable(string profileName, string facebookID, string instagramID, string twitterID, string VKID, string linkedinID, string targetDescription, int UsecaseID)
        {
            return usecaseBL.InsertProfileAboutTable(profileName, facebookID, instagramID, twitterID, VKID, linkedinID, targetDescription, UsecaseID);
        }

        public int InsertWideSearchAboutTable(string searchName, string socialNetwork, string type, string targetDescription, int UsecaseID ,string Q, decimal? lat, decimal? lon, int? radius, string unitOfMeasuremen)
        {
            return usecaseBL.InsertWideSearchAboutTable(searchName, socialNetwork, type, targetDescription, UsecaseID ,Q,lat,lon,radius,unitOfMeasuremen);
        }

        public void UpdateWideSearchAbout(int id, bool alertMode)
        {
            usecaseBL.UpdateWideSearchAbout(id, alertMode);
        }

        public UsecaseDataSet.WideSearchAboutDataTable GetWideSearchAbout(int caseId)
        {
            return usecaseBL.GetWideSearchAbout(caseId);
        }


        public void UpdateDescriptionWideSearchAbout(CyberGlobes.DAL.UsecaseDataSet.WideSearchAboutDataTable data)
        {
            usecaseBL.UpdateDescriptionWideSearchAbout(data);
        }


       public void DeleteWideSearchAbout(int id)
        {
            usecaseBL.DeleteWideSearchAbout(id);
        }

        public CyberGlobes.DAL.UsecaseDataSet.ProfileAboutDataTable GetProfilesUserTable(int usecaseId)
        {
            return usecaseBL.GetProfilesUserTable(usecaseId);
        }


        public int UpdateProfilesUserTable(int usecaseId , bool InAlertMode)
        {
            return usecaseBL.UpdateProfilesUserTable(usecaseId, InAlertMode);
        }

        

        public string DeleteProfileManagerTable(int Id)
        {
            return usecaseBL.DeleteProfileManagerTable(Id);
        }

        public string InsertProfileInfoTable(ProfileAboutDM profileAboutDM, int ProfileAboutId)
        {
            return usecaseBL.InsertProfileInfoTable(profileAboutDM, ProfileAboutId);
        }

        //public string ExportFacebookPostToUsecaseDB(List<FacebookPostDM> ListFacebookPostTemp, int ProfileAboutId)
        //{
        //    return usecaseBL.ExportFacebookPostToUsecaseDB(ListFacebookPostTemp, ProfileAboutId);
        //}

        //public CyberGlobes.DAL.CyberglobesDataSet.FacebookUserDataTable GetFacebookUsersFromUsecaseDB(int? ProfileAboutId)
        //{
        //    return usecaseBL.GetFacebookUsersFromUsecaseDB();

        //}

        public List<FacebookUserDM> GetFacebookUsersFromUsecaseDB(int? ProfileAboutId)
        {
            return usecaseBL.GetFacebookUsersFromUsecaseDB(ProfileAboutId);

        }



        public void MyUpdate(DictionaryWordsForSearchDataSet.DictionaryWordsTableDataTable dataTable)
        {
            usecaseBL.MyUpdate(dataTable);
        }



        public DictionaryWordsForSearchDataSet.DictionaryWordsTableDataTable GetDictionaryWordsEditor(string userName, bool isAdmin)
        {
            return usecaseBL.GetDictionaryWordsEditor(userName, isAdmin);

        }

        public string UpdateDescriptionProfileAboutTable(CyberGlobes.DAL.UsecaseDataSet.ProfileAboutDataTable data)
        {
            return usecaseBL.UpdateDescriptionProfileAboutTable(data);
        }

        public CyberGlobes.DAL.alertModeDictionary.AlertModeCategoryDataTable GetAlertModeCategoryRows()
        {

            return usecaseBL.GetAlertModeCategoryRows();

        }


        public CyberGlobes.DAL.alertModeDictionary.DictionaryAlertModeDataTable GetDictionaryAlertModeRowsByCategory(string category)
        {
            return usecaseBL.GetDictionaryAlertModeRowsBycategory(category);
        }



        public void UpdateCategoryNames(alertModeDictionary.AlertModeCategoryDataTable dataTable)
        {
            usecaseBL.UpdateCategoryNames(dataTable);
        }

        public void UpdateWordsInCategory(alertModeDictionary.DictionaryAlertModeDataTable dataTable)
        {
            usecaseBL.UpdateWordsInCategory(dataTable);
        }


       public void InsertCategoryNames(string category)
        {
            usecaseBL.InsertCategoryNames(category);
        }

        public void InsertWordsInCategory(string word, bool? isSearch, string category)
        {
           usecaseBL.InsertWordsInCategory(word, isSearch, category);
        }

        public void DeleteCategryAndWords(string categoryName)
        {
            usecaseBL.DeleteCategryAndWords(categoryName);
        }

        public CyberglobesDataSet.TwitterPostDataTable GetTwitterByIds(int caseId, string twitterId)
        {
            return usecaseBL.GetTwitterByIds(caseId, twitterId);
        }

        public Dictionary<int, int> IsNewInfoFromCase(int clientId, int intervalInSec)
        {
            return usecaseBL.IsNewInfoFromCase(clientId , intervalInSec);
        }


        public void UpdateCategoryToCase(int categoryId, string categoryName, int useCaseId)
        {
            usecaseBL.UpdateCategoryToCase(categoryId, categoryName, useCaseId);
        }
    }
}
