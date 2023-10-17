namespace HostedService.BackgroundServices;

using HostedService.Services;
using Microsoft.Extensions.Hosting;

public class Worker : BackgroundService
{
    private readonly IAlarmService _alarmService;

    public Worker(IAlarmService alarmService)
    {
        _alarmService = alarmService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var time = new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute, 0);

            var alarms = await _alarmService.GetAll();

            await Task.WhenAll(alarms.Where(a => a.Active).Select(async a =>
            {
                if (a.ActivateAt.CompareTo(time) == 0)
                    await _alarmService.Sound(a);
            }));

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
