using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Infrastructure.Services.Interfaces
{
    public interface IStorageService
    {
        string UploadFile(byte[] fileContent, string fileName, List<KeyValuePair<string, string>> metadata, string table, string containerName, string mimeType = "");
        string GetAccountSASToken();
        string GetFile(string path, string containerName);
        Task<string> UploadFileAsync(byte[] fileContent, string fileName, List<KeyValuePair<string, string>> metadata, string table, string containerName, string mimeType = "");
        Task<string> GetAccountSASTokenAsync();
    }
}
