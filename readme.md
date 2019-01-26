# [Float.xAPI](https://github.com/gowithfloat/xapi)    [![Build Status](https://travis-ci.org/gowithfloat/xapi.svg?branch=master)](https://travis-ci.org/gowithfloat/xapi) [![codecov](https://codecov.io/gh/gowithfloat/xapi/branch/master/graph/badge.svg)](https://codecov.io/gh/gowithfloat/xapi) [![Documentation Status](https://readthedocs.org/projects/xapi/badge/?version=latest)](https://xapi.readthedocs.io/en/latest/?badge=latest) [![license](https://img.shields.io/badge/license-mit-green.svg)](./license.md) [![nuget](https://img.shields.io/nuget/v/Float.xAPI.svg)](https://www.nuget.org/packages/Float.xAPI/)

An F# implementation of the [xAPI](https://xapi.com/) specification with a focus on type safety and immutability. Wherever possible, we have strived to translate the [xAPI specification](https://github.com/adlnet/xAPI-Spec) directly to code, with requirements embedded as type checks.

## Status

This library is currently in a pre-release state. Feedback is welcome but active development continues and this library should not be considered ready for production use. However, we hope that the existing code base will provide an indication of the implementation goals for this project.

## C# Example

To craft a simple statement, you first need an actor:

```C#
var address = new MailAddress("example@gowithfloat.com");
var mailbox = new Mailbox(address);
var actor = new Agent(mailbox, "Example Learner");
```

A verb is a URI paired with a language map:

```C#
var id = new Uri("http://adlnet.gov/expapi/verbs/completed");
var definition = new LanguageMap(new LanguageTag(Language.English, Region.UnitedStates), "completed");
var verb = new Verb(id, definition);
```

An activity requires a definition and identifier; the definition needs a name, description, and type:

```C#
var name = LanguageMap.EnglishUS("Example Activity");
var description = LanguageMap.EnglishUS("An example activity.");
var theType = new Uri("http://adlnet.gov/expapi/activities/course");
var definition = new ActivityDefinition(name, description, theType);
var activityId = new Uri("http://www.example.com/example-activity");
var activity = new Activity(activityId, definition);
```

Combine the actor, verb, and activity into a statement:

```C#
var statement = new Statement(actor, verb, activity);
```

## About

Existing implementations of the xAPI specification for .NET do not leverage the type system to ensure code will run safely. Furthermore, many implementations allow a high degree of mutability, leading to undesired and unpredictable behavior.

This library is an attempt to address these challenges and leverage functional programming paradigms to create a reusable xAPI implementation that is suitable for a variety of .NET runtimes such as [ASP.NET](https://www.asp.net/) and [Xamarin](https://visualstudio.microsoft.com/xamarin/), while leveraging the unique capabilities of the [F# language](https://fsharp.org/) to create safe and predictable code. Furthermore, future improvements to this library could use [F*](https://www.fstar-lang.org/) to create code with verified runtime behavior, or leverage compilers such as [Fable](http://fable.io/) to generate JavaScript variants of this library.

This implementation is influenced by the existing [TinCan.NET](https://github.com/RusticiSoftware/TinCan.NET) and years of working with the xAPI specification.

## Roadmap

* Add missing type definitions
* Provide serialization logic
* Add implementation and interface for an LRS
* Improve build pipeline with [Fake](https://fake.build/)
* Provide a minimal example server implementation that passes the [LRS Test Suite](https://lrstest.adlnet.gov/)
* Publish library on [NuGet](https://www.nuget.org/)
* Add support for [xAPI Profiles](https://github.com/adlnet/xAPI-profiles)
* Determine viability of Fable compiler for JavaScript target
* Investigate use of F* to improve library with formal verification

## Notes

* C# [does not allow](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-structs) structs to have a [parameterless default constructor](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-constructors) defined, and auto-generates one for all structs. As a result, all struct types can be instantiated with a parameterless constructor, which for most of this library, will create an invalid instance. Note that this may conflict with the CLI [specification](https://www.ecma-international.org/publications/standards/Ecma-335.htm) and could be revised in future versions of C#. This is generally not an issue in F# as that language prevents initialization via default constructor when properties don't also support default constructors.

## License

All content in this repository is shared under an MIT license. See [license.md](./license.md) for details.
