// <copyright file="Generators.cs" company="">
// Copyright (c) 2020 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using FsCheck;

namespace Float.xAPI.Tests
{
    public class Generators
    {
        static bool IsValid(string uri)
        {
            try
            {
                return new Uri(uri) != null;
            }
            catch (UriFormatException)
            {
                return false;
            }
        }

        static Gen<string> Scheme()
        {
            var options = new string[]
            {
                System.Uri.UriSchemeFile,
                System.Uri.UriSchemeFtp,
                System.Uri.UriSchemeGopher,
                System.Uri.UriSchemeHttp,
                System.Uri.UriSchemeHttps,
                System.Uri.UriSchemeMailto,
                System.Uri.UriSchemeNetPipe,
                System.Uri.UriSchemeNetTcp,
                System.Uri.UriSchemeNews,
                System.Uri.UriSchemeNntp,
            };

            return ChooseFrom(options);
        }

        static Gen<T> ChooseFrom<T>(IEnumerable<T> xs)
        {
            return from i in Gen.Choose(0, xs.Count() - 1)
                   select xs.ElementAt(i);
        }

        static Gen<string> Subdomain()
        {
            var options = new string[] { "www", "mail", "remote", "blog", "webmail", "server", "ns1", "ns2", "smtp", "secure", "vpn", "m", "shop", "ftp" };
            return ChooseFrom(options);
        }

        static Gen<string> Tld()
        {
            var options = new string[] { "com", "org", "net", "de", "ru", "co.uk", "jp", "it", "fr", "edu", "gov", "mil" };
            return ChooseFrom(options);
        }

        static Gen<string> Domain()
        {
            var characters = Gen.Elements("abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray());
            return Gen.Choose(1, 63)
                .SelectMany(i => Gen.ArrayOf(i, characters))
                .Select(a => new string(a));
        }

        public static Arbitrary<Uri> Uri()
        {
            return Scheme()
                .Zip(Subdomain())
                .Zip(Domain())
                .Select(a => (a.Item1.Item1, a.Item1.Item2, a.Item2))
                .Zip(Tld())
                .Select(a => $"{a.Item1.Item1}://{a.Item1.Item2}.{a.Item1.Item3}.{a.Item2}")
                .Where(str => IsValid(str))
                .Select(str => new Uri(str))
                .ToArbitrary();
        }
    }
}
