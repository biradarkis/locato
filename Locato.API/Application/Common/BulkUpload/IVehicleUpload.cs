using Locato.Data.Entities.Transport.VehicleEntities;

namespace Locato.API.Application.Common.BulkUpload
{
    public interface IVehicleUpload
    {
       Task<bool> UploadVehicles(IList<Vehicle> vehicles);
    }
}
