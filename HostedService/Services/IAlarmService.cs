using HostedService.Models;

namespace HostedService.Services
{
    public interface IAlarmService
    {
        Task<IEnumerable<Alarm>> GetAll();
        Task<Alarm?> Get(string id);
        Task Create(Alarm alarm);
        Task Update(Alarm alarm);
        Task Delete(Alarm alarm);
        Task Sound(Alarm alarm);
    }
}
