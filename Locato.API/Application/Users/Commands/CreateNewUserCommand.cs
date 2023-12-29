using Locato.API.Application.Users.Models;
using Locato.Data.Entities.Business;
using Locato.Data.Entities.UserEntities;
using Locato.Data.EntityFramework;
using Locato.Data.Web;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Locato.API.Application.Users.Commands
{
    public class CreateNewUserCommand : IRequest<User>
    {
        public AddUserProfileRequest Profile { get; set; }
        public AddUserPhotoRequest? Photo { get; set; }

        public string Email { get; set; }

        public int Role { get; set; }

        public string Password { get; set; }

        public long OrganizationId { get; set; }
        public Phone Phone { get; set; }  
        public Location Address { get;set; }
        public string Designation { get; set; }
        public class Handler : IRequestHandler<CreateNewUserCommand, User>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<User> Handle(CreateNewUserCommand request, CancellationToken cancellationToken)
            {
                Photo? photo;
                var profile = new Profile 
                {
                    FirstName = request.Profile.FirstName,
                    LastName = request.Profile.LastName,
                    DateOfBirth =  request.Profile.DateOfBirth,
                    Sex = request.Profile.Sex
                };
                
                await _context.Profiles.AddAsync(profile , cancellationToken);
                _context.SaveChanges();
                //todo --UPLOAD TO OVH
                if(request.Photo != null)
                {
                    photo = new Photo
                    {
                        MimeType = request.Photo.MimeType,
                        Key = request.Photo.Key,
                        ThumbnailLargeKey = request.Photo.ThumbnailLargeKey,
                        RawBytes = Convert.FromBase64String(request.Photo.RawBytes),
                        StorageURL ="",
                        ThumbnailLarge= Convert.FromBase64String(request.Photo.ThumbnailLarge),
                        ProfileId = profile.Id
                    };

                    await _context.Photos.AddAsync(photo, cancellationToken);
                }
                _context.SaveChanges();

                //TODO verify phone if necessary 
                // todo validate commands
                var user = new User(request.Email, request.Phone, request.Role, request.Password, false, request.Address, request.OrganizationId, null, request.Designation)
                {
                    ProfileId = profile.Id
                };

                await _context.Users.AddAsync(user,cancellationToken);
                _context.SaveChanges();
                return user;
            }

        }
    }
}
