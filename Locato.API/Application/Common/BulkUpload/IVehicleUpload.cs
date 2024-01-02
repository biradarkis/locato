namespace Locato.API.Application.Common.BulkUpload
{
    public interface IVehicleUpload
    {
        Task<bool> UploadVehicles();
    }
}
