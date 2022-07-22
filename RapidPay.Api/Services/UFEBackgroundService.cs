using Microsoft.Extensions.Hosting;

namespace RapidPay.Api.Services;

public class UFEBackgroundService : BackgroundService
{
    private static readonly Random Random = new();
    private readonly PeriodicTimer _timer = new(TimeSpan.FromSeconds(1));

    public decimal Fee { get; private set; } = NextFee();

    private static decimal NextFee()
    {
        return NextDecimal(0.0, 2.0);
    }

    private static decimal NextDecimal(double min, double max)
    {
        return (decimal) (Random.NextDouble() * (max - min) + min);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await _timer.WaitForNextTickAsync(stoppingToken) &&
               !stoppingToken.IsCancellationRequested)
            await IncreaseFee();
    }

    private Task IncreaseFee()
    {
        var newFee = Fee * NextFee();
        Console.WriteLine($"Current Fee: {Fee} New Fee {newFee}");
        Fee = newFee;

        return Task.CompletedTask;
    }
}