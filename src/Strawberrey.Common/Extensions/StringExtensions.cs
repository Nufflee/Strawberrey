namespace Strawberrey.CLI
{
  public static class StringExtensions
  {
    public static string SubstringTill(this string value, int startIndex, int endIndex)
    {
      return value.Substring(startIndex, endIndex - startIndex + 1);
    }
  }
}