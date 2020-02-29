// <copyright file="TestHelpers.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System.IO;
using System.Reflection;

namespace Float.xAPI.Json.Tests
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
            var path = $"Float.xAPI.Json.Tests.Data.{file}";
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
