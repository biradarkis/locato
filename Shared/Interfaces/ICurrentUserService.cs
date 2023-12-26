using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface ICurrentUserService
    {
        bool IsLoggedIn { get; }
        long UserId { get; }
        long OrganizationId { get; }
        int Role { get; }
    }
}
