using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace D10221
{
    ///<Summary>
    ///  Read Text Resouces, associated by convention, to a Type/Class             
    ///</Summary>
    public static class StringResource
    {
        public static string[] GetStrings<T>(string sufix = null, string extension = "sql", string delimitter = "GO")
        {
            return GetStrings(typeof(T), sufix, extension, delimitter);
        }

        public static string[] GetStrings(Type type, string sufix = null, string extension = "sql", string delimitter = "GO")
        {
            return GetString(type, sufix, extension).Split(new[] { delimitter }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string GetString<T>(string sufix, string extension = "sql")
        {
            return GetString(typeof(T), sufix, extension);
        }

        public static string GetString(Type type, string sufix = null, string extension = "sql")
        {
            var fullname = Join(new[] { type.Namespace, type.Name, sufix }, ".") + "." + extension;

            using (var stream = type.Assembly.GetManifestResourceStream(fullname))
            {
                if (stream == null)
                {
                    throw new StringResourceException(
                        $"No resource named {fullname} found, did you add the resource as Embedded resource?"
                    );
                }
                var reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
        }

        private static string Join(string[] strings, string separator)
        {
            return strings.Where(x => !string.IsNullOrEmpty(x)).Aggregate((a, b) => a + separator + b);
        }

        private static string[] Split(string input)
        {
            return input.Split(new[] { "\nGO", "\ngo" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}