
using System.Reflection;

namespace Boilerplate.Shared.Extensions;

public static class AssemblyExtensions
{
    public static string GetResourceAsString(this Assembly assembly, string path)
    {
        if (assembly == null)
            throw new ArgumentNullException(nameof(assembly), "The assembly cannot be null.");

        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException("The path cannot be null or empty.", nameof(path));

        using Stream? stream = assembly.GetManifestResourceStream(path);
        if (stream == null)
            throw new InvalidOperationException($"Failed to get a stream for the resource at path '{path}' in the assembly '{assembly.FullName}'.");

        using StreamReader reader = new(stream);
        if (reader == null)
            throw new InvalidOperationException($"Failed to create a StreamReader for the stream obtained from the resource at path '{path}' in the assembly '{assembly.FullName}'.");

        string result = reader.ReadToEnd();
        return result;
    }
}
