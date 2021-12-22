using BaseProcessor;

namespace MovieAPI
{
    public interface IMovieServiceManager
    {
        public List<ProviderResponse> getListOfMedia(string searchText);
        public ProviderResponse getMediaInfo(string id);
    }
}