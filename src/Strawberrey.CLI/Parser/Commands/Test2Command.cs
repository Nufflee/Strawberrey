using System;

namespace Strawberrey.CLI
{
  public class Test2Command : ICommand
  {
    public void Run(CommandArgs args, Runner runner)
    {
      Console.WriteLine("TEST2");
    }
  }
}