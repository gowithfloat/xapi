// <copyright file="LanguageTag.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Languages

open System
open System.Globalization
open System.Runtime.InteropServices
open Float.Common.Interop

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
    abstract member ExtendedLanguage: ExtendedLanguage option

    // todo: abstract member Script: Script option

    /// <summary>
    /// Region subtags are used to indicate linguistic variations associated with or appropriate to a specific country, territory, or region.
    /// Typically, a region subtag is used to indicate variations such as regional dialects or usage, or region-specific spelling conventions.
    /// It can also be used to indicate that content is expressed in a way that is appropriate for use throughout a region, for instance, Spanish content tailored to be useful throughout Latin America.
    /// </summary>
    abstract member Region: Region option

    // todo: abstract member Variant: Variant option
    // todo: abstract member Extension: Extension
    // todo: abstract member PrivateUse: PrivateUse

    /// <summary>
    /// Convert this language tag to a system culture info object.
    /// </summary>
    abstract member ToCultureInfo: unit -> CultureInfo

    inherit IEquatable<ILanguageTag>
    inherit IComparable

[<CustomEquality;CustomComparison;Struct>]
type public LanguageTag =
    /// <inheritdoc />
    val PrimaryLanguage: Language

    /// <inheritdoc />
    val ExtendedLanguage: ExtendedLanguage option

    /// <inheritdoc />
    val Region: Region option
    
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Languages.LanguageTag"/> struct.
    /// </summary>
    /// <param name="primary">The primary language associated with this tag.</param>
    /// <param name="region">The region associated with this tag.</param>
    /// <param name="extended">An optional extended language to disambiguate dialects.</param>
    new (primary, [<Optional;DefaultParameterValue(null)>] ?region, [<Optional;DefaultParameterValue(null)>] ?extended) =
        nullArg primary "primary"
        { PrimaryLanguage = primary; ExtendedLanguage = extended; Region = region }

    /// <inheritdoc />
    member this.ToCultureInfo() = CultureInfo(this.ToString())

    /// <inheritdoc />
    override this.GetHashCode() = hash (this.PrimaryLanguage, this.Region)

    /// <inheritdoc />
    override this.Equals other =
        match other with
        | :? ILanguageTag as tag -> (this.PrimaryLanguage, this.Region) = (tag.PrimaryLanguage, tag.Region)
        | _ -> false

    static member op_Equality (lhs: LanguageTag, rhs: ILanguageTag) = lhs.Equals(rhs)
    static member op_Inequality (lhs: LanguageTag, rhs: ILanguageTag) = not(lhs.Equals(rhs))

    /// <inheritdoc />
    override this.ToString() = 
        // see https://www.w3.org/International/articles/language-tags/
        // language-extlang-script-region-variant-extension-privateuse
        let extPortion = match this.ExtendedLanguage with
                         | Some ext -> sprintf "-%O" ext
                         | None -> ""
        let regPortion = match this.Region with
                         | Some reg -> sprintf "-%O" reg
                         | None -> ""
        sprintf "%O%O%O" this.PrimaryLanguage extPortion regPortion

    interface ILanguageTag with
        member this.PrimaryLanguage = this.PrimaryLanguage
        member this.ExtendedLanguage = this.ExtendedLanguage
        member this.Region = this.Region
        member this.ToCultureInfo() = this.ToCultureInfo()
        member this.Equals other = this.Equals other

    interface IComparable with
        member this.CompareTo other =
            match other with
            | null -> 1
            | :? ILanguageTag as tag -> this.ToString().CompareTo(tag.ToString())
            | _ -> invalidArg "other" "Not a language tag"

    /// <summary>
    /// As United States English is the most common language tag in examples, it is provided here for convenience.
    /// </summary>
    static member public EnglishUS = LanguageTag(Language.English, Region.UnitedStates)
    