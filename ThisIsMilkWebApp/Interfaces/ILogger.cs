namespace ThisIsMilkWebApp.Interfaces
{
    public interface ILog
    {
        Task WriteAsync(string log);
    }
}