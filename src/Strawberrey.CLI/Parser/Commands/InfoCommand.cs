using System;

namespace Strawberrey.CLI
{
  public class InfoCommand : ICommand
  {
    public void Run(CommandArgs args, Runner runner)
    {
      Console.WriteLine($"Strawberrey {runner.Configuration.Version}");
    }
  }
}