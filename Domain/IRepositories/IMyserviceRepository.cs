using Domain.Entities._1Information.Myservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IMyserviceRepository
    {
        Task<List<Myservices>> GetMyservicesAsync(CancellationToken cancellationToken);

        Task SaveChanges();

        void Update(Myservices myservices);
        Myservices GetMyserviceById(int ServiceId);
        void Delete(Myservices myservices);
        Task AddService(Myservices service);
    }
}
