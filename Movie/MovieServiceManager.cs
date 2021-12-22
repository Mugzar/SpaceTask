using BaseProcessor;
using MovieAPI.Models;

namespace MovieAPI
{
    public class MovieServiceManager : IMovieServiceManager
    {
        private readonly BaseProcessor.ISideService _movieService;
        public MovieServiceManager(BaseProcessor.ISideService service)
        {
            _movieService = service;
        }
        public List<ProviderResponse> getListOfMedia(string searchText) {
            return _movieService.GetAll(searchText);
        }

        public ProviderResponse getMediaInfo(string id)
        {
            return _movieService.GetInfo(id);
        }



    }
}
