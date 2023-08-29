using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
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
        if (country == null){
            return NotFound();
        }
        return this.mapper.Map<CountryDto>(country);    
    }

    [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <ActionResult<Country>> Post(Country country)
        {
            unitOfWork.Countries.Add(country);
            await unitOfWork.SaveAsync();
            if(country == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new {id = country.Id}, country);
        }
    }
}