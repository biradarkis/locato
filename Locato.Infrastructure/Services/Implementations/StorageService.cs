//using Locato.Infrastructure.Services.Interfaces;
//using Microsoft.Extensions.Logging;
//using Shared.helpers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Shared.helpers;

//namespace Locato.Infrastructure.Services.Implementations
//{
//    public class StorageService : IStorageService
//    {
//      private readonly  ILogger _logger;
//        private readonly AppSettings _appSettings;
//        static string Token;// = ConfigurationManager.AppSettings.Get("OVHStorageToken");
//        static string ObjectStoreUrl;  
//        static string AuthDomain ;
//        static string AuthPassword;
//        static string AuthName ;
//        static string AuthUrl ;
//        public StorageService(ILogger logger, AppSettings appSettings)
//        {
//            _logger = logger;
//            _appSettings = appSettings;
//            ObjectStoreUrl = _appSettings.OVHStorageUrl;
//            AuthDomain = _appSettings.AuthDomain;
//            AuthPassword = _appSettings.AuthPassword;
//            AuthName = _appSettings.AuthName;
//            AuthUrl = _appSettings.AuthUrl;

//        }
//        public string GetAccountSASToken()
//        {
            
//        }

//        public Task<string> GetAccountSASTokenAsync()
//        {
            
//        }

//        public string GetFile(string path, string containerName)
//        {
            
//        }

//        public string UploadFile(byte[] fileContent, string fileName, List<KeyValuePair<string, string>> metadata, string table, string containerName, string mimeType = "")
//        {
            
//        }

//        public Task<string> UploadFileAsync(byte[] fileContent, string fileName, List<KeyValuePair<string, string>> metadata, string table, string containerName, string mimeType = "")
//        {
            
//        }
//    }
//}
