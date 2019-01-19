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
            var doc1 = new Document(StateId.NewStateId("state-id"), DateTime.Now, new List<Tuple<string, string>> { new Tuple<string, string>("contents", "example") });
            return new Document(StateId.NewStateId("state-id"), DateTime.Now, GenerateDictionary());
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new Document(StateId.NewStateId("test"), DateTime.Now, null as IDictionary<string, string>));
            Assert.Throws<ArgumentNullException>(() => new Document(StateId.NewStateId("test"), DateTime.Now, null as IEnumerable<Tuple<string, string>>));
            Assert.Throws<ArgumentException>(() => new Document(StateId.NewStateId("test"), DateTime.Now, new Dictionary<string, string>()));
        }

        [Fact]
        public void TestEquality()
        {
            var doc1 = TestValidInit();
            var doc2 = new Document(StateId.NewStateId("state-id"), new DateTime(123456), new Dictionary<string, string> { { "test", "testing" } });
            AssertHelper.Equality<Document, IDocument>(doc1, doc2, (a, b) => a == b);
        }

        [Fact]
        public void TestInequality()
        {
            var doc1 = new Document(StateId.NewStateId("state-id1"), new DateTime(123456), new Dictionary<string, string> { { "test", "testing" } });
            var doc2 = new Document(StateId.NewStateId("state-id2"), new DateTime(123456), new Dictionary<string, string> { { "test", "testing" } });
            AssertHelper.Inequality<Document, IDocument>(doc1, doc2, (a, b) => a != b);
        }

        [Fact]
        public void TestProperties()
        {
            var doc = TestValidInit();
            Assert.Equal(GenerateDictionary().ToSequence(), doc.Contents);
            Assert.Equal(StateId.NewStateId("state-id"), doc.Id);
            Assert.Equal(DateTime.Now, doc.Updated, new TimeSpan(0, 0, 1));

            var idoc = doc as IDocument;
            Assert.Equal(GenerateDictionary().ToSequence(), idoc.Contents);
            Assert.Equal(StateId.NewStateId("state-id"), idoc.Id);
            Assert.Equal(DateTime.Now, idoc.Updated, new TimeSpan(0, 0, 1));
        }

        [Fact]
        public void TestIdTypes()
        {
            AssertHelper.Equality(ActivityId.NewActivityId(new Uri("http://example.com/test")), ActivityId.NewActivityId(new Uri("http://example.com/test")));
            AssertHelper.Equality(ProfileId.NewProfileId("profile-id"), ProfileId.NewProfileId("profile-id"));
            AssertHelper.Equality(StateId.NewStateId("state-id"), StateId.NewStateId("state-id"));
            Assert.True(ActivityId.NewActivityId(new Uri("http://example.com/test")) is ActivityId);
            Assert.True(ProfileId.NewProfileId("profile-id") is ProfileId);
            Assert.True(StateId.NewStateId("state-id") is StateId);

            AssertHelper.Inequality(ActivityId.NewActivityId(new Uri("http://example.com/test1")), ActivityId.NewActivityId(new Uri("http://example.com/test2")), (a, b) => a != b);
            AssertHelper.Inequality(ProfileId.NewProfileId("profile-id"), ProfileId.NewProfileId("profile-id-b"), (a, b) => a != b);
            AssertHelper.Inequality(StateId.NewStateId("stateid"), StateId.NewStateId("state-id"), (a, b) => a != b);
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
