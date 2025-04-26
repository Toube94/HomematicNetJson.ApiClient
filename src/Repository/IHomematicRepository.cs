using HomematicNetJson.ApiClient.Models;

namespace HomematicNetJson.ApiClient.Repository
{
    public interface IHomematicRepository
    {
        #region Session
        /// <summary>
        /// Login to the Homematic server
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Session Id</returns>
        public Task<string> LoginAsync(string username, string password);
        /// <summary>
        /// Logout from the Homematic server
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public Task<bool> LogoutAsync(string sessionId);
        /// <summary>
        /// Renews the session; if a session is not renewed in time, it expires
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public Task<bool> SessionRenewAsync(string sessionId);
        #endregion
        #region Device
        /// <summary>
        /// Provides detailed information on a device
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public Task<DeviceDto> GetDevice(string sessionId, int deviceId);
        /// <summary>
        /// Provides detailed information on all configured devices
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public Task<List<DeviceDto>> DeviceListAllDetailAsync(string sessionId);
        /// <summary>
        /// Provides a list of all configured devices
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns>Return array of configured device ids</returns>
        public Task<int[]> DeviceListAllAsync(string sessionId);
        #endregion
        #region Event
        public Task<List<object>> EventPoll(string sessionId);
        public Task<bool> EventSubscribe(string sessionId);
        public Task<bool> EventUnsubscribe(string sessionId);
        #endregion
        #region Interface
        /// <summary>
        /// Get the complete paramset of a device
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="interfaceId"></param>
        /// <param name="address"></param>
        /// <param name="paramsetKey"></param>
        /// <returns></returns>
        public Task<Dictionary<string, object>> InterfaceGetParamsetAsync(string sessionId, string interfaceId, string address, ParamsetKey paramsetKey);
        public Task<bool> InterfaceInitAsync(string sessionId, string interfaceName, string url, string interfaceId);
        #endregion
    }
}
