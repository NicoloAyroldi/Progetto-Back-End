using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caso_Di_Studio.Data;
using Caso_Di_Studio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Caso_Di_Studio.Repository
{
    public class PublishingHRepository : IPublishingHRepository
    {
        private readonly DataContext _context;

        public PublishingHRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PublishingH>> GetAll()
        {
            return await _context.PublishingH.ToListAsync();
        }

        public async Task<PublishingH> GetPublishingHById(int id)
        {
            return await _context.PublishingH.FindAsync(id);
        }

        public async Task<bool> DeletePublishingH(int id)
        {
            var publishingH = await _context.PublishingH.FindAsync(id);
            if (publishingH == null)
            {
                return false;
            }

            _context.PublishingH.Remove(publishingH);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PublishingH> InsertPublishingH(PublishingH publishingH){
            _context.PublishingH.Add(publishingH);
            await _context.SaveChangesAsync();
            return publishingH;
        }

        public async Task<PublishingH> UpdatePublishingH(PublishingH publishingH){
            var publishingHToUpdate = await _context.PublishingH.FindAsync(publishingH.Id);
            if (publishingHToUpdate == null)
            {
                return null;
            }
            
            publishingHToUpdate.Nome = publishingH.Nome;
            publishingHToUpdate.Indirizzo = publishingH.Indirizzo;
            publishingHToUpdate.Citta = publishingH.Citta;
            
            await _context.SaveChangesAsync();
            return publishingHToUpdate;
        }
    }
}