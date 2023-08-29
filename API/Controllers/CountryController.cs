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
    
    //Definicion HTTP Get
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
    }
}