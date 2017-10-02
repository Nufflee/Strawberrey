namespace Strawberrey.CLI
{
  public interface ICommand
  {
    void Run(CommandArgs args, Runner configuration);
  }
}