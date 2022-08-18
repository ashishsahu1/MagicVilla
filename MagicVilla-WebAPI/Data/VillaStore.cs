using MagicVilla_WebAPI.Models.DTO;

namespace MagicVilla_WebAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villa = new List<VillaDTO>
        {
            new VillaDTO{Id=1,Name="Pool View",Occupancy=4,Sqft = 1024},
            new VillaDTO{Id=2,Name="Beach View",Occupancy=3,Sqft = 950},
            new VillaDTO{Id=3,Name="City View",Occupancy=2,Sqft = 800},
            new VillaDTO{Id=3,Name="Night View",Occupancy=6,Sqft = 2200}
         };
    }
}
