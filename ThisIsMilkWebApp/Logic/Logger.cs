using ThisIsMilkWebApp.Interfaces;

public class Log : ILog
{
    public async Task WriteAsync(string log)
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"log.txt");
        await File.AppendAllLinesAsync(filePath, new[] { log });
    }
}