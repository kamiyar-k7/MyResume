using Application.DTOs;
using Application.DTOs.AdminSide;
using Domain.Entities._1Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Intefaces
{
    public interface IUserInformationService
    {
        ShowAllDto GetUserInformation();
        Task<bool> LogIn(AdminLoginDto model);

        #region Admin side
        AdminSideUserDto GetUserInformationAdminSide();
        Task<AdminSideUserDto> FillUserDto(int id, CancellationToken cancellation);
        Task<bool> EditUserDto(AdminSideUserDto model, CancellationToken cancellation);
   
        #endregion
    }
}
