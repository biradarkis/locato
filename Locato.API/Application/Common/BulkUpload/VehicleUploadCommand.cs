using Locato.API.Application.Users.Models;
using Locato.Data.Entities.Transport.VehicleEntities;
using Locato.Data.EntityFramework;
using MediatR;
using System.IO;
using OfficeOpenXml;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using Shared.Constants;
using Excel = Microsoft.Office.Interop.Excel;

namespace Locato.API.Application.Common.BulkUpload
{
    public class VehicleUploadCommand :IRequest<DefaultAPIResponse>
    {
        public IFormFile FormFile { get; set; }
        public class VehiclUploadCommandHandler : IRequestHandler<VehicleUploadCommand, DefaultAPIResponse>, IVehicleUpload
        {
            private readonly IApplicationDbContext _context;
            private readonly ILogger _logger;

            public VehiclUploadCommandHandler(IApplicationDbContext context)
            {
                _context = context;
                
            }   

            public async Task<DefaultAPIResponse> Handle(VehicleUploadCommand request, CancellationToken cancellationToken)
            {
                var list = new List<Vehicle>();
                if(!await ValidateFile(request.FormFile))
                {
                    return new DefaultAPIResponse("File Format not valid cross check the number of columns in the excel and standard excel" ,false);
                }
                using var stream = new MemoryStream();
                request.FormFile.CopyTo(stream);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using var package = new ExcelPackage(stream);
                var worksheet = package.Workbook.Worksheets[0];
                var rows = (worksheet.Dimension.End.Row - worksheet.Dimension.Start.Row);
                var cols = (worksheet.Dimension.End.Column - worksheet.Dimension.Start.Column);
                int col = 2;
                for(int i = 2;i< rows; i++)
                {
                    var vehicle = new Vehicle
                    {
                        Name = worksheet.Cells[i,col++].Value.ToString(),
                        RegistrationNumber = worksheet.Cells[i,col++].Value.ToString(),
                        VehicleType = worksheet.Cells[i,col++].Value.ToString(),
                        SeatCapacity = int.Parse(worksheet.Cells[i,col++].Value.ToString()),
                        OwnedByOrg = bool.Parse(worksheet.Cells[i, col++].Value.ToString()),
                        BGV = bool.Parse(worksheet.Cells[i, col++].Value.ToString()),
                        CCTV = bool.Parse(worksheet.Cells[i, col++].Value.ToString()),
                        FireExtinguisher  = bool.Parse(worksheet.Cells[i, col++].Value.ToString()),
                        FirstAidBox = bool.Parse(worksheet.Cells[i, col++].Value.ToString()),
                        OrgId = await GetOrgIdByName(worksheet.Cells[i, col++].Value.ToString()),
                        EngineNumber = worksheet.Cells[i, col++].Value.ToString(),
                        ModelNameAndNumber = worksheet.Cells[i, col++].Value.ToString(),
                        ChassisNumber = worksheet.Cells[i, col++].Value.ToString(),
                        FuelType = worksheet.Cells[i, col++].Value.ToString(),
                    };
                    list.Add(vehicle);
                    col = 2;
                }
                if (await UploadVehicles(list))
                {
                    return new DefaultAPIResponse("" ,true,"successfully uploaded the vehicles");
                } else
                {
                    return new DefaultAPIResponse("Something went wrong", false);
                }
            }


            public async Task<bool> UploadVehicles(IList<Vehicle> vehicles)
            {
                try
                {
                    _context.Vehicles.AddRange(vehicles);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }


            private async Task<long> GetOrgIdByName(string name)
            {
                name  = name.ToLower().Trim();
                var id =_context.Organizations.FirstOrDefault(x=>x.Name.ToLower().Trim()==name)?.Id;
                return id ?? 0;
            }



            public async Task<bool> ValidateFile(IFormFile file)
            {
                using var stream = new MemoryStream();
                file.CopyTo(stream);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using var package = new ExcelPackage(stream);
                var worksheet = package.Workbook.Worksheets[0];
                var rows = (worksheet.Dimension.End.Row - worksheet.Dimension.Start.Row)+1;
                var cols = (worksheet.Dimension.End.Column - worksheet.Dimension.Start.Column)+1;
                if (cols != UtilityConstants.VEHICLE_EXCEL_SHEET_FILED_COUNT)
                {
                    return false;
                }

                for (int i = 2; i <rows; i++)
                {
                    for(int j = 2;j<cols ; j++)
                    {
                        if (worksheet.Cells[i, j].Value == null || string.IsNullOrWhiteSpace(worksheet.Cells[i, j].Value.ToString()))
                        {
                            return false;
                        }
                        if(worksheet.Cells[i, j].Value.ToString().ToUpper() == "YES")
                        {
                            worksheet.Cells[i, j].Value = true;
                        } else if(worksheet.Cells[i, j].Value.ToString().ToUpper() == "NO")
                        {
                            worksheet.Cells[i, j].Value = false;
                        }
                    }    
                }


                return true;
            }
        }
    }
}
