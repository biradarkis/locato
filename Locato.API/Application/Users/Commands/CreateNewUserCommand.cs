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
        public Profile Profile { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string Password { get; set; }

        public long OrganizationId { get; set; }
        public Phone Phone { get; set; }  
        public Photo? Photo { get; set; }
        

        public class Handler : IRequestHandler<CreateNewUserCommand, User>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<User> Handle(CreateNewUserCommand request, CancellationToken cancellationToken)
            {
                if(request.Photo != null)
                {
                    _context.Photos.Add(request.Photo);
                    _context.Profiles.Add(new Profile 
                    {
                    FirstName = request.
                    });
                }
            }
        }
    }
}
