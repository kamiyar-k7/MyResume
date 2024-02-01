using Application.DTOs;
using Application.Services.Intefaces;
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
                });
            }
            return model;
        }
    }
}
