using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Strawberrey.CLI
{
  public class Parser
  {
    private readonly Runner runner;

    public Dictionary<string, Type> commandTypes;

    public Parser(Runner runner)
    {
      this.runner = runner;
      commandTypes = LoadCommandTypes();
    }

    public void Parse(CommandArgs args)
    {
      if (args.Length == 0)
      {
        Console.WriteLine($"Strawberrey {runner.Configuration.Version}");
        return;
      }

      ICommand command = GetCommand(args[0]);

      command?.Run(args, runner);
    }

    private ICommand GetCommand(string name)
    {
      KeyValuePair<string, Type> first = new KeyValuePair<string, Type>();
      foreach (KeyValuePair<string, Type> t in commandTypes)
      {
        if (t.Key.SubstringTill(0, t.Key.IndexOf("Command", StringComparison.Ordinal) - 1).ToLower() == name)
        {
          first = t;
          break;
        }
      }
      return (ICommand) Activator.CreateInstance(first.Value);
    }

    private Dictionary<string, Type> LoadCommandTypes()
    {
      Dictionary<string, Type> result = new Dictionary<string, Type>();
      List<Type> types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Contains(typeof(ICommand))).ToList();

      foreach (Type type in types)
      {
        result.Add(type.Name, type);
      }

      return result;
    }
  }
}