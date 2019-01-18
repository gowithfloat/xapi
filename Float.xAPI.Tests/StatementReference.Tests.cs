// <copyright file="StatementReference.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Xunit;

namespace Float.xAPI.Tests
{
    public class StatementReferenceTests : IInitializationTests<StatementReference>, IEqualityTests, IPropertyTests
    {
        [Fact]
        public StatementReference TestValidInit()
        {
            return new StatementReference(Guid.NewGuid());
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentException>(() => new StatementReference(default(Guid)));
            Assert.Throws<ArgumentException>(() => new StatementReference(new Guid(new byte[] { })));
            Assert.Throws<ArgumentNullException>(() => new StatementReference(new Guid(null as string)));
            Assert.Throws<FormatException>(() => new StatementReference(new Guid(string.Empty)));
            Assert.Throws<FormatException>(() => new StatementReference(new Guid(" ")));
            Assert.Throws<FormatException>(() => new StatementReference(new Guid("a")));
        }

        [Fact]
        public void TestEquality()
        {
            var id = Guid.NewGuid();
            var ref1 = new StatementReference(id);
            var ref2 = new StatementReference(id);
            AssertHelper.Equality<StatementReference, IStatementReference>(ref1, ref2, (a, b) => a == b);
        }

        [Fact]
        public void TestInequality()
        {
            var ref1 = new StatementReference(Guid.NewGuid());
            var ref2 = new StatementReference(Guid.NewGuid());
            AssertHelper.Inequality<StatementReference, IStatementReference>(ref1, ref2, (a, b) => a != b);
        }

        [Fact]
        public void TestProperties()
        {
            var id = Guid.NewGuid();
            var sref = new StatementReference(id);
            Assert.Equal(id, sref.Id);
            Assert.Equal(ObjectType.StatementReference, sref.ObjectType);

            var isref = sref as IStatementReference;
            Assert.Equal(id, isref.Id);
            Assert.Equal(ObjectType.StatementReference, isref.ObjectType);
        }
    }
}
