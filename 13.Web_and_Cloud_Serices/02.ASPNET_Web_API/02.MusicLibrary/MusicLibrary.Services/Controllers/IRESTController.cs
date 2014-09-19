using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MusicLibrary.Services.Controllers
{
    public interface IRESTController<T>
    {

        IHttpActionResult Get();
        IHttpActionResult Get(int id);
        IHttpActionResult Post([FromBody]T model);
        IHttpActionResult Put([FromBody]T model);
        IHttpActionResult Delete(int id);
    }
}
