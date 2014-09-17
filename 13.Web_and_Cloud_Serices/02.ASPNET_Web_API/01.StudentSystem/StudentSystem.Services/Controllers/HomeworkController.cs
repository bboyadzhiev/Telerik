﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentSystem.Data;
using StudentSystem.Data.Repositories;
using StudentSystem.Models;
using StudentSystem.Services.Models;

namespace StudentSystem.Services.Controllers
{
    public class HomeworkController : ApiController
    {
        private readonly IStudentSystemData data;
        public HomeworkController()
        {
            this.data = new StudentSystemData();
        }

        public HttpResponseMessage Post([FromBody]HomeworkModel homeworkModel)
        {
            var homework = homeworkModel.CreateHomework();
            this.data.Homeworks.Add(homework);

            var message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(this.Request.RequestUri + homework.Id.ToString(CultureInfo.InvariantCulture));
            return message;
        }

        public IQueryable<HomeworkModel> Get()
        {
            var homeworks = this.data.Homeworks.All().Select(HomeworkModel.FromHomeworkCFModel);
            return homeworks;
        }

        public HttpResponseMessage Put([FromBody]HomeworkModel homeworkModel)
        {
            //var homework = this.homeworkData.Get(id);
            var homework = this.data.Homeworks.SearchFor(x => x.Id == homeworkModel.Id).FirstOrDefault();

            if (homework == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Homework not found for update!");
            }

            homeworkModel.UpdateHomework(homework);
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
