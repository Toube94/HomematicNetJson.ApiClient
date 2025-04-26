using HomematicNetJson.ApiClient.Models;
using HomematicNetJson.ApiClient.Requests.Models;

namespace HomematicNetJson.ApiClient.Requests
{
    public static class RequestFactory
    {
        public static JsonApiRequest CreateLoginRequest(string username, string password)
        {
            JsonApiRequestBuilder builder = new();

            builder
                .SetMethod("Session.login")
                .AddParameter("username", username)
                .AddParameter("password", password);

            return builder.Build();
        }

        public static JsonApiRequest CreateLogoutRequest(string sessionId)
        {
            JsonApiRequestBuilder builder = new();
            builder
                .SetMethod("Session.logout")
                .SetSessionId(sessionId);
            return builder.Build();
        }

        public static JsonApiRequest CreateSessionRenewRequest(string sessionId)
        {
            JsonApiRequestBuilder builder = new();
            builder
                .SetMethod("Session.renew")
                .SetSessionId(sessionId);
            return builder.Build();
        }

        public static JsonApiRequest CreateDeviceListAllDetailRequest(string sessionId)
        {
            JsonApiRequestBuilder builder = new();
            builder
                .SetMethod("Device.listAllDetail")
                .SetSessionId(sessionId);
            return builder.Build();
        }

        public static JsonApiRequest CreateDeviceListAllRequest(string sessionId)
        {
            JsonApiRequestBuilder builder = new();
            builder
                .SetMethod("Device.listAll")
                .SetSessionId(sessionId);
            return builder.Build();
        }

        public static JsonApiRequest CreateInterfaceGetParamsetRequest(string sessionId, string interfaceId, string address, ParamsetKey paramsetKey)
        {
            JsonApiRequestBuilder builder = new();
            builder
                .SetMethod("Interface.getParamset")
                .SetSessionId(sessionId)
                .AddParameter("interface", interfaceId)
                .AddParameter("address", address)
                .AddParameter("paramsetKey", paramsetKey.ToString());
            return builder.Build();
        }

        public static JsonApiRequest CreateGetDeviceRequest(string sessionId, int deviceId)
        {
            JsonApiRequestBuilder builder = new();
            builder
                .SetMethod("Device.get")
                .SetSessionId(sessionId)
                .AddParameter("id", deviceId);
            return builder.Build();
        }

        public static JsonApiRequest CreatePollRequest(string sessionId)
        {
            JsonApiRequestBuilder builder = new();
            builder
                .SetMethod("Event.poll")
                .SetSessionId(sessionId);
            return builder.Build();
        }

        public static JsonApiRequest CreateEventSubscribeRequest(string sessionId)
        {
            JsonApiRequestBuilder builder = new();
            builder
                .SetMethod("Event.subscribe")
                .SetSessionId(sessionId);
            return builder.Build();
        }

        public static JsonApiRequest CreateEventUnsubscribeRequest(string sessionId)
        {
            JsonApiRequestBuilder builder = new();
            builder
                .SetMethod("Event.unsubscribe")
                .SetSessionId(sessionId);
            return builder.Build();
        }

        public static JsonApiRequest CreateInterfaceInitRequest(string sessionId, string interfaceName, string url, string interfaceId)
        {
            JsonApiRequestBuilder builder = new();
            builder
                .SetMethod("Interface.init")
                .SetSessionId(sessionId)
                .AddParameter("interface", interfaceName)
                .AddParameter("url", url)
                .AddParameter("interfaceId", interfaceId);
            return builder.Build();
        }
    }
}
