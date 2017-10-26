using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Strawberrey.CLI
{
  public class Parser
  {
    private readonly Runner runner;

    private readonly Dictionary<string, Type> commandTypes;

    public Parser(Runner runner)
    {
      this.runner = runner;
      commandTypes = LoadCommandTypes();
    }

    public void Parse(CommandArgs args)
    {
      ICommand command;

      if (args.Length == 0)
      {
        command = CreateCommand(typeof(InfoCommand));
      }
      else
      {
        command = GetCommand(args[0]);
      }

      command?.Run(args, runner);
    }

    private ICommand GetCommand(string name)
    {
      return CreateCommand(commandTypes.FirstOrDefault(t => t.Key.SubstringTill(0, t.Key.IndexOf("Command", StringComparison.Ordinal) - 1).ToLower() == name).Value);
    }

    private ICommand CreateCommand(Type type)
    {
      Debug.Assert(type != null);
      Debug.Assert(type.Implements(typeof(ICommand)));
      Debug.Assert(commandTypes.ContainsValue(type));

      return (ICommand) Activator.CreateInstance(type);
    }

    private static Dictionary<string, Type> LoadCommandTypes()
    {
      Dictionary<string, Type> results = new Dictionary<string, Type>();
      List<Type> types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Contains(typeof(ICommand))).ToList();

      foreach (Type type in types)
      {
        results.Add(type.Name, type);
      }

      return results;
    }
  }
}