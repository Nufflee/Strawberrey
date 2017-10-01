using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Strawberrey.CLI
{
  public static class Bootstrap
  {
    private static Configuration configuration;

    public static async void Init()
    {
    }

    public static async Task StartUp(string[] args)
    {
      configuration = await GetConfiguration();
      new Runner(configuration).Run(args);
    }

    private static async Task<Configuration> GetConfiguration()
    {
      using (WebClient client = new WebClient())
      {
        string json = await client.DownloadStringTaskAsync(new Uri("https://raw.githubusercontent.com/Nufflee/Strawberrey/master/config.json"));

        return JsonConvert.DeserializeObject<Configuration>(json);
      }
    }
  }
}