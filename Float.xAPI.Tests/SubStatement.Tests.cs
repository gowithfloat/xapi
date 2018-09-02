// <copyright file="SubStatement.Tests.cs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Net.Mail;
using Float.xAPI.Activities;
using Float.xAPI.Activities.Definitions;
using Float.xAPI.Actor;
using Float.xAPI.Actor.Identifier;
using Float.xAPI.Languages;
using Xunit;

namespace Float.xAPI.Tests
{
    public class SubStatementTests : IInitializationTests, IToStringTests, ISpecExampleTests
    {
        [Fact]
        public void TestValidInit()
        {
            var actor = new Agent(new Mailbox(new MailAddress("test@example.com")));
            var verb = Verb.Voided;
            var activity = new Activity(new Uri("http://example.com"));
            var result = new Result();
            var context = new Context();
            var timestamp = DateTime.Now;

            var substatement1 = new SubStatement(actor, verb, activity);
            var substatement2 = new SubStatement(actor, verb, activity, result);
            var substatement3 = new SubStatement(actor, verb, activity, result, context);
            var substatement4 = new SubStatement(actor, verb, activity, result, context, timestamp);
        }

        [Fact]
        public void TestInvalidInit()
        {
            var actor = new Agent(new Mailbox(new MailAddress("test@example.com")));
            var verb = Verb.Voided;
            var activity = new Activity(new Uri("http://example.com"));

            Assert.Throws<ArgumentNullException>(() => new SubStatement(null, null, null));
            Assert.Throws<ArgumentNullException>(() => new SubStatement(actor, null, null));
            Assert.Throws<ArgumentNullException>(() => new SubStatement(null, verb, null));
            Assert.Throws<ArgumentNullException>(() => new SubStatement(null, null, activity));
            Assert.Throws<ArgumentNullException>(() => new SubStatement(actor, verb, null));
            Assert.Throws<ArgumentNullException>(() => new SubStatement(actor, null, activity));
            Assert.Throws<ArgumentNullException>(() => new SubStatement(null, verb, activity));

            var substatement = new SubStatement(actor, verb, activity);
            Assert.Throws<ArgumentException>(() => new SubStatement(actor, verb, substatement));
        }

        [Fact]
        public void TestToString()
        {
            var actor = new Agent(new Mailbox(new MailAddress("test@example.com")));
            var verb = new Verb(new Uri("http://example.com/sent"), LanguageMap.EnglishUS("sent"));
            var activity = new Activity(new Uri("http://example.com"));
            var substatement = new SubStatement(actor, verb, activity);
            Assert.Equal($"<SubStatement: Actor {actor} Verb {verb} Object {activity}>", substatement.ToString());
        }

        [Fact]
        public void TestExample()
        {
            var actor = new Agent(new Mailbox(new MailAddress("test@example.com")), "Agent");
            var verb1 = new Verb(new Uri("http://example.com/planned"), new LanguageMap(LanguageTag.EnglishUS, "planned"));
            var verb2 = new Verb(new Uri("http://example.com/planned"), new LanguageMap(LanguageTag.EnglishUS, "will visit"));
            var activity = new Activity(
                new Uri("http://example.com/website"), 
                new ActivityDefinition(new LanguageMap(LanguageTag.EnglishUS, "Some Awesome Website"), 
                                       new LanguageMap(LanguageTag.EnglishUS, "This is an awesome website"),
                                       new Uri("http://adlnet.gov/expapi/activities/media"))
            );
            var substatement = new SubStatement(actor, verb2, activity, null, null, null);
            var statement = new Statement(actor, verb1, substatement);
        }
    }
}
