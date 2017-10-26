using System;
using System.Diagnostics;
using System.Linq;

namespace Strawberrey.CLI
{
  public static class TypeExtensions
  {
    /// <summary>
    /// Returns whether type implements <paramref name="interfaceType"/> (<paramref name="interfaceType"/> must be an interface).
    /// </summary>
    /// <param name="type">Type to check for.</param>
    /// <param name="interfaceType">Interface type.</param>
    public static bool Implements(this Type type, Type interfaceType)
    {
      Debug.Assert(type != null);
      Debug.Assert(interfaceType.IsInterface);

      return type.GetInterfaces().Contains(interfaceType);
    }

    public static bool Inherits(this Type type, Type inheritedType)
    {
      Debug.Assert(type != null);
      Debug.Assert(type.IsClass);
      Debug.Assert(!type.IsSealed);

      return type.IsSubclassOf(inheritedType);
    }
  }
}