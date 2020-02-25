// <copyright file="Assert.Extensions.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using Xunit;

namespace Float.xAPI.Tests
{
    /// <summary>
    /// Helpers for common assertions.
    /// </summary>
    public static class AssertHelper
    {
        /// <summary>
        /// An extremely explicit method of checking equality of two types and throwing an assertion error if an equality check fails.
        /// </summary>
        /// <param name="first">The first object to compare.</param>
        /// <param name="second">The second object to compare.</param>
        /// <param name="equalityOp">A means to compare the two; often used to use equality operators.</param>
        /// <typeparam name="TConcrete">The concrete type of the given parameters.</typeparam>
        /// <typeparam name="TInterface">The interface type of the given parameters.</typeparam>
        /// <typeparam name="TEquatable">The type for which the concrete type is equatable.</typeparam>
        public static void Equality<TConcrete, TInterface, TEquatable>(TConcrete first, TConcrete second, Func<TConcrete, TConcrete, bool> equalityOp = null) where TConcrete : TInterface where TInterface : TEquatable
        {
            Assert.NotNull(first);
            Assert.NotNull(second);

            if (equalityOp != null)
            {
                Assert.True(equalityOp(first, second));
                Assert.True(equalityOp(second, first));
            }

            Assert.Equal(first, second);
            Assert.Equal(first.GetHashCode(), second.GetHashCode());
            Assert.Equal(first.GetType(), second.GetType());

            // cast to interface types
            var ifirst = (TInterface)first;
            var isecond = (TInterface)second;
            Assert.NotNull(ifirst);
            Assert.NotNull(isecond);
            Assert.Equal(ifirst, isecond);
            Assert.Equal(isecond, ifirst);
            Assert.Equal(ifirst.GetHashCode(), isecond.GetHashCode());
            Assert.Equal(ifirst.GetType(), isecond.GetType());

            // cast to equatable types
            var eqfirst = first as IEquatable<TEquatable>;
            var eqsecond = second as IEquatable<TEquatable>;
            Assert.NotNull(eqfirst);
            Assert.NotNull(eqsecond);
            Assert.Equal(eqfirst, eqsecond);
            Assert.Equal(eqsecond, eqfirst);
            Assert.Equal(eqfirst.GetHashCode(), eqsecond.GetHashCode());
            Assert.Equal(eqfirst.GetType(), eqsecond.GetType());

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

            // check all types using an equality comparer
            Assert.True(EqualityComparer<TConcrete>.Default.Equals(first, second));
            Assert.True(EqualityComparer<TInterface>.Default.Equals(first, second));
            Assert.True(EqualityComparer<TConcrete>.Default.Equals(second, first));
            Assert.True(EqualityComparer<TInterface>.Default.Equals(second, first));
        }

        /// <summary>
        /// An extremely explicit method of checking equality of two types and throwing an assertion error if an equality check fails.
        /// Use this when the equatable type is the same as the interface type.
        /// </summary>
        /// <param name="first">The first object to compare.</param>
        /// <param name="second">The second object to compare.</param>
        /// <param name="equalityOp">A means to compare the two; often used to use equality operators.</param>
        /// <typeparam name="TConcrete">The concrete type of the given parameters.</typeparam>
        /// <typeparam name="TInterface">The interface type of the given parameters.</typeparam>
        public static void Equality<TConcrete, TInterface>(TConcrete first, TConcrete second, Func<TConcrete, TConcrete, bool> equalityOp = null) where TConcrete : TInterface
        {
            Equality<TConcrete, TInterface, TInterface>(first, second, equalityOp);
        }

        /// <summary>
        /// An extremely explicit method of checking equality of two types and throwing an assertion error if an equality check fails.
        /// Use this when the concrete type doesn't have an interface type.
        /// </summary>
        /// <param name="first">The first object to compare.</param>
        /// <param name="second">The second object to compare.</param>
        /// <param name="equalityOp">A means to compare the two; often used to use equality operators.</param>
        /// <typeparam name="TConcrete">The concrete type of the given parameters.</typeparam>
        public static void Equality<TConcrete>(TConcrete first, TConcrete second, Func<TConcrete, TConcrete, bool> equalityOp = null)
        {
            Equality<TConcrete, TConcrete>(first, second, equalityOp);
        }

