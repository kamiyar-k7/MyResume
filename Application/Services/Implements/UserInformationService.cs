using Application.DTOs;
using Application.Services.Intefaces;
using Domain.Entities._1Information;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class UserInformationService : IUserInformationService
    {
        #region Ctor
        private readonly IUserInformationRepository _UserInformationRepository;
        public UserInformationService(IUserInformationRepository userInformationRepository)
        {
            _UserInformationRepository = userInformationRepository;
        }

        #endregion


        public ShowAllDto GetUserInformation()
        {

            var user = _UserInformationRepository.GetUserInformation();
            if (user == null)
            {
                return null;
            }
            ShowAllDto dtomodel = new ShowAllDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                TitleDescription = user.TitleDescription,
                Description = user.Description,
                Email = user.Email,
                MobilePhone = user.MobilePhone,
                Location = user.Location,
                PicName = user.Picture,

            };
            return dtomodel;
        }
    }
}
