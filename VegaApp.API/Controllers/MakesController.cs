using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VegaApp.API.Data;
using VegaApp.API.Dtos;

namespace VegaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        #region Field
        private readonly IVegaRepository _repo;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public MakesController(IVegaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> GetMakes() 
        {
            var makesFromRepo = await _repo.GetMakeList();

            var makesToReturn = _mapper.Map<IEnumerable<MakeForListDto>>(makesFromRepo);

            return Ok(makesToReturn);
        }

        #endregion
    }
}