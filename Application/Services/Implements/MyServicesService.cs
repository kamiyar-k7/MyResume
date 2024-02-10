using Application.DTOs;
using Application.NAmeGenerator;
using Application.Services.Intefaces;
using Domain.Entities._1Information.Myservices;
using Domain.Entities._3Contact;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class MyServicesService : IMyServicesService
    {
        #region ctor
        private readonly IMyserviceRepository _MyserviceRepository;
        public MyServicesService(IMyserviceRepository myserviceRepository)
        {
            _MyserviceRepository = myserviceRepository;
        }
        #endregion

        #region General 
        public async Task<List<MyServiceDto>> GetMyservicesAsync(CancellationToken cancellationToken)
        {
            var services = await _MyserviceRepository.GetMyservicesAsync(cancellationToken);

            List<MyServiceDto> model = new List<MyServiceDto>();
            foreach (var service in services)
            {
                model.Add(new MyServiceDto
                {
                    ServiceId = service.ServiceId,
                    ServiceName = service.ServiceName,
                    ServiceDescription = service.ServiceDescription,
                    ServicePicture = service.ServicePicture,
                });
            }
            return model;
        }
        #endregion

        #region Admin Side
        public async Task<MyServiceDto> FillMyServiceDto(int ServiceId)
        {
            #region Get user By Id 

            var user = _MyserviceRepository.GetMyserviceById(ServiceId);
            if (user == null) { return null; }

            #endregion

            #region Object Mapping 

            MyServiceDto myServiceDto = new MyServiceDto()
            {
                ServiceId = user.ServiceId,
                ServiceName = user.ServiceName,
                ServiceDescription = user.ServiceDescription,
                ServicePicture = user.ServicePicture,

            };
            return myServiceDto;

            #endregion
        }

        public async Task<bool> UpdateMyService(MyServiceDto model)
        {
            #region Get user By Id 

            var user = _MyserviceRepository.GetMyserviceById(model.ServiceId);
            if (user == null) { return false; }

            #endregion

            #region Update service


            user.ServiceName = model.ServiceName;
            user.ServiceDescription = model.ServiceDescription;
            // picture 
            if (model.pictureFile != null)
            {
                //Save New Image
                model.ServicePicture = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.pictureFile.FileName);

                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/ServiceImages", model.ServicePicture);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    model.pictureFile.CopyTo(stream);
                }
                  user.ServicePicture = model.ServicePicture;
            }
          

            #endregion
            _MyserviceRepository.Update(user);
            await _MyserviceRepository.SaveChanges();

            return true;
        }
        #endregion

        #region Add Service
        public async Task AddService(MyServiceDto model)
        {


            // picture 
            if (model.pictureFile != null)
            {
                //Save New Image
                model.ServicePicture = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.pictureFile.FileName);

                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/ServiceImages", model.ServicePicture);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    model.pictureFile.CopyTo(stream);
                }
            }

            Myservices myService = new Myservices()
            {
                ServiceName = model.ServiceName,
                ServiceDescription = model.ServiceDescription,

                ServicePicture = model.ServicePicture,


            };

            await _MyserviceRepository.AddService(myService);
            await _MyserviceRepository.SaveChanges();


        }
        #endregion

        #region Delete Service 
        public async Task<bool> DeleteMyService(int ServiceId)
        {

            var user = _MyserviceRepository.GetMyserviceById(ServiceId);
            if (user == null) { return false; }


            _MyserviceRepository.Delete(user);
            await _MyserviceRepository.SaveChanges();
            return true;
        }
        #endregion


    }
}
