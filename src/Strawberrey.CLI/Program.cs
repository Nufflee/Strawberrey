using System;
using System.Data;
using System.Linq;

namespace Strawberrey.CLI
{
  public class Program
  {
    private static void Main(string[] args)
    {
#if DEBUG
      if (args.Length == 0)
      {
        while (true)
        {
          string input = Console.ReadLine();
          string[] inputArgs = input.Split(' ').Skip(1).ToArray();

          //if (!string.IsNullOrWhiteSpace(input))
          {
            new Parser().Parse(input, inputArgs);
          }
        }
      }
#endif
    }
  }
}