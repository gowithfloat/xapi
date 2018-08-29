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
using Xunit;

namespace Float.xAPI.Tests
{
    public class SubStatementTests : IInitializationTests, IEqualityTests, IToStringTests, ISpecExampleTests
    {
        [Fact]
        public void TestValidInit()
        {

        }

        [Fact]
        public void TestInvalidInit()
        {

        }

        [Fact]
        public void TestEquality()
        {

        }

        [Fact]
        public void TestInequality()
        {

        }

        [Fact]
        public void TestToString()
        {

        }

        [Fact]
        public void TestExample()
        {
            var actor = new Agent(new Mailbox(new MailAddress("test@example.com")), "Agent");
            var verb1 = new Verb(new Uri("http://example.com/planned"), new LanguageMap("en-US", "planned"));
            var verb2 = new Verb(new Uri("http://example.com/planned"), new LanguageMap("en-US", "will visit"));
            var activity = new Activity(
                new Uri("http://example.com/website"), 
                new ActivityDefinition(new LanguageMap("en-US", "Some Awesome Website"), 
                                       new LanguageMap("en-US", "This is an awesome website"),
                                       new Uri("http://adlnet.gov/expapi/activities/media"))
            );
            var substatement = new SubStatement(actor, verb2, activity, null, null, null);
            var statement = new Statement(actor, verb1, substatement);
        }
    }
}
