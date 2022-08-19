using MagicVilla_WebAPI.Data;
using MagicVilla_WebAPI.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_WebAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : Controller
    {
        // Implementing logging 
        public ILogger<VillaAPIController> _logger { get; }

        public VillaAPIController(ILogger<VillaAPIController> logger)
        {
            _logger = logger;
        }

        // Get all API
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> getVilla()
        {
            _logger.LogInformation("Get all Villa successful");
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
                _logger.LogError("Bad request error to find Villa with id " + id);
                return BadRequest();
            }

            var villa = VillaStore.villa.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                _logger.LogError("Villa with id " + id + " not found error");
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

        // Delete a Villa on basis of id
        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var deletingVilla = VillaStore.villa.FirstOrDefault(u => u.Id == id);
            if (deletingVilla == null)
            {
                return NotFound();
            }
            VillaStore.villa.Remove(deletingVilla);
            return NoContent();
        }

        // Update complete object
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDto)
        {
            if (villaDto == null || id != villaDto.Id)
            {
                return BadRequest();
            }
            var UpdatingVilla = VillaStore.villa.FirstOrDefault(u => u.Id == id);
            UpdatingVilla.Name = villaDto.Name;
            UpdatingVilla.Sqft = villaDto.Sqft;
            UpdatingVilla.Occupancy = villaDto.Occupancy;

            return NoContent();
        }

        // Update single entity of an object
        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UppdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var PatchingVilla = VillaStore.villa.FirstOrDefault(u => u.Id == id);
            if (PatchingVilla == null)
            {
                return NotFound();
            }
            patchDTO.ApplyTo(PatchingVilla, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}