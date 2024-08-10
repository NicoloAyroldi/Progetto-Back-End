using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caso_Di_Studio.Entities;
using Caso_Di_Studio.Services;
using Microsoft.AspNetCore.Mvc;

namespace Caso_Di_Studio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublishingHController : ControllerBase
    {
        private readonly IPublishingHService _publishingHService;

        public PublishingHController(IPublishingHService publishingHService)
        {
            _publishingHService = publishingHService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var publishing = await _publishingHService.GetAll();
            return Ok(publishing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _publishingHService.DeletePublishingH(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> InsertPublishingH([FromBody] PublishingH publishingH){
            await _publishingHService.InsertPublishingH(publishingH);
            return Ok(publishingH);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePublishingH(PublishingH publishingH)
        {
            var UpdatePublishingH = await _publishingHService.UpdatePublishingH(publishingH);
            if(UpdatePublishingH == null){
                return NotFound();
            }
            return Ok(UpdatePublishingH);
            
        }
    }

}