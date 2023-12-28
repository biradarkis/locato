using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared.helpers
{
    public static class ImageHelpers
    {
        public static async Task<byte[]> ConvertImageToByteArray(string url , CancellationToken cancellationToken)
        {
            try
            {
                // Download the image from the URL
                using var webClient = new HttpClient();
                byte[] imageBytes = await webClient.GetByteArrayAsync(url, cancellationToken);
                return imageBytes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting online image to byte array: {ex.Message}");
                return new byte[] {0};
            }
        }
    }
}
