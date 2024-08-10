using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caso_Di_Studio.Entities;

namespace Caso_Di_Studio.Services
{
    public interface IPublishingHService
    {
        Task<IEnumerable<PublishingH>> GetAll();
        Task<PublishingH> GetPublishingHById(int id);
        Task<bool> DeletePublishingH(int id);
        Task<PublishingH> InsertPublishingH(PublishingH publishingH);
        Task<PublishingH> UpdatePublishingH(PublishingH publishingH);
    }
}