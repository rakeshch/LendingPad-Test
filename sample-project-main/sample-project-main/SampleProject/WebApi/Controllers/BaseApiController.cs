using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        public IHttpActionResult Found(object obj)
        {
            return Ok(obj); // built-in Web API 2 method
        }

        public IHttpActionResult Found()
        {
            return Ok(); // Built-in helper for 200 OK
        }

        public IHttpActionResult DoesNotExist()
        {
            return NotFound(); // Built-in Web API 2 method
        }
    }
}