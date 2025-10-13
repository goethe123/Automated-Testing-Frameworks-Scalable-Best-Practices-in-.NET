using log4net;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase1Epam.Core.API
{
    public class BaseApiClient
    {
        private readonly RestClient _Client;
        private static readonly ILog Log = LogManager.GetLogger(typeof(BaseApiClient));

        public BaseApiClient(string baseUrl)
        {
            _Client = new RestClient(baseUrl);
            Log.Info($"[API] BaseApiClient initialized using the base URL: {baseUrl}");
        }

        public async Task <RestResponse> ExecuteAsync(RestRequest request)
        {
            Log.Info($"[API] Sending {request.Method} request to {request.Resource}");
            var response = await _Client.ExecuteAsync(request);
            Log.Info($"[API] Recieved response with status codeee: { response.StatusCode}");
            return response;
        }
    }
}
