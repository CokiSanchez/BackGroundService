using HostedService.Models;
using HostedService.Services;
using Microsoft.AspNetCore.Mvc;

namespace HostedService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmsController : ControllerBase
    {
        private readonly IAlarmService _alarmService;

        public AlarmsController(IAlarmService alarmService)
        {
            _alarmService = alarmService;
        }

        [HttpPost]
        public async Task<IActionResult> SetAlarm(AlarmDto alarmDto)
        {
            var alarm = alarmDto.Map();

            await _alarmService.Create(alarm);

            return Ok();
        }
    }
}
