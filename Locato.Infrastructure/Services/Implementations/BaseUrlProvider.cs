using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class HTTPContextBaseUrlProvider : IBaseUrlProvider
    {
        public readonly string _applicationPath;
        public readonly Uri _uri;
        public HTTPContextBaseUrlProvider(Uri uri, string applicationPath)
        {
            _uri = uri;
            _applicationPath = applicationPath;
        }
        public string GetBaseUrl()
        {
            var appPath = string.Empty;

            //Checking the current context content
            if (_uri != null)
            {
                //Formatting the fully qualified website url/name
                appPath =
                    $"{_uri.Scheme}://{_uri.Host}{(_uri.Port == 80 ? string.Empty : ":" + _uri.Port)}{_applicationPath}";
            }

            return appPath.TrimEnd('/');
        }
    }
}
