using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BugLogger.Models;

namespace BugLogger.WebApi.Models
{
    public class BugDataModel
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public string Text { get; set; }
        public DateTime LogDate { get; set; }

        public static Expression<Func<Bug, BugDataModel>> FromBug
        {
            get
            {
                return g => new BugDataModel
                {
                    Id = g.Id,
                    Status = g.Status,
                    Text = g.Text,
                    LogDate = g.LogDate
                };
            }
        }
    }
}