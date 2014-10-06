namespace BullsAndCows.WebApi.Controllers
{
    using System;
    using System.Web;
    using System.Web.Http;
    using BullsAndCows.Data;

    public class BaseApiController : ApiController
    {
        protected IBullsAndCowsData data;

        public BaseApiController(IBullsAndCowsData data)
        {
            this.data = data;
        }
    }
}