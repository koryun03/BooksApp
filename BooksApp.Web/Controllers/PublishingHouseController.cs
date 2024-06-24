using AutoMapper;
using BooksApp.Application.Models.PublishingHouse;
using BooksApp.Application.ServicesInterfaces;
using BooksApp.Domain.Common.Constants;
using BooksApp.Domain.Dto.PublishingHouse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Web.Controllers
{
    public class PublishingHouseController : ApiControllerBase
    {
        private readonly IPublishingHouseService _publishingHouseService;
        private readonly IMapper _mapper;
        public PublishingHouseController(IPublishingHouseService publishingHouseService, IMapper mapper)
        {
            _publishingHouseService = publishingHouseService;
            _mapper = mapper;
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Post(PublishingHouseInsertModel model)
        {
            var dto = _mapper.Map<PublishingHouseInsertDto>(model);
            var id = await _publishingHouseService.AddAsync(dto);
            return Ok(id);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut]
        public async Task<IActionResult> Update(PublishingHouseModel model)
        {
            var dto = _mapper.Map<PublishingHouseDto>(model);
            await _publishingHouseService.UpdateAsync(dto);
            return Ok(dto.Id);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _publishingHouseService.DeleteAsync(id);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllPublishingHouses()
        {
            var ph = await _publishingHouseService.GetAllAsync();
            return Ok(ph);
        }

        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetPublishingHouseById(int id)
        {
            var ph = await _publishingHouseService.GetByIdAsync(id);
            return Ok(ph);
        }
    }
}
