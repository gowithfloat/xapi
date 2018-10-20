// <copyright file="Dictionary.Extensions.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;

namespace Float.xAPI.Tests
{
    /// <summary>
    /// Dictionary extensions.
    /// </summary>
    static class DictionaryExtensions
    {
        /// <summary>
        /// Convert this dictionary to an enumerable sequence of tuples.
        /// todo: This method should not be necessary; it would be helpful if F# sequences of tuples could be compared to dictionaries in C#.
        /// </summary>
        /// <returns>The sequence.</returns>
        /// <param name="dictionary">A dictionary to convert to a sequence.</param>
        public static IEnumerable<Tuple<T1, T2>> ToSequence<T1, T2>(this IDictionary<T1, T2> dictionary)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            foreach (var pair in dictionary)
            {
                yield return new Tuple<T1, T2>(pair.Key, pair.Value);
            }
        }
    }
}
