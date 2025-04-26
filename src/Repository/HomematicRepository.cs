using HomematicNetJson.ApiClient.Client;
using HomematicNetJson.ApiClient.Requests;
using HomematicNetJson.ApiClient.Exceptions;
using HomematicNetJson.ApiClient.Models;
using Microsoft.Extensions.Logging;

namespace HomematicNetJson.ApiClient.Repository
{
    public class HomematicRepository(IHomematicClient homematicClient, ILogger<HomematicRepository>? logger = null) : IHomematicRepository
    {
        #region Session
        public async Task<string> LoginAsync(string username, string password)
        {
            var request = RequestFactory.CreateLoginRequest(username, password);
            logger?.LogTrace("Login request: {@Request}", request);

            var result = await homematicClient.SendRequest<string>(request);
            logger?.LogDebug("Login result: {@Result}", result);

            return HandleServerResult(result);
        }

        public async Task<bool> LogoutAsync(string sessionId)
        {
            var request = RequestFactory.CreateLogoutRequest(sessionId);
            logger?.LogTrace("Logout request: {@Request}", request);

            var result = await homematicClient.SendRequest<bool>(request);
            logger?.LogDebug("Logout result: {@Result}", result);

            return HandleServerResult(result);
        }

        public async Task<bool> SessionRenewAsync(string sessionId)
        {
            var request = RequestFactory.CreateSessionRenewRequest(sessionId);
            logger?.LogTrace("SessionRenew request: {@Request}", request);

            var result = await homematicClient.SendRequest<bool>(request);
            logger?.LogDebug("SessionRenew result: {@Result}", result);

            return HandleServerResult(result);
        }
        #endregion

        #region Device
        public async Task<List<DeviceDto>> DeviceListAllDetailAsync(string sessionId)
        {
            var request = RequestFactory.CreateDeviceListAllDetailRequest(sessionId);
            logger?.LogTrace("DeviceListAllDetailAsync request: {@Request}", request);

            var result = await homematicClient.SendRequest<List<DeviceDto>>(request);
            logger?.LogDebug("DeviceListAllDetailAsync result: {@Result}", result);

            return HandleServerResult(result);
        }

        public async Task<DeviceDto> GetDevice(string sessionId, int deviceId)
        {
            var request = RequestFactory.CreateGetDeviceRequest(sessionId, deviceId);
            logger?.LogTrace("GetDevice request: {@Request}", request);

            var result = await homematicClient.SendRequest<DeviceDto>(request);
            logger?.LogDebug("GetDevice result: {@Result}", result);

            return HandleServerResult(result);
        }

        public async Task<int[]> DeviceListAllAsync(string sessionId)
        {
            var request = RequestFactory.CreateDeviceListAllRequest(sessionId);
            logger?.LogTrace("DeviceListAllAsync request: {@Request}", request);

            var result = await homematicClient.SendRequest<int[]>(request);
            logger?.LogDebug("DeviceListAllAsync result: {@Result}", result);

            return HandleServerResult(result);
        }
        #endregion

        #region Event
        public async Task<List<object>> EventPoll(string sessionId)
        {
            var request = RequestFactory.CreatePollRequest(sessionId);
            logger?.LogTrace("EventPoll request: {@Request}", request);

            var result = await homematicClient.SendRequest<List<object>>(request);
            logger?.LogDebug("EventPoll result: {@Result}", result);

            return HandleServerResult(result);
        }

        public async Task<bool> EventSubscribe(string sessionId)
        {
            var request = RequestFactory.CreateEventSubscribeRequest(sessionId);
            logger?.LogTrace("EventSubscribe request: {@Request}", request);

            var result = await homematicClient.SendRequest<bool>(request);
            logger?.LogDebug("EventSubscribe result: {@Result}", result);

            return HandleServerResult(result);
        }
        public async Task<bool> EventUnsubscribe(string sessionId)
        {
            var request = RequestFactory.CreateEventUnsubscribeRequest(sessionId);
            logger?.LogTrace("EventUnsubscribe request: {@Request}", request);

            var result = await homematicClient.SendRequest<bool>(request);
            logger?.LogDebug("EventUnsubscribe result: {@Result}", result);

            return HandleServerResult(result);
        }
        #endregion

        #region Interface
        public async Task<Dictionary<string, object>> InterfaceGetParamsetAsync(string sessionId, string interfaceId, string address, ParamsetKey paramsetKey)
        {
            var request = RequestFactory.CreateInterfaceGetParamsetRequest(sessionId, interfaceId, address, paramsetKey);
            logger?.LogTrace("InterfaceGetParamsetAsync request: {@Request}", request);

            var result = await homematicClient.SendRequest<Dictionary<string, object>>(request);
            logger?.LogDebug("InterfaceGetParamsetAsync result: {@Result}", result);

            return HandleServerResult(result);
        }

        public async Task<bool> InterfaceInitAsync(string sessionId, string interfaceName, string url, string interfaceId)
        {
            var request = RequestFactory.CreateInterfaceInitRequest(sessionId, interfaceName, url, interfaceId);
            logger?.LogTrace("InterfaceInit request: {@Request}", request);

            var result = await homematicClient.SendRequest<bool>(request);
            logger?.LogDebug("InterfaceInit result: {@Result}", result);

            return HandleServerResult(result);
        }
        #endregion

        #region Private
        private T HandleServerResult<T>(JsonApiResult<T> result)
        {
            if (result.Error is not null)
            {
                HandleServerError(result.Error);
            }

            if (result.Result is null)
            {
                logger?.LogWarning("Result from server is null");
                throw new InvalidOperationException("Result from server is null");
            }

            return result.Result;
        }

        private static void HandleServerError(ServerError serverError)
        {
            switch (serverError.Code)
            {
                case > 499:
                    HandleApplicationSpecificErrors(serverError);
                    break;
                case 402:
                    throw new ArgumentNotFoundException(serverError);
                case 400:
                    throw new PrivilegeLevelNotEnoughException(serverError);
                default:
                    throw new ServerException(serverError);
            }
        }

        private static void HandleApplicationSpecificErrors(ServerError serverError)
        {
            if (string.IsNullOrWhiteSpace(serverError.Message))
            {
                throw new ApplicationSpecificErrorException(serverError);
            }

            throw serverError.Message switch
            {
                "invalid credentials or too many sessions" => new InvalidCredentialsOrTooManySessionException(serverError),
                _ => new ApplicationSpecificErrorException(serverError),
            };
        }
        #endregion
    }
}
