using MagicVilla_WebAPI.Data;
using MagicVilla_WebAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_WebAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> getVilla()
        {

            return Ok(VillaStore.villa);
        }

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
    }
}
