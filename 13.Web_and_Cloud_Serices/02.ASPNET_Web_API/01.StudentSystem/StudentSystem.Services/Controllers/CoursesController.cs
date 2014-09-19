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

        /// <summary>
        /// Returns a course with the specified Guid
        /// </summary>
        /// <param name="guid">The Guid of the course</param>
        /// <returns>The found course</returns>
        public HttpResponseMessage Get(Guid guid)
        {
            var course = this.data.Courses.All().Where(x => x.Id == guid).Select(CourseModel.FromCourseCFModel).FirstOrDefault();
            if (course == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Course not found!");
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, course);
        }

        /// <summary>
        /// Gets all the courses
        /// </summary>
        /// <returns>All the courses</returns>
        public IQueryable<CourseModel> Get()
        {
            var courses = this.data.Courses.All().Select(CourseModel.FromCourseCFModel);
            return courses;
        }

        /// <summary>
        /// Creates a new course
        /// </summary>
        /// <param name="courseModel">The course data</param>
        /// <returns>Appropriate message</returns>
        public HttpResponseMessage Post([FromBody]CourseModel courseModel)
        {
            var course = courseModel.CreateCourse();
            this.data.Courses.Add(course);
            this.data.SaveChanges();

            var message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(this.Request.RequestUri + course.Id.ToString());
            return message;
        }

        /// <summary>
        /// Updates a course info
        /// </summary>
        /// <param name="courseModel">The course that is to be updated</param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromBody]CourseModel courseModel)
        {
            var course = this.data.Courses.SearchFor(x=>x.Id == courseModel.Id).FirstOrDefault();
            if (course == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Course not found for update!");
            }

            courseModel.UpdateCourse(course);
            this.data.SaveChanges();

            return this.Request.CreateResponse(HttpStatusCode.OK, courseModel);
        }

        /// <summary>
        /// Removes a course by supplied Guid
        /// </summary>
        /// <param name="guid">The guid of the course that is </param>
        /// <returns></returns>
        public HttpResponseMessage Delete(Guid guid)
        {
            var course = this.data.Courses.SearchFor(x => x.Id == guid).FirstOrDefault();
            if (course == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Course not found for deletion!");
            }
            this.data.Courses.Delete(guid);
            this.data.SaveChanges();
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
