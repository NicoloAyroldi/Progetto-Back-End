using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caso_Di_Studio.Entities;
using Caso_Di_Studio.Repository;

namespace Caso_Di_Studio.Services
{
    public class PublishingHService : IPublishingHService
    {
        private readonly IPublishingHRepository _publishingHRepository;

        public PublishingHService(IPublishingHRepository publishingHRepository)
        {
            _publishingHRepository = publishingHRepository;
        }

        public async Task<IEnumerable<PublishingH>> GetAll()
        {
            return await _publishingHRepository.GetAll();
        }

        public async Task<PublishingH> GetPublishingHById(int id)
        {
            return await _publishingHRepository.GetPublishingHById(id);
        }

        public async Task<bool> DeletePublishingH(int id)
        {
            return await _publishingHRepository.DeletePublishingH(id);
        }

        public async Task<PublishingH> InsertPublishingH(PublishingH publishingH){
            return await _publishingHRepository.InsertPublishingH(publishingH);
        }

        public async Task<PublishingH> UpdatePublishingH(PublishingH publishingH){
            return await _publishingHRepository.UpdatePublishingH(publishingH);
        }
    }
}