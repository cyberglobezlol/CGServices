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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICGUsecaseService" in both code and config file together.
    [ServiceContract]
    public interface ICGUsecaseService
    {
        [OperationContract]
        CyberGlobes.DAL.UsecaseDataSet.AnalystUserDataTable GetAnalystUserTable(int usecaseId);
        [OperationContract]
        string SetAnalystUserTable(CyberGlobes.DAL.UsecaseDataSet.AnalystUserDataTable data);
        [OperationContract]
        int InsertAnalystUserTable(string UserName, string pass);
        [OperationContract]
        CyberGlobes.DAL.UsecaseDataSet.UsecaseManagerDataTable GetUsecaseManagerTable();
        [OperationContract]
        string SetUsecaseManagerTable(CyberGlobes.DAL.UsecaseDataSet.UsecaseManagerDataTable data);
        [OperationContract]
        int InsertUsecaseManagerTable(string usecaseName, string description, DateTime? dateStart, int priority);
        [OperationContract]
        string InsertAnalystUsecaseConnectionTable(int usecaseId, int ClientUserID, DateTime? connectionDate);
        [OperationContract]
        string SetDocumentsManagerTable(CyberGlobes.DAL.UsecaseDataSet.DocumentManagerDataTable data);
        [OperationContract]
        CyberGlobes.DAL.UsecaseDataSet.DocumentManagerDataTable GetDocumentsManagerTable(int usecaseId);
        [OperationContract]
        string InsertDocumentManagerTable(string documentName, byte[] fileData, string fileName, string extension, int usecaseId);
        [OperationContract]
        string DeleteDocumentManagerTable(int Id);
        [OperationContract]
        DocumentDM GetDocumentManagerByIdTable(int Id);
        [OperationContract]
        string DeleteAnalystUserManagerTable(int Id);
        [OperationContract]
        string DeleteUsecaseManagerTable(int Id);
        [OperationContract]
        int InsertProfileAboutTable(string profileName, string facebookID, string instagramID, string twitterID, string VKID, string linkedinID, string targetDescription, int UsecaseID);
        [OperationContract]
        int InsertWideSearchAboutTable(string searchName, string socialNetwork, string type, string targetDescription, int UsecaseID, string Q, decimal? lat, decimal? lon, int? radius, string unitOfMeasuremen);
        [OperationContract]
        CyberGlobes.DAL.UsecaseDataSet.WideSearchAboutDataTable GetWideSearchAbout(int caseId);
        [OperationContract]
        void UpdateWideSearchAbout(int id, bool alertMode);
        [OperationContract]
        void UpdateDescriptionWideSearchAbout(CyberGlobes.DAL.UsecaseDataSet.WideSearchAboutDataTable data);
        [OperationContract]
        void DeleteWideSearchAbout(int id);

        [OperationContract]
        CyberGlobes.DAL.UsecaseDataSet.ProfileAboutDataTable GetProfilesUserTable(int usecaseId);
        [OperationContract]
        string DeleteProfileManagerTable(int Id);
        [OperationContract]
        string InsertProfileInfoTable(ProfileAboutDM profileAboutDM, int ProfileAboutId);
        //[OperationContract]
        //string ExportFacebookPostToUsecaseDB(List<FacebookPostDM> ListFacebookPostTemp, int ProfileAboutId);

        [OperationContract]
        CyberGlobes.DAL.UsecaseDataSet.CyberglobesClientUsersDataTable GetCyberglobesClientUsersDataTableByCaseId(int usecaseId);
        [OperationContract]
        CyberGlobes.DAL.UsecaseDataSet.CyberglobesClientUsersDataTable GetCyberglobesClientUsersDataTableByOrganzation(string organization, int usecaseId);
        [OperationContract]
        List<FacebookUserDM> GetFacebookUsersFromUsecaseDB(int? ProfileAboutId);

        
        [OperationContract]
        CyberGlobes.DAL.DictionaryWordsForSearchDataSet.DictionaryWordsTableDataTable GetDictionaryWordsEditor(string userName, bool isAdmin);

        [OperationContract]
        void MyUpdate(CyberGlobes.DAL.DictionaryWordsForSearchDataSet.DictionaryWordsTableDataTable dataTable);
        [OperationContract]
        string UpdateDescriptionProfileAboutTable(CyberGlobes.DAL.UsecaseDataSet.ProfileAboutDataTable data);

        [OperationContract]
        CyberGlobes.DAL.alertModeDictionary.AlertModeCategoryDataTable GetAlertModeCategoryRows();

        [OperationContract]
        CyberGlobes.DAL.alertModeDictionary.DictionaryAlertModeDataTable GetDictionaryAlertModeRowsByCategory(string category);

        [OperationContract]
        void UpdateCategoryNames(CyberGlobes.DAL.alertModeDictionary.AlertModeCategoryDataTable dataTable);

        [OperationContract]
        void UpdateWordsInCategory(CyberGlobes.DAL.alertModeDictionary.DictionaryAlertModeDataTable dataTable);

        [OperationContract]
        void DeleteCategryAndWords(string categoryName);
        [OperationContract]
        void InsertWordsInCategory(string word, bool? isSearch, string category);
        [OperationContract]
        void InsertCategoryNames(string category);

        [OperationContract]
        int UpdateProfilesUserTable(int usecaseId, bool InAlertMode);

        [OperationContract]
        Dictionary<int, int> IsNewInfoFromCase(int clientId , int intervalInSec);

        [OperationContract]
        CyberGlobes.DAL.CyberglobesDataSet.TwitterPostDataTable GetTwitterByIds(int caseId, string twitterId);
    }
}
