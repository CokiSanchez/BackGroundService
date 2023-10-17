namespace HostedService.Models;

public class Alarm
{
    public string Id { get; set; } = new Guid().ToString();
    public string Name { get; set; } = string.Empty;
    public bool Active { get; set; }
    public TimeOnly ActivateAt { get; set; } = default;
}

public class AlarmDto
{
    public string Id { get; set; } = new Guid().ToString();
    public string Name { get; set; } = string.Empty;
    public bool Active { get; set; }
    public string ActivateAt { get; set; } = string.Empty;

    public Alarm Map()
    {
        return new Alarm
        {
            Id = Id,
            Name = Name,
            Active = Active,
            ActivateAt = Helpers.GetTimeOnly(ActivateAt)
        };
    }

}

public static class Helpers
{
    public static TimeOnly GetTimeOnly(string time)
    {
        var result = TimeOnly.TryParse(time, out TimeOnly parsed);
        return result ? parsed : default;
    }
}
