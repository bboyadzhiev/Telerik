using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using StudentSystem.Models;

namespace StudentSystem.Services.Models
{
    public class CourseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public static Expression<Func<Course, CourseModel>> FromCourseCFModel
        {
            get
            {
                return x => new CourseModel { Id = x.Id, Name = x.Name, Description = x.Description };
            }
        }

        internal Course CreateCourse()
        {
            return new Course { Name = this.Name, Description = this.Description };
        }

        internal void UpdateCourse(Course course)
        {
            if (this.Name != null)
            {
                course.Name = this.Name;
            }
            if (this.Description != null)
            {
                course.Description = this.Description;
            }
        }
    }
}