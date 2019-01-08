using System.Collections;
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
    public class FeaturesController : ControllerBase
    {
        #region Fields
        private readonly IVegaRepository _repo;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public FeaturesController(IVegaRepository repo, 
            IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> GetFeatures() {
            var featuresFromRepo = await _repo.GetFeatures();

            var featuresToReturn = _mapper.Map<IEnumerable<FeatureForDetailDto>>(featuresFromRepo);

            return Ok(featuresToReturn);
        }
        #endregion
    }
}