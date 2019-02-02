// <copyright file="Attachment.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Net.Mime;
using Float.xAPI.Languages;
using Float.xAPI.Statements;
using Xunit;

namespace Float.xAPI.Tests
{
    public class AttachmentTests : IInitializationTests<Attachment>, IPropertyTests
    {
        [Fact]
        public Attachment TestValidInit()
        {
            var attachment1 = new Attachment(
                new Uri("https://www.gowithfloat.com"),
                LanguageMap.EnglishUS("attachment"),
                new ContentType("text/plain"),
                100,
                new SHAHash("example"));
            var attachment2 = new Attachment(
                new Uri("https://www.gowithfloat.com"),
                LanguageMap.EnglishUS("attachment"),
                new ContentType("text/plain"),
                100,
                new SHAHash("example"),
                LanguageMap.EnglishUS("description"));
            return new Attachment(
                new Uri("https://www.gowithfloat.com"),
                LanguageMap.EnglishUS("attachment"),
                new ContentType("text/plain"),
                100,
                new SHAHash("example"),
                LanguageMap.EnglishUS("description"),
                new Uri("http://example.com"));
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new Attachment(null, null, null, 0, null));
            Assert.Throws<ArgumentNullException>(() => new Attachment(new Uri("http://example.com"), null, null, 0, null));
            Assert.Throws<ArgumentNullException>(() => new Attachment(new Uri("http://example.com"), LanguageMap.EnglishUS("test"), null, 0, null));
            Assert.Throws<ArgumentNullException>(() => new Attachment(new Uri("http://example.com"), LanguageMap.EnglishUS("test"), new ContentType("appliction/json"), 0, null));
            Assert.Throws<ArgumentNullException>(() => new Attachment(new Uri("http://example.com"), LanguageMap.EnglishUS("test"), new ContentType("appliction/json"), 1024, null));
        }

        [Fact]
        public void TestProperties()
        {
            uint length = 37037;
            var iattachment = new Attachment(
                new Uri("https://www.gowithfloat.com"),
                LanguageMap.EnglishUS("display"),
                new ContentType("text/plain"),
                length,
                new SHAHash("example"),
                LanguageMap.EnglishUS("description"),
                new Uri("http://example.com")) as IAttachment;

            Assert.Equal(new ContentType("text/plain"), iattachment.ContentType);
            Assert.Equal(LanguageMap.EnglishUS("description"), iattachment.Description);
            Assert.Equal(LanguageMap.EnglishUS("display"), iattachment.Display);
            Assert.Equal(new Uri("http://example.com"), iattachment.FileUrl);
            Assert.Equal(length, iattachment.Length);
            Assert.Equal(new SHAHash("example"), iattachment.Sha2);
            Assert.Equal(new Uri("https://www.gowithfloat.com"), iattachment.UsageType);
        }
    }
}
