using Xunit;
using AGL.Catlovers.FindMyCatAPI.Repository;

namespace AGL.Catlovers.FindMyCatAPI.Test.RepositoryTests
{
    public class CatsRepositoryTest
    {
        private CatsRepository _catsRepository;
        public CatsRepositoryTest()
        {
            _catsRepository = new CatsRepository();
        }

        [Fact]
        public void Verify_GetCatsByOwnerGender_Content()
        {
            var repoData = _catsRepository.GetCatsByOwnerGender();
            Assert.NotNull(repoData);
            Assert.True(repoData.Result.Count == 2);
            Assert.True(repoData.Result[0].gender.ToLower() == "male");
            Assert.True(repoData.Result[1].gender.ToLower() == "female");
            Assert.True(repoData.Result[0].cats.Count == 4);
            Assert.True(repoData.Result[1].cats.Count == 3);
            Assert.Equal("Garfield", repoData.Result[0].cats[0]);
            Assert.Equal("Tom", repoData.Result[0].cats[3]);
            Assert.Equal("Garfield", repoData.Result[1].cats[0]);
            Assert.Equal("Tabby", repoData.Result[1].cats[2]);
        }
    }
}
