namespace BugLogger.WebApi.Controllers
{
    using System;
    using System.Web;
    using System.Web.Http;
    using BugLogger.Data;

    public class BaseApiController : ApiController
    {
        protected IBugLoggerData data;

        public BaseApiController(IBugLoggerData data)
        {
            this.data = data;
        }
    }
}