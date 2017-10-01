using System.Threading.Tasks;

namespace Strawberrey.CLI
{
  public class Program
  {
    private static void Main(string[] args)
    {
      MainAsync(args).Wait();
    }

    private static async Task MainAsync(string[] args)
    {
      Bootstrap.Init();
      await Bootstrap.StartUp(args);
    }
  }
}