using Locato.API.Application.Users.Models;
using Locato.Data.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Locato.API.Application.Users.Queries
{
    public class CheckEmailOrPhoneExistQuery : IRequest<int>
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public class Handler : IRequestHandler<CheckEmailOrPhoneExistQuery, int>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CheckEmailOrPhoneExistQuery request, CancellationToken cancellationToken)
            {
                request.Email = request.Email.ToLower().Trim();
                request.PhoneNumber = request.PhoneNumber.Trim();
                if(await _context.Users.CountAsync(u => u.Email == request.Email,cancellationToken) > 0)
                {
                    return (int) RegisterResult.PHONE_EXISTS;
                }
                if(await _context.Users.CountAsync(u=>u.Phone.RawInput==request.PhoneNumber,cancellationToken) > 0)
                {
                    return (int)RegisterResult.PHONE_EXISTS;
                }

                return (int)RegisterResult.SUCCESS;
            }
        }
    }
}
