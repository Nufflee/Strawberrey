using Microsoft.AspNetCore.Mvc;

namespace Strawberrey.API
{
  [Route("api/[controller]")]
  public class ConfigurationController : Controller
  {
    [HttpGet]
    public ContentResult Get()
    {
      return Content("{\"version\": \"1.0.0-test2\"}", "application/json");
    }
  }
}