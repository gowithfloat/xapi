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

/// <summary>
/// Another way of representing a tag and value as a tuple.
/// </summary>
type LanguageTuple = Tuple<ILanguageTag, string>

[<CustomEquality;NoComparison;Struct>]
type public LanguageMap =
    /// <summary>
    /// Internal storage of key/value pairs.
    /// Language maps could be a type abbreviation instead, but that prevents us from creating constructors or adding members.
    /// </summary>
    val private map: Map<ILanguageTag, string>

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Languages.LanguageMap"/> struct with a map of tag/value pairs.
    /// </summary>
    /// <param name="pairs">The language tag and value pairs.</param>
    public new(pairs) =
        nullArg pairs "pairs"
        emptySeqArg pairs "pairs"
        { map = pairs }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Languages.LanguageMap"/> struct with an enumerable of tag/value tuples.
    /// </summary>
    /// <param name="tuples">The language tag and value tuples.</param>
    public new(tuples: IEnumerable<LanguageTuple>) =
        nullArg tuples "tuples"
        emptySeqArg tuples "tuples"
        { map = tuples |> Map.ofSeq }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Languages.LanguageMap"/> struct with an enumerable of tag/value pairs.
    /// </summary>
    /// <param name="dict">The dictionary from which to construct this map.</param>
    public new(list: IEnumerable<LanguagePair>) =
        emptySeqArg list "list"
        { map = list |> Seq.map (|KeyValue|) |> Map.ofSeq}

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Languages.LanguageMap"/> struct with a readonly dictionary of tag/value pairs.
    /// </summary>
    /// <param name="dict">The dictionary from which to construct this map.</param>
    public new (map: ILanguageMap) =
        nullArg map "map"
        emptySeqArg map "map"
        { map = map |> Seq.map (|KeyValue|) |> Map.ofSeq }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Languages.LanguageMap"/> struct with one tag/value pair.
    /// </summary>
    /// <param name="languageTag">The language tag for the given value.</param>
    /// <param name="value">The value for the given tag.</param>
    public new(languageTag: ILanguageTag, value: string) =
        nullArg languageTag "languageTag"
        invalidStringArg value "value"
        { map = Map[languageTag, value] }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Languages.LanguageMap"/> struct with one language, region, and value.
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
    member this.Keys = this.Dict.Keys
    member this.Values = this.Dict.Values
    member this.Item
        with get(key) = this.Dict.[key]
    member this.TryGetValue(key: ILanguageTag, [<Out>] value: string byref) = this.Dict.TryGetValue(key, &value)

    interface IEquatable<ILanguageMap> with
        member this.Equals other = this.Equals other

    interface ILanguageMap with
        member this.Count = this.Count
        member this.ContainsKey key = this.ContainsKey key
        member this.GetEnumerator() = this.GetEnumerator()
        member this.GetEnumerator() = this.GetEnumerator() :> IEnumerator
        member this.Keys = this.Keys
        member this.Values = this.Values
        member this.Item
            with get(key) = this.[key]
        member this.TryGetValue(key: ILanguageTag, [<Out>] value: string byref) = this.TryGetValue(key, &value)

    static member EnglishUS value =
        LanguageMap(LanguageTag.EnglishUS, value)
    