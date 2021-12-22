using BaseProcessor;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace IMDBprocessor
{
    public class MovieProcessor : BaseApiProcessor
    {
        private IMDBprocessorConfiguration _apiConfig;
        public MovieProcessor(IOptions<IMDBprocessorConfiguration> options)
        {
            _apiConfig = options.Value;       
        }

        public override List<ProviderResponse> GetAll(string searchText)
        {
            List<ProviderResponse> movies = new List<ProviderResponse>();
            string movieResponse = SendRequest($"{_apiConfig.Host}/SearchMovie/{_apiConfig.ApiKey}/{searchText}");
            IMDBsearchResponse searchResponse =
                JsonConvert.DeserializeObject<IMDBsearchResponse>(movieResponse);
            if (searchResponse.Results == null)
            {
                throw new Exception("Side service returned empty response");
            }
            foreach (ResultItem m in searchResponse.Results)
            {
                //IMDBmovieResponse detailedResponse = GetInfo(m.Id);
                movies.Add(GetInfo(m.Id));
                    
            }
            return movies;
        }
        public override ProviderResponse GetInfo(string title)
        {
            string detailedResponse = SendRequest($"{_apiConfig.Host}/Title/{_apiConfig.ApiKey}/{title}");
            IMDBmovieResponse movieResponse =
                JsonConvert.DeserializeObject<IMDBmovieResponse>(detailedResponse);
            return new ProviderResponse
            {
                Id = movieResponse.Id,
                Name = movieResponse.Title,
                Genre = movieResponse.Genres,
                Author = movieResponse.Directors,
                Rating = movieResponse.ImDbRating,
                Image = movieResponse.Image,
                Description = movieResponse.Plot
            };
        }

        public IMDBmovieResponse GetPoster(string title)
        {
            string response = SendRequest($"{_apiConfig.Host}/Posters/{_apiConfig.ApiKey}/{title}");
            IMDBmovieResponse IMDBmovieResponse =
                JsonConvert.DeserializeObject<IMDBmovieResponse>(response);
            return IMDBmovieResponse;
        }
        public IMDBmovieResponse GetDescription(string title)
        {
            string response = SendRequest($"{_apiConfig.Host}/Wikipedia/{_apiConfig.ApiKey}/{title}");
            IMDBmovieResponse IMDBmovieResponse =
                JsonConvert.DeserializeObject<IMDBmovieResponse>(response);
            return IMDBmovieResponse;
        }




    }
}