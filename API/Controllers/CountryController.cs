using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CountryController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CountryController(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            this.unitOfWork = _unitOfWork;
            this.mapper = _mapper;
        }

        //Definiciones HTTP 
        //Get con DTO
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CountryDto>>> Get()
        {
            var countries = await unitOfWork.Countries.GetAllAsync();
            return mapper.Map<List<CountryDto>>(countries);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CountryDto>> Get(int id)
        {
            var country = await unitOfWork.Countries.GetByIdAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return this.mapper.Map<CountryDto>(country);
        }
        //Método POST con DTO
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Country>> Post(CountryDto countryDto)
        {
            var country = this.mapper.Map<Country>(countryDto);
            this.unitOfWork.Countries.Add(country);
            await unitOfWork.SaveAsync();
            if (country == null)
            {
                return BadRequest();
            }
            countryDto.Id = countryDto.Id;
            return CreatedAtAction(nameof(Post), new { id = countryDto.Id }, countryDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CountryDto>> Put(int id, [FromBody]CountryDto countryDto){
            if(countryDto == null)
                return NotFound();
            var country = this.mapper.Map<Country>(countryDto);
            unitOfWork.Countries.Update(country);
            await unitOfWork.SaveAsync();
            return countryDto;
            
        }
    }


}