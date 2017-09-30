using System;

namespace Strawberrey.CLI
{
  public class Parser
  {
    public void Parse(string input, string[] args)
    {
      if (args.Length == 0)
      {
        Console.WriteLine("Strawberrey (1.0.0)");
      }
    }
  }
}