using EldoradoWebApi.Models.Statuses;

namespace EldoradoWebApi.Services;

public interface IStatusService
{
    Task CreateStatus(StatusCreate model);
    Task<IEnumerable<StatusObject>> GetStatuses();
    Task<StatusObject> GetStatusById(int id);
    Task<StatusObject> UpdateStatus(int id, StatusUpdate model);
    Task<StatusObject> DeleteStatus(int id);
}