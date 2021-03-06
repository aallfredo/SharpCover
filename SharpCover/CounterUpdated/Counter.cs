using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

// ReSharper disable once CheckNamespace
namespace SharpCover
{
    public static class Counter
    {
        [ThreadStatic]
        private static HashSet<int> indexes;

        [ThreadStatic]
        private static BinaryWriter writer;

        [ThreadStatic]
        private static string path;

        public static void Count(string pathPrefix, int index)
        {
            if (path == null) {
                path = pathPrefix + "_" + Process.GetCurrentProcess().Id + "_" + Thread.CurrentThread.ManagedThreadId;
                indexes = new HashSet<int>();
                Console.WriteLine("Location Where we are counting : "+ path);
                writer = new BinaryWriter(File.Open(path, FileMode.CreateNew));
            }

            if (indexes.Add(index))
                writer.Write(index);
        }
    }
}
