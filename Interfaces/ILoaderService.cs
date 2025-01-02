namespace ElderlyCareSupport.Client.Interfaces;

public interface ILoaderService
{
    Task StartLoaderAsync(int delay);
    Task StopLoaderAsync();
}