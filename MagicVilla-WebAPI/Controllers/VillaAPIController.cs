using MagicVilla_WebAPI.Data;
using MagicVilla_WebAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_WebAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        // Get all API
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> getVilla()
        {

            return Ok(VillaStore.villa);
        }

        // Get one data from database
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> getVillaWithId(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = VillaStore.villa.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }

            return Ok(villa);
        }

        // Create New data in VillaDTO
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDto)
        {
            if (villaDto == null)
            {
                return BadRequest(villaDto);
            }
            if (villaDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villaDto.Id = VillaStore.villa.OrderByDescending(u => u.Id).First().Id + 1;
            VillaStore.villa.Add(villaDto);

            return Ok(villaDto);
        }
    }
}
