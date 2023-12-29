namespace Locato.API.Application.Users.Models
{
    public class AddUserPhotoRequest
    {
        public string Key { get; set; }

        /// <summary>
        /// Mime type; e.g. image/jpg
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Image binary
        /// </summary>
        public byte[] RawBytes { get; set; }


        public string ThumbnailLargeKey { get; set; }

        /// <summary>
        /// Image binary
        /// </summary>
        public byte[] ThumbnailLarge { get; set; }

    }
}
