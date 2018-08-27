// // <copyright file="Verb.Tests.cs" company="Float">
// // Copyright (c) 2018 Float, All rights reserved.
// // Shared under an MIT license. See license.md for details.
// // </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace Float.xAPI.Tests
{
    public class VerbTests
    {
        [Fact]
        public void TestInit()
        {
            var uri = new Uri("http://www.gowithfloat.com");
            var map = new LanguageMap("en-US", "floated");

            // display is required
            Assert.Throws<ArgumentNullException>(() => new Verb(null, map));

            // map must have at least one element
            var map2 = new LanguageMap();
            Assert.Throws<ArgumentException>(() => new Verb(uri, map2));

            // valid
            var verb = new Verb(uri, map);
        }

        [Fact]
        public void TestExampleVerb()
        {
            var uri = new Uri("http://example.com/xapi/verbs#defenestrated");
            var map = new Dictionary<CultureInfo, string>
            {
                {
                    new CultureInfo("en-US"), "defenestrated"
                },
                {
                    new CultureInfo("es"), "defenestrado"
                }
            };

            var verb = new Verb(uri, map);

            Assert.Equal(uri, verb.Id);
            Assert.Equal(map, verb.Display);
        }
    }
}
