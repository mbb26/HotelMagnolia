using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Ulacit.Mandiola.API.Models;

namespace Ulacit.Mandiola.API.Controllers
{
    /// <summary>A controller for handling base apis.</summary>
    public class BaseApiController : ApiController
    {
        /// <summary>The server watch.</summary>
        private readonly Stopwatch _serverWatch;

        /// <summary>Constructor.</summary>
        public BaseApiController()
            => _serverWatch = new Stopwatch();

        /// <summary>StartServerWatch.</summary>
        private void StartServerWatch()
            => _serverWatch.Start();

        /// <summary>Stops server watch and get elapsed time.</summary>
        /// <returns>A string.</returns>
        private string StopServerWatchAndGetElapsedTime()
        {
            //stop timer
            if (_serverWatch.IsRunning)
                _serverWatch.Stop();

            var ts = _serverWatch.Elapsed;

            // Format and display the TimeSpan value.
            return $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds:00}";
        }

        /// <summary>Gets API result model.</summary>
        /// <exception cref="HttpResponseException">Thrown when a HTTP Response error condition occurs.</exception>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="getItemCallback">The get item callback.</param>
        /// <returns>The API result model.</returns>
        protected ApiResultModel<T> GetApiResultModel<T>(Func<T> getItemCallback)
        {
            var model = new ApiResultModel<T>();
            const HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            try
            {
                StartServerWatch();
                model.Result = getItemCallback();
            }
            catch (Exception ex)
            {
                model.Status = "Fail";
                model.Error = ex;
                model.Time = StopServerWatchAndGetElapsedTime();

                throw new HttpResponseException(Request.CreateResponse(statusCode, model));
            }
            finally
            {
                model.Server = HttpContext.Current.Server.MachineName;
                model.Time = StopServerWatchAndGetElapsedTime();
            }
            return model;
        }
    }
}