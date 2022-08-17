using MagicVilla_WebAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_WebAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<VillaDTO> getVilla()
        {
            List<VillaDTO> villa = new List<VillaDTO>
            {
                new VillaDTO{Id=1,Name="Pool View"},
                new VillaDTO{Id=2,Name="Beach View"},
                new VillaDTO{Id=3,Name="City View"},
                new VillaDTO{Id=3,Name="Night View"}
            };
            return villa;
        }
    }
}
