using Locato.Data.Entities.UserEntities;
using Locato.Data.Web;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Locato.Data.EntityFramework.Seed
{
    public partial class ApplicationContextSeed
    {
        public async Task SeedPhoto(CancellationToken cancellationToken)
        {
            var photos = new List<Photo>
            {
                new Photo
                {
                    ProfileId = 1,
                    Key = "photo_key_1",
                    MimeType = "image/jpeg",
                    RawBytes = new byte[] { },
                    ThumbnailLargeKey = "thumbnail_large_key_1",
                    ThumbnailLarge = new byte[] { }
                },
                new Photo
                {
                    ProfileId = 2,
                    Key = "photo_key_2",
                    MimeType = "image/png",
                    RawBytes = new byte[] { 26 },
                    ThumbnailLargeKey = "thumbnail_large_key_2",
                    ThumbnailLarge = new byte[] {12 }
                }
            };

            _context.Photos.AddRange(photos);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
