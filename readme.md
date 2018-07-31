# Float.xAPI

An F# implementation of the [https://xapi.com/](xAPI) specification with a focus on type safety and immutability. Wherever possible, we have strived to translate the [https://github.com/adlnet/xAPI-Spec](xAPI specification) directly to code, with requirements embedded as type checks.

## Status

This library is currently in a pre-release state. Feedback is welcome but active development continues and this library should not be considered ready for production use. However, we hope that the existing code base will provide an indication of the implementation goals for this project.

## About

Existing implementations of the xAPI specification for .NET do not leverage the type system to ensure code will run safely. Furthermore, many implementations allow a high degree of mutability, leading to undesired and unpredictable behavior.

This library is an attempt to address these challenges and leverage functional programming paradigms to create a reusable xAPI implementation that is suitable for a variety of .NET runtimes such as [https://www.asp.net/](ASP.NET) and [https://visualstudio.microsoft.com/xamarin/](Xamarin), while leveraging the unique capabilities of the [F# language](https://fsharp.org/) to create safe and predictable code. Furthermore, future improvements to this library could use [F*](https://www.fstar-lang.org/) to create code with verified runtime behavior, or leverage compilers such as [http://fable.io/](Fable) to generate JavaScript variants of this library.

This implementation is influenced by the existing [https://github.com/RusticiSoftware/TinCan.NET](TinCan.NET) and years of working with the xAPI specification.

## Roadmap

* Add missing type definitions
* Provide serialization logic
* Add implementation and interface for an LRS
* Publish library on [https://www.nuget.org/](NuGet)
* Determine viability of Fable compiler for JavaScript target
* Investigate use of F* to improve library with formal verification

## License

All content in this repository is shared under an MIT license. See [license.md](./license.md) for details.
