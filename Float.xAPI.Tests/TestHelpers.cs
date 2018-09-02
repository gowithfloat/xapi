// <copyright file="TestHelpers.cs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System.IO;
using System.Reflection;

namespace Float.xAPI.Tests
{
    /// <summary>
    /// Test helpers.
    /// </summary>
    public static class TestHelpers
    {
        /// <summary>
        /// Read an embedded resource file with the given name. Assumes the Data directory.
        /// </summary>
        /// <returns>The contents of the file.</returns>
        /// <param name="file">The name of the file to read.</param>
        public static string ReadFile(string file)
        {
            var path = $"Float.xAPI.Tests.Data.{file}";
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(path))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
