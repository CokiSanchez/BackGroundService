using HostedService.Models;

namespace HostedService.Services;

public class AlarmService : IAlarmService
{
    private readonly List<Alarm> _alarms = new()
    {
        new Alarm
        {
            Name = "Test",
            Active = true,
            ActivateAt = new TimeOnly(22, 14, 0, 0),
        }
    };

    public async Task Create(Alarm alarm)
    {
        _alarms.Add(alarm);
        await Task.CompletedTask;
    }

    public async Task Delete(Alarm alarm)
    {
        _alarms.Remove(alarm);
        await Task.CompletedTask;
    }

    public async Task<Alarm?> Get(string id)
    {
        return await Task.FromResult(_alarms.FirstOrDefault(a => a.Id == id));
    }

    public async Task<IEnumerable<Alarm>> GetAll()
    {
        return await Task.FromResult(_alarms.OrderBy(a => a.ActivateAt));
    }

    public async Task Sound(Alarm alarm)
    {
        Console.WriteLine($"{alarm.Name} is happening now!");
        await Task.CompletedTask;
    }

    public async Task Update(Alarm updated)
    {
        var alarm = _alarms.First(a => a.Id == updated.Id);

        _alarms.Remove(alarm);
        _alarms.Add(updated);

        await Task.CompletedTask;
    }
}
