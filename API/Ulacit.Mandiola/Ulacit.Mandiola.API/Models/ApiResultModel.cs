using System;
using Newtonsoft.Json;

namespace Ulacit.Mandiola.API.Models
{
    /// <summary>A data Model for the API result.</summary>
    /// <typeparam name="T">.</typeparam>
    public class ApiResultModel<T> : IApiBaseModel
    {
        /// <summary>ApiResultModel.</summary>
        public ApiResultModel()
        {
            Status = "OK";
        }

        /// <summary>Response Time.</summary>
        /// <value>The time.</value>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Time { get; set; }

        /// <summary>Errors found.</summary>
        /// <value>The error.</value>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Exception Error { get; set; }

        /// <summary>Error message.</summary>
        /// <value>A message describing the error.</value>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; }

        /// <summary>Status Code.</summary>
        /// <value>The status.</value>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <summary>Server which sends the response.</summary>
        /// <value>The server.</value>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Server { get; set; }

        /// <summary>Result showed.</summary>
        /// <value>The result.</value>
        public T Result { get; set; }
    }

    /// <summary>IApiBaseModel.</summary>
    public interface IApiBaseModel
    {
        /// <summary>Response Time.</summary>
        /// <value>The time.</value>
        string Time { get; set; }

        /// <summary>Server response.</summary>
        /// <value>The server.</value>
        string Server { get; set; }

        /// <summary>Error found.</summary>
        /// <value>The error.</value>
        Exception Error { get; set; }
    }
}