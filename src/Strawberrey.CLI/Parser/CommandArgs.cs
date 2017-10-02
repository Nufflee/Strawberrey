namespace Strawberrey.CLI
{
  public class CommandArgs
  {
    public string this[int index] => rawArgs[index];

    public int Length => rawArgs.Length;

    private readonly string[] rawArgs;

    public CommandArgs(string[] rawArgs)
    {
#if DEBUG
      this.rawArgs = rawArgs.Skip(1).ToArray();
      #else
      this.rawArgs = rawArgs;
#endif
    }
  }
}