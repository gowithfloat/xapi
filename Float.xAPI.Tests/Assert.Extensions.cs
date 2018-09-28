// <copyright file="Assert.Extensions.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Xunit;

namespace Float.xAPI.Tests
{
    /// <summary>
    /// Helpers for common assertions.
    /// </summary>
    public static class AssertHelper
    {
        /// <summary>
        /// An extremely explicit method of checking equality of two types and throwing an assertion error if it fails.
        /// </summary>
        /// <param name="first">The first object to compare.</param>
        /// <param name="second">The second object to compare.</param>
        /// <param name="equalityOp">A means to compare the two; often used to use equality operators.</param>
        /// <typeparam name="Concrete">The concrete type of the given parameters.</typeparam>
        /// <typeparam name="Interface">The interface type of the given parameters.</typeparam>
        /// <typeparam name="Equatable">The type for which the concrete type is equatable.</typeparam>
        public static void Equality<Concrete, Interface, Equatable>(Concrete first, Concrete second, Func<Concrete, Concrete, bool> equalityOp) where Concrete : Interface where Interface : Equatable
        {
            Assert.True(equalityOp(first, second));
            Assert.True(equalityOp(second, first));
            Assert.Equal(first, second);
            Assert.Equal(first.GetHashCode(), second.GetHashCode());

            // cast to interface types
            var ifirst = (Interface)first;
            var isecond = (Interface)second;
            Assert.NotNull(ifirst);
            Assert.NotNull(isecond);
            Assert.Equal(ifirst, isecond);
            Assert.Equal(isecond, ifirst);
            Assert.Equal(ifirst.GetHashCode(), isecond.GetHashCode());

            // cast to equatable types
            var eqfirst = first as IEquatable<Equatable>;
            var eqsecond = second as IEquatable<Equatable>;
            Assert.NotNull(eqfirst);
            Assert.NotNull(eqsecond);
            Assert.Equal(eqfirst, eqsecond);

            // check that the right equals operator is used
            Assert.True(first.Equals(second));
            Assert.True(first.Equals(isecond));
            Assert.True(first.Equals(eqsecond));
            Assert.True(ifirst.Equals(second));
            Assert.True(ifirst.Equals(isecond));
            Assert.True(ifirst.Equals(eqsecond));
            Assert.True(eqfirst.Equals(second));
            Assert.True(eqfirst.Equals(isecond));
            Assert.True(eqfirst.Equals(eqsecond));
            Assert.True(second.Equals(first));
            Assert.True(second.Equals(ifirst));
            Assert.True(second.Equals(eqfirst));
            Assert.True(isecond.Equals(first));
            Assert.True(isecond.Equals(ifirst));
            Assert.True(isecond.Equals(eqfirst));
            Assert.True(eqsecond.Equals(first));
            Assert.True(eqsecond.Equals(ifirst));
            Assert.True(eqsecond.Equals(eqfirst));
        }
    }
}
