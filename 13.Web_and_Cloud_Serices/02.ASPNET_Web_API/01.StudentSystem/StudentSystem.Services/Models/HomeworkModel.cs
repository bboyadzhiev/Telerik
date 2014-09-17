using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using StudentSystem.Models;

namespace StudentSystem.Services.Models
{
    public class HomeworkModel
    {
        public int Id { get; set; }

        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }

        public int StudentIdentification { get; set; }

        public Guid CourseId { get; set; }

        public static Expression<Func<Homework, HomeworkModel>> FromHomeworkCFModel
        {
            get
            {
                return x => new HomeworkModel { Id = x.Id, FileUrl = x.FileUrl, TimeSent = x.TimeSent, StudentIdentification = x.StudentIdentification, CourseId = x.CourseId };
            }
        }

        public Homework CreateHomework()
        {
            return new Homework { StudentIdentification = this.StudentIdentification, CourseId = this.CourseId, FileUrl = this.FileUrl, TimeSent = DateTime.Now };
        }

        public void UpdateHomework(Homework homework)
        {
            if (this.StudentIdentification != null)
            {
                homework.StudentIdentification = this.StudentIdentification;
            }
            if (this.CourseId != null)
            {
                homework.CourseId = this.CourseId;
            }
            if (this.FileUrl != null)
            {
                homework.FileUrl = this.FileUrl;
            }
            homework.TimeSent = DateTime.Now;
        }
    }
}