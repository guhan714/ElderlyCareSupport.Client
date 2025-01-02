using CurrieTechnologies.Razor.SweetAlert2;

namespace ElderlyCareSupport.Client.Interfaces;

public interface IAlertService<in TMethod, in TData>
{
    Task AlertAsync(TMethod? alertOptions, TData? alertData);
}