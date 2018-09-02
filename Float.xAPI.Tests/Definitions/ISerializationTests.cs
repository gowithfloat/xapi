// <copyright file="ISerializationTests.cs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Tests
{
    /// <summary>
    /// Defines common serialization tests.
    /// </summary>
    public interface ISerializationTests
    {
        /// <summary>
        /// Verify that the type under test can be serialized successfully.
        /// </summary>
        void TestSerialize();

        /// <summary>
        /// Verify that the type under test can be deserialized successfully.
        /// </summary>
        void TestDeserialize();
    }
}
