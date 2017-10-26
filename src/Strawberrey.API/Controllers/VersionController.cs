using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace Strawberrey.API
{
  [Route("api/[controller]")]
  public class VersionController : Controller
  {
    [HttpGet]
    public HttpResponseMessage Get()
    {
      HttpResponseMessage response = new HttpResponseMessage()
      {
        Content = new StringContent("[{\"version\": \"1.0.0-test2\"}]")
      };

      response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

      return response;
    }
  }
}