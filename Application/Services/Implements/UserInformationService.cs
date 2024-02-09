using Application.DTOs;
using Application.Services.Intefaces;
using Domain.Entities._1Information;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Application.NAmeGenerator;

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

        #region General
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

        #region Log in 

        public async Task<bool> LogIn(AdminLoginDto model)
        {
            UserInformation userInformation = new UserInformation();


            userInformation.Id = model.Id;
            userInformation.Password = model.Password;

            var admin = await _UserInformationRepository.CheckAdmin(userInformation);

            if (admin == false) { return false; }


            return true;



        }

        #endregion

        #endregion


        #region Admin Side
        public async Task<ShowAllDto> FillUserDto(int id, CancellationToken cancellation)
        {
            #region Get User By Id
            var user = await _UserInformationRepository.GetUserById(id);
            if (user == null) { return null; }
            #endregion

            #region Fill Dto
            ShowAllDto model = new ShowAllDto()
            {
                Id = id,
                UserName = user.UserName,
                TitleDescription = user.TitleDescription,
                Description = user.Description,
                Location = user.Location,
                Email = user.Email,
                MobilePhone = user.MobilePhone,
                PicName = user.Picture,
            };

            #endregion
            return model;
        }
        public async Task<bool> EditUserDto(ShowAllDto model, CancellationToken cancellation)
        {
            #region Get User By Id
            var User = await _UserInformationRepository.GetUserById(model.Id);
            if (User == null) { return false; }
            #endregion

            #region Update

            User.UserName = model.UserName;
            User.TitleDescription = model.TitleDescription;
            User.Description = model.Description;
            User.Email = model.Email;
            User.Location = model.Location;
            User.MobilePhone = model.MobilePhone;
            // User.IsAdmin = true;

            // save new image 

            if (model.pictureFile != null)
            {
                //Save New Image
                User.Picture = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.pictureFile.FileName);

                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/UserAvatar", User.Picture);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    model.pictureFile.CopyTo(stream);
                }
            }



            #endregion

            _UserInformationRepository.Update(User);
            await _UserInformationRepository.Save();

            return true;

        }

        #endregion


    }
}
