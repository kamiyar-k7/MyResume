using Application.DTOs;
using Application.ViewModel;


namespace Application.Services.Intefaces;

public interface IMyServicesService
{
    Task<List<ServiceViewModel>> GetMyservicesAsync(CancellationToken cancellationToken);


    #region Admin

    Task<MyServiceDto> FillMyServiceDto(int ServiceId);
    Task<bool> UpdateMyService(MyServiceDto model);
    Task AddService(MyServiceDto model);
    Task<bool> DeleteMyService(int ServiceId);
    #endregion
}
