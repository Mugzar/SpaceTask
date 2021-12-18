using Xunit;
using IMDBprocessor;

namespace TestIMDBapi
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int countMovies = 8;
            MovieProcessor proc = new MovieProcessor();
            var result= proc.GetAll("matrix");
            Assert.Equal(countMovies, result.Count);
            

        }
    }
}