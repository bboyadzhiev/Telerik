using System;
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
    public class CoursesController : ApiController
    {
        private readonly IStudentSystemData data;

        public CoursesController()
        {
            this.data = new StudentSystemData();
        }

        public HttpResponseMessage Get(Guid id)
        {
            var course = this.data.Courses.All().Where(x => x.Id == id).Select(CourseModel.FromCourseCFModel).FirstOrDefault();
            if (course == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Course not found!");
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, course);
        }

        public IQueryable<CourseModel> Get()
        {
            var courses = this.data.Courses.All().Select(CourseModel.FromCourseCFModel);
            return courses;
        }

        public HttpResponseMessage Post([FromBody]CourseModel courseModel)
        {
            var course = courseModel.CreateCourse();
            this.data.Courses.Add(course);

            var message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(this.Request.RequestUri + course.Id.ToString());
            return message;
        }

        public HttpResponseMessage Put([FromBody]CourseModel courseModel)
        {
            var course = this.data.Courses.SearchFor(x=>x.Id == courseModel.Id).FirstOrDefault();
            if (course == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Course not found for update!");
            }

            courseModel.UpdateCourse(course);
            return this.Request.CreateResponse(HttpStatusCode.OK, courseModel);
        }

        public HttpResponseMessage Delete(Guid id)
        {
            var course = this.data.Courses.SearchFor(x => x.Id == id).FirstOrDefault();
            if (course == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Course not found for deletion!");
            }
            this.data.Courses.Delete(id);
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
