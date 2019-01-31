// <copyright file="Document.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using Float.xAPI.Resources.Documents;
using Xunit;

namespace Float.xAPI.Tests
{
    public class DocumentTests : IInitializationTests<Document>, IEqualityTests, IPropertyTests
    {
        [Fact]
        public Document TestValidInit()
        {
            var doc1 = new Document(new StateId("state-id"), DateTime.Now, new List<Tuple<string, string>> { new Tuple<string, string>("contents", "example") });
            return new Document(new StateId("state-id"), DateTime.Now, GenerateDictionary());
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new Document(new StateId("test"), DateTime.Now, null as IDictionary<string, string>));
            Assert.Throws<ArgumentNullException>(() => new Document(new StateId("test"), DateTime.Now, null as IEnumerable<Tuple<string, string>>));
            Assert.Throws<ArgumentException>(() => new Document(new StateId("test"), DateTime.Now, new Dictionary<string, string>()));
        }

        [Fact]
        public void TestEquality()
        {
            var doc1 = TestValidInit();
            var doc2 = new Document(new StateId("state-id"), new DateTime(123456), new Dictionary<string, string> { { "test", "testing" } });
            AssertHelper.Equality<Document, IDocument>(doc1, doc2, (a, b) => a == b);
        }

        [Fact]
        public void TestInequality()
        {
            var doc1 = new Document(new StateId("state-id1"), new DateTime(123456), new Dictionary<string, string> { { "test", "testing" } });
            var doc2 = new Document(new StateId("state-id2"), new DateTime(123456), new Dictionary<string, string> { { "test", "testing" } });
            AssertHelper.Inequality<Document, IDocument>(doc1, doc2, (a, b) => a != b);
        }

        [Fact]
        public void TestProperties()
        {
            var doc = TestValidInit();
            Assert.Equal(GenerateDictionary().ToSequence(), doc.Contents);
            Assert.Equal(new StateId("state-id"), doc.Id);
            Assert.Equal(DateTime.Now, doc.Updated, new TimeSpan(0, 0, 1));

            var idoc = doc as IDocument;
            Assert.Equal(GenerateDictionary().ToSequence(), idoc.Contents);
            Assert.Equal(new StateId("state-id"), idoc.Id);
            Assert.Equal(DateTime.Now, idoc.Updated, new TimeSpan(0, 0, 1));
        }

        [Fact]
        public void TestIdTypes()
        {
            AssertHelper.Equality(new ActivityId(new Uri("http://example.com/test")), new ActivityId(new Uri("http://example.com/test")));
            AssertHelper.Equality(new ProfileId("profile-id"), new ProfileId("profile-id"));
            AssertHelper.Equality(new StateId("state-id"), new StateId("state-id"));

            AssertHelper.Inequality(new ActivityId(new Uri("http://example.com/test1")), new ActivityId(new Uri("http://example.com/test2")), (a, b) => a != b);
            AssertHelper.Inequality(new ProfileId("profile-id"), new ProfileId("profile-id-b"), (a, b) => a != b);
            AssertHelper.Inequality(new StateId("stateid"), new StateId("state-id"), (a, b) => a != b);
        }

        static IDictionary<string, string> GenerateDictionary()
        {
            return new Dictionary<string, string>
            {
                { "contents", "example" }
            };
        }
    }
}
