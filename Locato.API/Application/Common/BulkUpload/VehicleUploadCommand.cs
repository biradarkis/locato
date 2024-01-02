using Locato.API.Application.Users.Models;
using Locato.Data.Entities.Transport.VehicleEntities;
using Locato.Data.EntityFramework;
using MediatR;
using System.IO;
using OfficeOpenXml;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using Shared.Constants;

namespace Locato.API.Application.Common.BulkUpload
{
    public class VehicleUploadCommand :IRequest<DefaultAPIResponse>
    {
        public IFormFile FormFile { get; set; }
        public class VehiclUploadCommandHandler : IRequestHandler<VehicleUploadCommand, DefaultAPIResponse>, IVehicleUpload
        {
            private readonly IApplicationDbContext _context;
            private readonly ILogger<VehicleUploadCommand> _logger;

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
                using var package = new ExcelPackage(stream);
                var worksheet = package.Workbook.Worksheets[0];
                var rows = (worksheet.Dimension.End.Row - worksheet.Dimension.Start.Row);
                var cols = (worksheet.Dimension.End.Column - worksheet.Dimension.Start.Column);
                int col = 2;
                for(int i = 0;i< rows; i++)
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
                        OrgId = long.Parse(worksheet.Cells[i, col++].Value.ToString()),
                        EngineNumber = worksheet.Cells[i, col++].Value.ToString(),
                        ModelNameAndNumber = worksheet.Cells[i, col++].Value.ToString(),
                        ChassisNumber = worksheet.Cells[i, col++].Value.ToString(),
                        FuelType = worksheet.Cells[i, col++].Value.ToString(),
                    };
                }
                if (await UploadVehicles(list))
                {
                    return new DefaultAPIResponse("" ,true,"successfully uploaded the vehicles");
                } else
                {
                    return new DefaultAPIResponse("Something went wrong", true);
                }
            }

            private async Task<bool> UploadVehicles(IList<Vehicle> vehicles)
            {
                try
                {
                    _context.Vehicles.AddRange(vehicles);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {

                    _logger.LogError(e, e.Message);
                    return false;
                }
            }


            private async Task<bool> ValidateFile(IFormFile file)
            {
                using var stream = new MemoryStream();
                file.CopyTo(stream);
                using var package = new ExcelPackage(stream);
                var worksheet = package.Workbook.Worksheets[0];
                var rows = (worksheet.Dimension.End.Row - worksheet.Dimension.Start.Row);
                var cols = (worksheet.Dimension.End.Column - worksheet.Dimension.Start.Column);
                if (cols != UtilityConstants.VEHICLE_EXCEL_SHEET_FILED_COUNT)
                {
                    return false;
                }

                for (int i = 2; i <rows; i++)
                {
                    for(int j = 1;j<cols ; j++)
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
