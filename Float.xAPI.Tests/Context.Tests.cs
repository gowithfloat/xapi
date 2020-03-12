// <copyright file="Context.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Float.xAPI.Activities;
using Float.xAPI.Actors;
using Float.xAPI.Actors.Identifier;
using Float.xAPI.Languages;
using Float.xAPI.Statements;
using Xunit;

namespace Float.xAPI.Tests
{
    public class ContextTests : IInitializationTests<Context>, IPropertyTests
    {
        [Fact]
        public Context TestValidInit()
        {
            var ctx1 = new Context(Guid.NewGuid());
            var ctx2 = new Context(
                Guid.NewGuid(),
                new Agent(new OpenID(new Uri("http://example.com"))));
            var ctx3 = new Context(
                Guid.NewGuid(),
                new Agent(new OpenID(new Uri("http://example.com"))),
                new AnonymousGroup(new IAgent[] { new Agent(new OpenID(new Uri("http://example.com"))) }));
            var ctx4 = new Context(
                Guid.NewGuid(),
                new Agent(new OpenID(new Uri("http://example.com"))),
                new AnonymousGroup(new IAgent[] { new Agent(new OpenID(new Uri("http://example.com"))) }),
                new ContextActivities(new IActivity[] { new Activity() }));
            var ctx5 = new Context(
                Guid.NewGuid(),
                new Agent(new OpenID(new Uri("http://example.com"))),
                new AnonymousGroup(new IAgent[] { new Agent(new OpenID(new Uri("http://example.com"))) }),
                new ContextActivities(new IActivity[] { new Activity() }),
                "revision");
            var ctx6 = new Context(
                Guid.NewGuid(),
                new Agent(new OpenID(new Uri("http://example.com"))),
                new AnonymousGroup(new IAgent[] { new Agent(new OpenID(new Uri("http://example.com"))) }),
                new ContextActivities(new IActivity[] { new Activity() }),
                "revision",
                "platform");
            var ctx7 = new Context(
                Guid.NewGuid(),
                new Agent(new OpenID(new Uri("http://example.com"))),
                new AnonymousGroup(new IAgent[] { new Agent(new OpenID(new Uri("http://example.com"))) }),
                new ContextActivities(new IActivity[] { new Activity() }),
                "revision",
                "platform",
                LanguageTag.EnglishUS);
            var ctx8 = new Context(
                Guid.NewGuid(),
                new Agent(new OpenID(new Uri("http://example.com"))),
                new AnonymousGroup(new IAgent[] { new Agent(new OpenID(new Uri("http://example.com"))) }),
                new ContextActivities(new IActivity[] { new Activity() }),
                "revision",
                "platform",
                LanguageTag.EnglishUS,
                new StatementReference(Guid.NewGuid()));
            return new Context(
                Guid.NewGuid(),
                new Agent(new OpenID(new Uri("http://example.com"))),
                new AnonymousGroup(new IAgent[] { new Agent(new OpenID(new Uri("http://example.com"))) }),
                new ContextActivities(new IActivity[] { new Activity() }),
                "revision",
                "platform",
                LanguageTag.EnglishUS,
                new StatementReference(Guid.NewGuid()),
                new Dictionary<Uri, object> { { new Uri("http://example.com/ext"), "ext" } });
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentException>(() => new Context(revision: string.Empty));
            Assert.Throws<ArgumentException>(() => new Context(platform: string.Empty));
            Assert.Throws<ArgumentException>(() => new Context(extensions: new Dictionary<Uri, object> { }));
        }

        [Fact]
        public void TestProperties()
        {
            var ctx = TestValidInit();
            var guid = ctx.Registration;
            var srguid = ctx.Statement.Value.Id;
            Assert.Equal(new ContextActivities(new IActivity[] { new Activity() }), ctx.ContextActivities);
            Assert.Equal("ext", ctx.Extensions.Value.First().Value);
            Assert.Equal(new Agent(new OpenID(new Uri("http://example.com"))), ctx.Instructor.Value.Item);
            Assert.Equal(LanguageTag.EnglishUS, ctx.Language);
            Assert.Equal("platform", ctx.Platform);
            Assert.Equal(guid, ctx.Registration);
            Assert.Equal("revision", ctx.Revision);
            Assert.Equal(new StatementReference(srguid), ctx.Statement);
            Assert.Equal(ObjectType.Group, ctx.Team.Value.ObjectType);

            var ictx = ctx as IContext;
            Assert.Equal(new ContextActivities(new IActivity[] { new Activity() }), ictx.ContextActivities);
            Assert.Equal("ext", ictx.Extensions.Value.First().Value);
            Assert.Equal(new Agent(new OpenID(new Uri("http://example.com"))), ictx.Instructor.Value.Item);
            Assert.Equal(LanguageTag.EnglishUS, ictx.Language);
            Assert.Equal("platform", ictx.Platform);
            Assert.Equal(guid, ictx.Registration);
            Assert.Equal("revision", ictx.Revision);
            Assert.Equal(new StatementReference(srguid), ictx.Statement);
            Assert.Equal(ObjectType.Group, ictx.Team.Value.ObjectType);
        }
    }
}
