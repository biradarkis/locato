using Locato.Data.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Services.Interfaces
{
    public interface IJwtHandler
    {
        string GenerateJwtToken( User user, int expiresInHours = 12);
        string GenerateJwtRefreshToken(User user, int expiresInHours = 720);
    }
}
