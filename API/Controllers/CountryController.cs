using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CountryController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
    public CountryController(IUnitOfWork _unitOfWork)
    {
        this.unitOfWork = _unitOfWork;
    }
    
    //Definiciones HTTP 
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Country>>> Get()
    {
        var countries = await unitOfWork.Countries.GetAllAsync();
        return Ok(countries);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Get(int id)
    {
        var country = await unitOfWork.Countries.GetByIdAsync(id);
        return Ok(country);
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