        /// <summary>
        /// An extremely explicit method of checking inequality of two types and throwing an assertion error if an inequality check fails.
        /// </summary>
        /// <param name="first">The first object to compare.</param>
        /// <param name="second">The second object to compare.</param>
        /// <param name="inequalityOp">A means to compare the two; often used to use equality operators.</param>
        /// <typeparam name="TConcrete">The concrete type of the given parameters.</typeparam>
        /// <typeparam name="TInterface">The interface type of the given parameters.</typeparam>
        /// <typeparam name="TEquatable">The type for which the concrete type is equatable.</typeparam>
        public static void Inequality<TConcrete, TInterface, TEquatable>(TConcrete first, TConcrete second, Func<TConcrete, TConcrete, bool> inequalityOp = null) where TConcrete : TInterface where TInterface : TEquatable
        {
            Assert.NotNull(first);
            Assert.NotNull(second);

            if (inequalityOp != null)
            {
                Assert.True(inequalityOp(first, second));
                Assert.True(inequalityOp(second, first));
            }

            Assert.NotEqual(first, second);
            Assert.NotEqual(second, first);
            Assert.NotEqual(first.GetHashCode(), second.GetHashCode());

            // cast to interface types
            var ifirst = (TInterface)first;
            var isecond = (TInterface)second;
            Assert.NotNull(ifirst);
            Assert.NotNull(isecond);
            Assert.NotEqual(ifirst, isecond);
            Assert.NotEqual(isecond, ifirst);
            Assert.NotEqual(ifirst.GetHashCode(), isecond.GetHashCode());

            // cast to equatable types
            var eqfirst = first as IEquatable<TEquatable>;
            var eqsecond = second as IEquatable<TEquatable>;
            Assert.NotNull(eqfirst);
            Assert.NotNull(eqsecond);
            Assert.NotEqual(eqfirst, eqsecond);
            Assert.NotEqual(eqsecond, eqfirst);
            Assert.NotEqual(eqfirst.GetHashCode(), eqsecond.GetHashCode());

            // check that the correct equals operator is used
            Assert.False(first.Equals(second));
            Assert.False(first.Equals(isecond));
            Assert.False(first.Equals(eqsecond));
            Assert.False(ifirst.Equals(second));
            Assert.False(ifirst.Equals(isecond));
            Assert.False(ifirst.Equals(eqsecond));
            Assert.False(eqfirst.Equals(second));
            Assert.False(eqfirst.Equals(isecond));
            Assert.False(eqfirst.Equals(eqsecond));
            Assert.False(second.Equals(first));
            Assert.False(second.Equals(ifirst));
            Assert.False(second.Equals(eqfirst));
            Assert.False(isecond.Equals(first));
            Assert.False(isecond.Equals(ifirst));
            Assert.False(isecond.Equals(eqfirst));
            Assert.False(eqsecond.Equals(first));
            Assert.False(eqsecond.Equals(ifirst));
            Assert.False(eqsecond.Equals(eqfirst));
        }

        /// <summary>
        /// An extremely explicit method of checking inequality of two types and throwing an assertion error if an inequality check fails.
        /// Use this when the equatable type is the same as the interface type.
        /// </summary>
        /// <param name="first">The first object to compare.</param>
        /// <param name="second">The second object to compare.</param>
        /// <param name="inequalityOp">A means to compare the two; often used to use equality operators.</param>
        /// <typeparam name="TConcrete">The concrete type of the given parameters.</typeparam>
        /// <typeparam name="TInterface">The interface type of the given parameters.</typeparam>
        public static void Inequality<TConcrete, TInterface>(TConcrete first, TConcrete second, Func<TConcrete, TConcrete, bool> inequalityOp = null) where TConcrete : TInterface
        {
            Inequality<TConcrete, TInterface, TInterface>(first, second, inequalityOp);
        }

        /// <summary>
        /// An extremely explicit method of checking inequality of two types and throwing an assertion error if an inequality check fails.
        /// Use this when the concrete type doesn't have an interface type.
        /// </summary>
        /// <param name="first">The first object to compare.</param>
        /// <param name="second">The second object to compare.</param>
        /// <param name="inequalityOp">A means to compare the two; often used to use equality operators.</param>
        /// <typeparam name="TConcrete">The concrete type of the given parameters.</typeparam>
        public static void Inequality<TConcrete>(TConcrete first, TConcrete second, Func<TConcrete, TConcrete, bool> inequalityOp = null)
        {
            Inequality<TConcrete, TConcrete>(first, second, inequalityOp);
        }
    }
}
