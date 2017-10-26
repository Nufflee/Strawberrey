using System.IO;
using System.Net;
using System.Threading.Tasks;

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
      HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://localhost:5000/api/version");

      using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
      using (Stream stream = response.GetResponseStream())
      using (StreamReader reader = new StreamReader(stream))
      {
        var c = "";
        for (int i = 0; i < 100; i++)
        {
          c = reader.ReadToEnd();
        }
      }

      return configuration;
    }
  }
}