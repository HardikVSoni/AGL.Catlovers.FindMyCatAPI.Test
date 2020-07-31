using System.Collections.Generic;

namespace AGL.Catlovers.FindMyCatAPI.Models
{
    public class PetOwners
    {
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public List<Pets> pets { get; set; }
    }
}
