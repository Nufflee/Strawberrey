using Newtonsoft.Json;

namespace Strawberrey.CLI
{
  public class Configuration
  {
    [JsonProperty("version")]
    public string Version { get; }

    public Configuration(string version)
    {
      Version = version;
    }
  }
}