using Xunit;
using IMDBprocessor;
using MovieAPI;
using Moq;

namespace TestIMDBapi
{
    public class UnitTest1
    {
        //pointless test
        [Fact]
        public void Test1()
        {
            int countMovies = 8;
            Mock<BaseProcessor.ISideService> _mockMovieService = new Mock<BaseProcessor.ISideService>();
            MovieServiceManager proc = new MovieServiceManager(_mockMovieService.Object);
            var result= proc.getListOfMedia("matrix");
            Assert.Equal(countMovies, result.Count);
        }
    }
}