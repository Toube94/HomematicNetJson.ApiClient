
using HomematicNetJson.ApiClient.Requests.Models;

namespace HomematicNetJson.ApiClient.Requests
{
    public class JsonApiRequestBuilder
    {
        JsonApiRequest Request { get; set; } = new ();

        public JsonApiRequestBuilder AddParameter(string key, object value)
        {
            Request.Parameters.Add(key, value);

            return this;
        }

        public JsonApiRequestBuilder SetMethod(string method)
        {
            Request.Method = method;
            return this;
        }

        public JsonApiRequestBuilder SetSessionId(string sessionId)
        {
            Request.Parameters["_session_id_"] = sessionId;
            return this;
        }

        public JsonApiRequest Build()
        {
            return Request;
        }
    }
}
