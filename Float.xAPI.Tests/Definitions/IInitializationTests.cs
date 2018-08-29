// <copyright file="IInitializationTests.cs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Tests
{
    /// <summary>
    /// Defines common initialization tests.
    /// </summary>
    public interface IInitializationTests
    {
        /// <summary>
        /// Verify that initialization that is missing data throw an exception.
        /// </summary>
        void TestInvalidInit();

        /// <summary>
        /// Verify that initialization that has all data succeeds.
        /// </summary>
        void TestValidInit();
    }
}
