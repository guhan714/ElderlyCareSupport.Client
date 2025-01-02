namespace ElderlyCareSupport.Client.Models;

public class SnackbarModel
{
    public string Message { get; set; } = string.Empty;
    public int Duration { get; set; }
    public string ActionText { get; set; } = string.Empty;
    public Action Action { get; set; } = default!;
}