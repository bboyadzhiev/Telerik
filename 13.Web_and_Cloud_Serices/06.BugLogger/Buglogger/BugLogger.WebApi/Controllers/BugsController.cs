using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BugLogger.Data;
using BugLogger.Models;
using BugLogger.WebApi.Models;

namespace BugLogger.WebApi.Controllers
{
    [Authorize]
    public class BugsController : BaseApiController
    {
        public BugsController(IBugLoggerData data)
            : base(data)
        {

        }
        public BugsController()
            :this(new BugLoggerData() )
        {

        }

        public IHttpActionResult Get()
        {
            var bugs = this.data.Bugs.All().Select(BugDataModel.FromBug).ToList();
            return Ok(bugs);
        }

        public IHttpActionResult Get([FromUri]DateTime date)
        {
            var bugs = this.data.Bugs.All().Where(b=>b.LogDate == date).Select(BugDataModel.FromBug).ToList();
            return Ok(bugs);
        }

        public IHttpActionResult Get(Status status)
        {                                                  
            var bugs = this.data.Bugs.All().Where(b=>b.Status == status).Select(BugDataModel.FromBug).ToList();
            return Ok(bugs);       
        }
                                                             
        public IHttpActionResult Put(int id, [FromUri]Status status)
        {
            var bug = this.data.Bugs.All().Where(b => b.Id == id).FirstOrDefault();
            bug.Status = status;
            this.data.Bugs.Update(bug);
            this.data.SaveChanges();

            var bugModel = this.data.Bugs.All().Where(b => b.Id == id).Select(BugDataModel.FromBug).FirstOrDefault();
            return Ok(bugModel);
        }

        public IHttpActionResult Post([FromBody]BugDataModel bugModel)
        {
            var bug = new Bug
            {
                Text = bugModel.Text,
                LogDate = DateTime.Now,
                Status = Status.Pending
            };

            this.data.Bugs.Add(bug);
            this.data.SaveChanges();

            var newBugModel = this.data.Bugs.All().Where(b => b.Id == bug.Id).Select(BugDataModel.FromBug);

            return Created(Request.GetRequestContext().VirtualPathRoot, newBugModel);
        }

    }
}
