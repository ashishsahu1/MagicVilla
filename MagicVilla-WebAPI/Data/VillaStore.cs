using MagicVilla_WebAPI.Models.DTO;

namespace MagicVilla_WebAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villa = new List<VillaDTO>
        {
            new VillaDTO{Id=1,Name="Pool View"},
            new VillaDTO{Id=2,Name="Beach View"},
            new VillaDTO{Id=3,Name="City View"},
            new VillaDTO{Id=3,Name="Night View"}
         };
    }
}
