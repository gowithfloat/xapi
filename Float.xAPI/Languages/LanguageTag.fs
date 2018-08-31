// <copyright file="LanguageTag.fs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Languages

open System
open System.Globalization
open System.Runtime.InteropServices
open Float.xAPI.Interop

/// <summary>
/// A language tag is composed from a sequence of one or more "subtags", each of which refines or narrows the range of language identified by the overall tag.
/// Subtags, in turn, are a sequence of alphanumeric characters (letters and digits), distinguished and separated from other subtags in a tag by a hyphen ("-", [Unicode] U+002D).
/// see: https://tools.ietf.org/html/rfc5646
/// </summary>
type public ILanguageTag =
    /// <summary>
    /// The primary language subtag is the first subtag in a language tag and cannot be omitted.
    /// </summary>
    abstract member PrimaryLanguage: Language

    /// <summary>
    /// Extended language subtags are used to identify certain specially selected languages that, for various historical and compatibility reasons, are closely identified with or tagged using an existing primary language subtag.
    /// Extended language subtags are always used with their enclosing primary language subtag (indicated with a 'Prefix' field in the registry) when used to form the language tag.
    /// All languages that have an extended language subtag in the registry also have an identical primary language subtag record in the registry.
    /// </summary>
    abstract member ExtendedLanguage: option<ExtendedLanguage>

    // todo: abstract member Script: option<Script>

    /// <summary>
    /// Region subtags are used to indicate linguistic variations associated with or appropriate to a specific country, territory, or region.
    /// Typically, a region subtag is used to indicate variations such as regional dialects or usage, or region-specific spelling conventions.
    /// It can also be used to indicate that content is expressed in a way that is appropriate for use throughout a region, for instance, Spanish content tailored to be useful throughout Latin America.
    /// </summary>
    abstract member Region: Region

    // todo: abstract member Variant: option<Variant>
    // todo: abstract member Extension: Extension
    // todo: abstract member PrivateUse: PrivateUse

    /// <summary>
    /// Convert this language tag to a system culture info object.
    /// </summary>
    abstract member ToCultureInfo: CultureInfo
    
[<CustomEquality;NoComparison>]
type public LanguageTag =
    struct
        /// <inheritdoc />
        val PrimaryLanguage: Language

        /// <inheritdoc />
        val ExtendedLanguage: option<ExtendedLanguage>

        /// <inheritdoc />
        val Region: Region
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Languages.LanguageTag"/> struct.
        /// </summary>
        /// <param name="primary">The primary language associated with this tag.</param>
        /// <param name="region">The region associated with this tag.</param>
        /// <param name="extended">An optional extended language to disambiguate dialects.</param>
        new (primary, region, [<Optional;DefaultParameterValue(null)>] ?extended) =
            nullArg primary "primary"
            nullArg region "region"
            { PrimaryLanguage = primary; ExtendedLanguage = extended; Region = region }

        /// <inheritdoc />
        member this.ToCultureInfo() = CultureInfo(this.ToString())

        /// <inheritdoc />
        override this.GetHashCode() = hash (this.PrimaryLanguage, this.Region)

        /// <inheritdoc />
        override this.Equals(other) =
            match other with
            | :? ILanguageTag as tag -> (this.PrimaryLanguage, this.Region) = (tag.PrimaryLanguage, tag.Region)
            | _ -> false

        /// <inheritdoc />
        override this.ToString() = 
            // see https://www.w3.org/International/articles/language-tags/
            // language-extlang-script-region-variant-extension-privateuse
            match this.ExtendedLanguage with
            | Some extended -> sprintf "%O-%O-%O" this.PrimaryLanguage extended this.Region
            | None -> sprintf "%O-%O" this.PrimaryLanguage this.Region

        interface IEquatable<ILanguageTag> with
            member this.Equals other = this.Equals other

        interface ILanguageTag with
            member this.PrimaryLanguage = this.PrimaryLanguage
            member this.ExtendedLanguage = this.ExtendedLanguage
            member this.Region = this.Region
            member this.ToCultureInfo = this.ToCultureInfo()

        /// <summary>
        /// As United States English is the most common language tag in examples, it is provided here for convenience.
        /// </summary>
        static member public EnglishUS: ILanguageTag =
            LanguageTag(Language.English, Region.UnitedStates) :> ILanguageTag
    end
    