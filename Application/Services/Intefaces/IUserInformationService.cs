using Application.DTOs;
using Application.DTOs.AdminSide;
using Application.ViewModel;


namespace Application.Services.Intefaces;

public interface IUserInformationService
{
    InformationViewModel GetUserInformation();
    Task<bool> LogIn(AdminLoginDto model);

    #region Admin side
    AdminSideUserDto GetUserInformationAdminSide();
    Task<AdminSideUserDto> FillUserDto(int id, CancellationToken cancellation);
    Task<bool> EditUserDto(AdminSideUserDto model, CancellationToken cancellation);

    #endregion
}
