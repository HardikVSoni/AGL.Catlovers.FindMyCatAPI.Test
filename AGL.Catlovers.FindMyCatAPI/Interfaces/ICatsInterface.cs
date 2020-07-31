using AGL.Catlovers.FindMyCatAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGL.Catlovers.FindMyCatAPI.Interfaces
{
    public interface ICatsInterface
    {
        Task<List<CatsResult>> GetCatsByOwnerGender();
        Task<List<CatsResult>> GetCatsByGender(List<PetOwners> petOwners);
    }
}
