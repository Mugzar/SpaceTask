using BaseProcessor;

namespace MovieAPI
{
    public interface ISideService
    {
        public List<ProviderResponse> GetAll(string searchText);
        public ProviderResponse GetInfo(string id);

    }
}
