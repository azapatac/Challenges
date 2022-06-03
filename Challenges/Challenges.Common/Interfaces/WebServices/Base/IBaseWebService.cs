using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Challenges.Common.Interfaces.WebServices.Base
{
    public interface IBaseWebService
	{
		Task<ResponseData> ExecuteWebService<ResponseData>(Func<Task<HttpResponseMessage>> endpoint);
	}
}