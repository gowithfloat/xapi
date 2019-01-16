// <copyright file="IEqualityTests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

// todo: tests should verify that all types in the xAPI namespace that are equatable are tested
// todo: since most of these will just defer to the assert helper, provide a default implementation that does that
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
