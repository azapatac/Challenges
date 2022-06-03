using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Challenges.Common.Constants.Settings;
using Challenges.Common.Exceptions.WebServices;
using Challenges.Common.Interfaces.Components.Network;
using Challenges.Common.Interfaces.WebServices.Base;
using Newtonsoft.Json;
using Refit;

namespace Challenges.Infraestructure.WebServices.Base
{
	public class BaseWebService : IBaseWebService
	{
        readonly INetworkComponent _networkComponent;

        protected HttpClient HttpClient { get; set; }

        public BaseWebService(INetworkComponent networkComponent)
        {
            _networkComponent = networkComponent;
        }

        public async Task<ResponseData> ExecuteWebService<ResponseData>(Func<Task<HttpResponseMessage>> endpoint)
		{
			VerifyInternetConnection();
            HttpResponseMessage response = await endpoint();
			ResponseData data = GetServiceResponse<ResponseData>(response);
			return data;
		}

        public T GetServiceResponse<T>(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<T>(jsonString);
                    return result;
                case HttpStatusCode.BadRequest:
                    throw new WebServiceException($"Bad request {response.Content.ReadAsStringAsync().Result}");
                case HttpStatusCode.NotFound:
                    throw new WebServiceException("Not found");
                case HttpStatusCode.InternalServerError:
                    throw new WebServiceException("Internal server error");
                default:
                    throw new Exception();
            }
        }

        public void VerifyInternetConnection()
        {
            if (_networkComponent.IsConnected() == false)
            {
                throw new WebServiceException("No internet connection");
            }
        }

        public void SetHttpClient()
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(GlobalSettings.BASE_URL)
            };
        }

        public virtual Interface GetServiceToExecute<Interface>()
        {
            SetHttpClient();
            return RestService.For<Interface>(HttpClient);
        }
    }
}