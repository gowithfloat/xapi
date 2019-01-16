// <copyright file="IPropertyTests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

// todo: property tests should, by default, operate on some given object, perhaps built from the initializer tests?
namespace Float.xAPI.Tests
{
    /// <summary>
    /// Defines common property tests.
    /// </summary>
    public interface IPropertyTests
    {
        /// <summary>
        /// Verify that all properties on the type can be accessed.
        /// </summary>
        void TestProperties();
    }
}
