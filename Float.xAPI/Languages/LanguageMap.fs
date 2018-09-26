// <copyright file="LanguageMap.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Languages

open System
open System.Collections
open System.Collections.Generic
open System.Runtime.InteropServices
open Float.xAPI.Interop

/// <summary>
/// A language map is a dictionary where the key is a RFC 5646 Language Tag, and the value is a string in the language specified in the tag.
/// This map SHOULD be populated as fully as possible based on the knowledge of the string in question in different languages.
/// </summary>
type public ILanguageMap = IReadOnlyDictionary<ILanguageTag, string>

/// <summary>
/// A shorthand type for one element of a language map.
/// </summary>
type LanguagePair = KeyValuePair<ILanguageTag, string>

[<CustomEquality;NoComparison;Struct>]
type public LanguageMap =
    /// <summary>
    /// Internal storage of key/value pairs.
    /// Language maps could be a type abbreviation instead, but that prevents us from creating constructors or adding members.
    /// </summary>
    val private map: Map<ILanguageTag, string>

    /// <summary>
    /// Construct a new language map with multiple key/value pairs.
    /// </summary>
    /// <param name="pairs">The language tag and value pairs.</param>
    public new(pairs) =
        nullArg pairs "pairs"
        emptySeqArg pairs "pairs"
        { map = pairs }

    /// <summary>
    /// Construct a new language map from any list of tag/value pairs.
    /// </summary>
    /// <param name="dict">The dictionary from which to construct this map.</param>
    public new(list: IList<LanguagePair>) =
        emptySeqArg list "list"
        { map = list :> seq<_> |> Seq.map (|KeyValue|) |> Map.ofSeq}

    /// <summary>
    /// Construct a new language map from any dictionary of tags and values.
    /// </summary>
    /// <param name="dict">The dictionary from which to construct this map.</param>
    public new (dict: ILanguageMap) =
        nullArg dict "dict"
        emptySeqArg dict "dict"
        { map = dict :> seq<_> |> Seq.map (|KeyValue|) |> Map.ofSeq }

    /// <summary>
    /// Construct a new language map with only one key/value pair.
    /// </summary>
    /// <param name="languageTag">The language tag for the given value.</param>
    /// <param name="value">The value for the given tag.</param>
    public new(languageTag: ILanguageTag, value: string) =
        nullArg languageTag "languageTag"
        invalidStringArg value "value"
        { map = Map[languageTag, value] }

    /// <summary>
    /// Construct a new language map with only one key/value pair.
    /// </summary>
    /// <param name="language">The language for the given value. Will be used to construct a LanguageTag object.</param>
    /// <param name="region">The region for the given value. Will be used to construct a LanguageTag object.</param>
    /// <param name="value">The value for the given tag.</param>
    public new(language, region, value) =
        invalidStringArg value "value"
        { map = Map[new LanguageTag(language, region) :> ILanguageTag, value] }

    /// <inheritdoc />
    override this.GetHashCode() = hash this.map

    /// <inheritdoc />
    override this.ToString() = sprintf "<%O: Map %O>" (this.GetType().Name) (seqToString this.map)

    /// <inheritdoc />
    override this.Equals other =
        match other with
        | :? ILanguageMap as map -> this.GetHashCode() = map.GetHashCode()
        | _ -> false

    static member op_Equality (lhs: LanguageMap, rhs: ILanguageMap) = lhs.Equals(rhs)
    static member op_Inequality (lhs: LanguageMap, rhs: ILanguageMap) = not(lhs.Equals(rhs))

    member private this.Dict = (this.map :> IReadOnlyDictionary<ILanguageTag, string>)
    member this.Count = this.map.Count
    member this.ContainsKey key = this.map.ContainsKey key
    member this.GetEnumerator() = this.Dict.GetEnumerator()
    member this.get_Keys() = this.Dict.get_Keys()
    member this.get_Values() = this.Dict.get_Values()
    member this.get_Item key = this.Dict.get_Item key
    member this.TryGetValue(key: ILanguageTag, [<Out>] value: string byref) = this.Dict.TryGetValue(key, ref value)

    interface IEquatable<ILanguageMap> with
        member this.Equals other = this.Equals other

    interface ILanguageMap with
        member this.Count = this.Count
        member this.ContainsKey key = this.ContainsKey key
        member this.GetEnumerator() = this.GetEnumerator()
        member this.GetEnumerator() = this.GetEnumerator() :> IEnumerator
        member this.get_Keys() = this.get_Keys()
        member this.get_Values() = this.get_Values()
        member this.get_Item key = this.get_Item key
        member this.TryGetValue(key: ILanguageTag, [<Out>] value: string byref) = this.TryGetValue(key, ref value)

    static member EnglishUS value =
        LanguageMap(LanguageTag.EnglishUS, value)
    