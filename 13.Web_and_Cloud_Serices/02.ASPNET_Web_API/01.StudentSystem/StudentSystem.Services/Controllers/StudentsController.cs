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
    public class StudentsController : ApiController
    {
        //private readonly IRepository<Student, int> studentsData;
        //private readonly IGenericRepository<Student> studentsData;
        private readonly IStudentSystemData data;

        public StudentsController()
        {
            this.data = new StudentSystemData();
        }

        public HttpResponseMessage Get(int id)
        {
            var student = this.data.Students.All().Where(x => x.StudentIdentification == id).Select(StudentModel.FromStudentCFModel).FirstOrDefault();
            if (student == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found!");
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, student);
        }

        public IQueryable<StudentModel> Get()
        {
            var students = this.data.Students.All().Select(StudentModel.FromStudentCFModel);
            return students;
        }

        public HttpResponseMessage Post([FromBody]StudentModel studentModel)
        {
            var student = studentModel.CreateStudent();
            this.data.Students.Add(student);

            var message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(this.Request.RequestUri + student.StudentIdentification.ToString(CultureInfo.InvariantCulture));
            return message;
        }

        


        // public void Put(int id, [FromBody]StudentModel studentModel)
        // {
        //     var student = this.studentsData.Get(id);
        //     studentModel.UpdateStudent(student);
        // }
        public HttpResponseMessage Put([FromBody]StudentModel studentModel)
        {
            var student = this.data.Students.SearchFor(x => x.StudentIdentification == studentModel.Id).FirstOrDefault();
            if (student == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found for update!");
            }

            studentModel.UpdateStudent(student);
            this.data.SaveChanges();
            return this.Request.CreateResponse(HttpStatusCode.OK, student);

        }

        public HttpResponseMessage Delete(int id)
        {
            var student = this.data.Students.SearchFor(x => x.StudentIdentification == id).FirstOrDefault();
            if (student == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found for deletion!");
            }

            this.data.Students.Delete(id);
            this.data.SaveChanges();
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
