using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreApiClient
{
    partial class ApiClient
    {
    }

    private readonly HttpClient httpClient;
    private Uri BaseEndpoint { get; set; }

    public ApiClient(Uri baseEndpoint)
    {
        if (baseEndpoint == null)
        {
            throw new ArgumentNullException("baseEndpoint");
        }
        BaseEndpoint = baseEndpoint;
        _httpClient = new HttpClient();
    }

    private async Task<T> GetAsync<T>(Uri requestUrl)
    {
        var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(data);
    }

    private static JsonSerialiseSettings MicrofostDateFormatSettings
    {
        get
        {
            return new JsonSerialiseSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };
        }
    }

    private HttpContent CreateHttpContent<T>(T content)
    {
        var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
        return new StringContent
    }

}
