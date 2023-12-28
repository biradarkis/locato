using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locato.Data.Entities.UserEntities;
using Shared.helpers;

namespace Locato.Data.EntityFramework.Seed
{
    partial class ApplicationDbContextSeed
    {
       private async Task SeedPhotos(CancellationToken cancellationToken)
       {
            if (_context.Photos.Count() > 2)
                return;

            var imageUrls = new List<string>()
            {
                "https://www.pexels.com/photo/sepia-toned-image-of-a-woman-wearing-a-skirt-and-blouse-with-ruffles-14755738/",
                "https://www.pexels.com/photo/man-in-blue-denim-jacket-sitting-on-chair-4067753/"
            };

            var profileIds = await _context.Profiles.Select(x => x.Id).ToArrayAsync(cancellationToken);
            for(int i  = 0;i< profileIds.Length;i++)
            {
                var bytearr = await ImageHelpers.ConvertImageToByteArray(imageUrls[i % imageUrls.Count], cancellationToken);
                _context.Photos.Add(new Photo
                {
                    ProfileId = profileIds[i],
                    Key = "photo_key_1",
                    MimeType = "image/jpeg",
                    RawBytes = bytearr,
                    ThumbnailLargeKey = "thumbnail_large_key_1",
                    ThumbnailLarge = bytearr
                });
            }
       }


       

    }
}
