using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Intefaces
{
    public interface IMyServicesService
    {
        Task<List<MyServiceDto>> GetMyservicesAsync(CancellationToken cancellationToken);
    }
}
