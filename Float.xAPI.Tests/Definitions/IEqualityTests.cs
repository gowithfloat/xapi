// <copyright file="IEqualityTests.cs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Tests
{
    /// <summary>
    /// Defines common tests of equality.
    /// </summary>
    public interface IEqualityTests
    {
        /// <summary>
        /// Verify that types that should be equal are treated as such.
        /// </summary>
        void TestEquality();

        /// <summary>
        /// Verify that types that should not be equal are treated as such.
        /// </summary>
        void TestInequality();
    }
}
