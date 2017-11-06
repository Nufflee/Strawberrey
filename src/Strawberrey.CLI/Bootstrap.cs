using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Strawberrey.CLI
{
  public static class Bootstrap
  {
    private static Configuration configuration;

    public static void Init()
    {
    }

    public static async Task StartUp(string[] args)
    {
      configuration = await GetConfiguration();
      new Runner(configuration).Run(args);
    }

    private static async Task<Configuration> GetConfiguration()
    {
      string json;
      
      using (WebClient client = new WebClient())
      {
        json = await client.DownloadStringTaskAsync(new Uri("http://localhost:5000/api/configuration"));
      }

      return JsonConvert.DeserializeObject<Configuration>(json);
    }
  }
}