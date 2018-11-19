using Microsoft.Rest;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MovieReviewer
{
    public class ApiKeyServiceClientCredentials : ServiceClientCredentials
    {
        private const string SubscriptionKey = "";
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Ocp-Apim-Subscription-Key", SubscriptionKey);
            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }

}
