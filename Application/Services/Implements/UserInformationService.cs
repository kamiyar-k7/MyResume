﻿using Application.DTOs;
using Application.Services.Intefaces;
using Domain.Entities._1Information;
using Domain.IRepositories;
using Application.NAmeGenerator;
using Application.DTOs.AdminSide;
using Application.ViewModel;


namespace Application.Services.Implements;

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
    public InformationViewModel GetUserInformation()
    {

        var user = _UserInformationRepository.GetUserInformation();
     

        InformationViewModel model = new InformationViewModel()
        {
            Id = user.Id,
            UserName = user.UserName,
            TitleDescription = user.TitleDescription,
            Description = user.Description,
            Email = user.Email,
            MobilePhone = user.MobilePhone,
            Location = user.Location,
            PicName = user.Picture,
            ResumeName = user.Resume,

        };
        return model;

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

    #region Get User Information
    public  AdminSideUserDto GetUserInformationAdminSide()
    {
        
        var user = _UserInformationRepository.GetUserInformationAdminSide();
        if(user == null) { return null;}

        AdminSideUserDto userDto = new AdminSideUserDto()
        {
            Id = user.Id,
            UserName = user.UserName,
            Password = user.Password,
            TitleDescription = user.TitleDescription,
            Description = user.Description,
            Email = user.Email,
            MobilePhone = user.MobilePhone,
            Location = user.Location,
            PicName = user.Picture,
        };
        return userDto;

    }
    #endregion

    public async Task<AdminSideUserDto> FillUserDto(int id, CancellationToken cancellation)
    {
        #region Get User By Id
        var user = await _UserInformationRepository.GetUserById(id);
        if (user == null) { return null; }
        #endregion

        #region Fill Dto
        AdminSideUserDto model = new AdminSideUserDto()
        {
            Id = id,
            UserName = user.UserName,
            Password = user.Password,
            TitleDescription = user.TitleDescription,
            Description = user.Description,
            Location = user.Location,
            Email = user.Email,
            MobilePhone = user.MobilePhone,
            PicName = user.Picture,
            ResumeName = user.Resume,
        };

        #endregion
        return model;
    }
    public async Task<bool> EditUserDto(AdminSideUserDto model, CancellationToken cancellation)
    {
        #region Get User By Id
        var User = await _UserInformationRepository.GetUserById(model.Id);
        if (User == null) { return false; }
        #endregion

        #region Update

        User.UserName = model.UserName;
        User.Password = model.Password;
        User.TitleDescription = model.TitleDescription;
        User.Description = model.Description;
        User.Email = model.Email;
        User.Location = model.Location;
        User.MobilePhone = model.MobilePhone;
       

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

        // save new Resume 

        if (model.ResumeFile != null)
        {

            if(User.Resume != null)
            { 
                    string oldresume = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ResumeFile", User.Resume);
                    if (File.Exists(oldresume))
                    {
                        File.Delete(oldresume);
                    }
            }

            //Save New Resume
            model.ResumeName = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.ResumeFile.FileName);

            string Filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ResumeFile", model.ResumeName);
            using (var stream = new FileStream(Filepath, FileMode.Create))
            {
                model.ResumeFile.CopyTo(stream);
            }
            User.Resume = model.ResumeName;
        }

        #endregion

        _UserInformationRepository.Update(User);
        await _UserInformationRepository.Save();

        return true;

    }

    #endregion


}
