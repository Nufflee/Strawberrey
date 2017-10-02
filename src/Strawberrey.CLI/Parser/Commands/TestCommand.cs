using System;

namespace Strawberrey.CLI
{
  public class TestCommand : ICommand
  {
    public void Run(CommandArgs args, Runner runner)
    {
      Console.WriteLine("I RAN");
    }
  }
}