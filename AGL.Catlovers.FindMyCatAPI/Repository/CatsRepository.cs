using AGL.Catlovers.FindMyCatAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AGL.Catlovers.FindMyCatAPI.Interfaces;

namespace AGL.Catlovers.FindMyCatAPI.Repository
{
    public class CatsRepository : ICatsInterface
    {
        private const string _catString = "Cat";

        public async Task<List<CatsResult>> GetCatsByOwnerGender()
        { 
            List<PetOwners> jsonData = await ReadJsonAsync();
            return await FilterCatWithOwnerGender(jsonData);
        }

        public async Task<List<CatsResult>> GetCatsByGender(List<PetOwners> petOwners)
        {
            return  await FilterCatWithOwnerGender(petOwners);
        }

        private async Task<List<PetOwners>> ReadJsonAsync()
        {
            using (HttpClient jsonReaderWc = new HttpClient())
            {
                var result = await jsonReaderWc.GetStringAsync("http://agl-developer-test.azurewebsites.net/people.json");
                return JsonConvert.DeserializeObject<List<PetOwners>>(result);
            }
        }

        private async Task<List<CatsResult>> FilterCatWithOwnerGender(List<PetOwners> petOwners)
        {
            List<CatsResult> catsResult = new List<CatsResult>();
            foreach (var item in petOwners)
            {
                catsResult.Add(new CatsResult {
                    gender = item.gender,
                    cats = item.pets?.OrderBy(x => x.name).Where(x => x.type == _catString)?.Select(x => x.name).ToList()
                });
            }

            catsResult = catsResult.Where(x => x.cats != null).OrderBy(x => x.cats.FirstOrDefault()).ToList();

            List<CatsResult> sortedCatsResult = new List<CatsResult>();
            foreach (var gender in catsResult.Select(x => x.gender).Distinct())
            {
                CatsResult catsRes = new CatsResult
                {
                    gender = gender,
                    cats = new List<string>()
                };
                foreach (var cats in catsResult.Where(x => x.gender == gender).Select(x => x.cats))
                {
                    catsRes.cats.AddRange(cats);
                }
                sortedCatsResult.Add(catsRes);
            }

            return await Task.FromResult(sortedCatsResult);
        }
    }
}
