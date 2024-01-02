using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locato.Data.Entities.Business;

namespace Locato.Data.EntityFramework.Seed
{
    partial class ApplicationDbContextSeed
    {
        private async Task SeedOrganizationShifts(CancellationToken cancellationToken)
        {
            if (_context.OrganizationShifts.Count() > 2)
            {
                return;
            }

            var organizations = _context.Organizations.AsNoTracking().ToArray();
            foreach(var organization in organizations)
            {
                _context.OrganizationShifts.Add(new OrganizationShift
                {
                    OrganizationId = organization.Id,
                    From = TimeOnly.FromDateTime(DateTime.UtcNow),
                    To = TimeOnly.FromDateTime(DateTime.UtcNow.AddHours(8)),
                    
                });
                _context.OrganizationShifts.Add(new OrganizationShift
                {
                    OrganizationId = organization.Id,
                    From = TimeOnly.FromDateTime(DateTime.UtcNow.AddHours(8.5)),
                    To = TimeOnly.FromDateTime(DateTime.UtcNow.AddHours(16.5)),
                });
            }

            _context.SaveChanges();
        }
    }
}
