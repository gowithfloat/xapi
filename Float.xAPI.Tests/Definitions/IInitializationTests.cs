// <copyright file="IInitializationTests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Tests
{
    /// <summary>
    /// Defines common initialization tests.
    /// </summary>
    public interface IInitializationTests<T>
    {
        /// <summary>
        /// Verify that initialization that has all data succeeds.
        /// </summary>
        T TestValidInit();

        /// <summary>
        /// Verify that initialization that is missing data throw an exception.
        /// </summary>
        void TestInvalidInit();
    }
}
