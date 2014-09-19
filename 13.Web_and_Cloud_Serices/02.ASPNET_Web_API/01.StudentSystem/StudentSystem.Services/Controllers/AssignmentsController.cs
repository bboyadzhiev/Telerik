using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentSystem.Data;
using StudentSystem.Data.Repositories;

namespace StudentSystem.Services.Controllers
{
    public class AssignmentsController : ApiController
    {
        private readonly IStudentSystemData data;

        public AssignmentsController()
        {
            this.data = new StudentSystemData();
        }

        /// <summary>
        /// Assignes student to trainer
        /// </summary>
        /// <param name="trainerId">The ID of the trainer</param>
        /// <param name="studentId">The ID of the student</param>
        /// <returns>If successful retuns the assignment information</returns>
        public HttpResponseMessage Post(int trainerId, int studentId)
        {
            var trainer = this.data.Students.All().Where(x => x.StudentIdentification == trainerId).FirstOrDefault();
            var student = this.data.Students.All().Where(x => x.StudentIdentification == studentId).FirstOrDefault();
            if (trainer == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Trainer not found!");
            }
            if (student == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found!");
            }

            //trainer.Trainees.Add(student);
            //student.Assistant.StudentIdentification = trainer.StudentIdentification;
            student.Assistant = trainer;
            this.data.Students.SaveChanges();

            return this.Request.CreateResponse(HttpStatusCode.OK,
                new
                {
                    Assignment = new
                    {
                        Trainer = student.Assistant.FirstName + " " + student.Assistant.LastName,
                        Student = student.FirstName + " " + student.LastName
                    }
                });

        }

        /// <summary>
        /// Removes the assignment student to trainer
        /// </summary>
        /// <param name="trainerId">The ID of the trainer</param>
        /// <param name="studentId">The ID of the student</param>
        /// <returns>If successful retuns the un-assignment information</returns>
        public HttpResponseMessage Delete(int trainerId, int studentId)
        {
            var trainer = this.data.Students.All().Where(x => x.StudentIdentification == trainerId).FirstOrDefault();
            if (!trainer.IsAssistant)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Trainer not found!");
            }

            var student = trainer.Trainees.First(x => x.StudentIdentification == studentId);

            if (student == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "The student assigned to that trainer was not found!");
            }

            student.Assistant = null;
            this.data.Students.SaveChanges();

            return this.Request.CreateResponse(HttpStatusCode.OK,
                new
                {
                    Unassignment = new
                    {
                        Trainer = trainer.FirstName + " " + trainer.LastName,
                        Student = student.FirstName + " " + student.LastName
                    }
                });
        }
    }
}
