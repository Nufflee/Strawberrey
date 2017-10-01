using System;

namespace Strawberrey.CLI
{
  public class Parser
  {
    private readonly Runner runner;

    public Parser(Runner runner)
    {
      this.runner = runner;
    }

    public void Parse(string[] args)
    {
      if (args.Length == 0)
      {
        Console.WriteLine($"Strawberrey {runner.Configuration.Version}");
      }
    }
  }
}