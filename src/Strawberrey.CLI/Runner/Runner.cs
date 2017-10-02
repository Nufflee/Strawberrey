namespace Strawberrey.CLI
{
  public class Runner
  {
    public Configuration Configuration { get; }

    private readonly Parser parser;

    public Runner(Configuration configuration)
    {
      Configuration = configuration;

      parser = new Parser(this);
    }

    public void Run(string[] args)
    {
#if DEBUG
      if (args.Length == 0)
      {
        while (true)
        {
          string input = Console.ReadLine();
          string[] inputArgs = input.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

          parser.Parse(new CommandArgs(inputArgs));
        }
      }
#else
      parser.Parse(new CommandArgs(args));
#endif
    }
  }
}