using MagicVilla_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_WebAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Villa> getVilla()
        {
            List<Villa> villa = new List<Villa>
            {
                new Villa{Id=1,Name="Pool View"},
                new Villa{Id=2,Name="Beach View"},
                new Villa{Id=3,Name="City View"}
            };
            return villa;
        }
    }
}
