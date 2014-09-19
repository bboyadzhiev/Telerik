using System;
using System.Collections.Generic;
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
    public class SubscriptionController : ApiController
    {
        //private readonly IGenericRepository<Student> studentsData;
        //private readonly IGenericRepository<Course> coursesData;
        private readonly IStudentSystemData data;

        public SubscriptionController()
        {
            this.data = new StudentSystemData();
        }

        /// <summary>
        /// Subscribes a student to a course
        /// </summary>
        /// <param name="studentId">The sudent's id</param>
        /// <param name="courseGuid">The dourse's Guid</param>
        /// <returns></returns>
        public HttpResponseMessage Post(int studentId, Guid courseGuid)
        {
                  
            var student = this.data.Students.All().Where(x => x.StudentIdentification == studentId).FirstOrDefault();
            if (student == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found!");
            }

            var course = this.data.Courses.All().Where(x => x.Id == courseGuid).FirstOrDefault();
            if (course == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Course not found!");
            }
            student.Courses.Add(course);
            //course.Students.Add(student);
            this.data.SaveChanges();
            

            return this.Request.CreateResponse(HttpStatusCode.OK,
                new
                {
                    Subscription = new
                    {
                        Student = student.FirstName + " " + student.LastName,
                        Course = course.Name
                    },
                    Date = DateTime.Now
                });
        }

        /// <summary>
        /// Removes student from a course
        /// </summary>
        /// <param name="studentId">The sudent's id</param>
        /// <param name="courseGuid">The dourse's Guid</param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int studentId, Guid courseGuid)
        {
            var student = this.data.Students.All().Where(x => x.StudentIdentification == studentId).FirstOrDefault();
            if (student == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found!");
            }

            var course = this.data.Courses.All().Where(x => x.Id == courseGuid).FirstOrDefault();
            if (course == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Course not found!");
            }
            if (!student.Courses.Contains(course))
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "The student is not enrolled in this course!");
            }
            student.Courses.Remove(course);
            this.data.SaveChanges();

            return this.Request.CreateResponse(HttpStatusCode.OK,
                new
                {
                    Unsubscription = new
                    {
                        Student = student.FirstName + " " + student.LastName,
                        Course = course.Name
                    },
                    Date = DateTime.Now
                });
        }

    }
}
