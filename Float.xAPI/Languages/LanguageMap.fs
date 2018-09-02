// <copyright file="LanguageMap.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Languages

open System
open System.Collections.Generic
open Float.xAPI.Interop

/// <summary>
/// A language map is a dictionary where the key is a RFC 5646 Language Tag, and the value is a string in the language specified in the tag.
/// This map SHOULD be populated as fully as possible based on the knowledge of the string in question in different languages.
/// </summary>
type ILanguageMap = IDictionary<ILanguageTag, string>

/// <summary>
/// A shorthand type for one element of a language map.
/// </summary>
type LanguagePair = KeyValuePair<ILanguageTag, string>

[<CustomEquality;NoComparison>]
type public LanguageMap =
    struct
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
        override this.Equals(other) =
            match other with
            | :? ILanguageMap as map -> this.GetHashCode() <> map.GetHashCode()
            | _ -> false

        member this.Add(item) = this.map.Add(item) |> ignore
        member this.Add(key, value) = this.map.Add(key, value) |> ignore
        member this.Contains(item) = this.map.ContainsKey(item)
        member this.ContainsKey key = this.map.ContainsKey key
        member this.Remove(key: LanguagePair) = this.map.Remove(key.Key)
        member this.Remove(key: ILanguageTag) = this.map.Remove(key)
        member this.TryGetValue(key, value) =
            match this.map.TryFind key with
            | Some value -> value
            | None -> null
        member this.Item(key) = this.map.Item(key)
        member this.Item(key, value) = this.Add(key, value)
        member this.Keys = this.map |> Map.toSeq |> Seq.map fst |> Seq.toArray :> ICollection<_>
        member this.Values = this.map |> Map.toSeq |> Seq.map snd |> Seq.toArray :> ICollection<_>
        member this.Count = this.map.Count
        member this.IsReadOnly = true
        member this.GetEnumerator<'T>() = (this.map |> Map.toSeq |> Seq.map(fun (a,b) -> LanguagePair(a, b))).GetEnumerator()

        interface IEquatable<ILanguageMap> with
            member this.Equals other =
                hash this = hash other

        interface ILanguageMap with
            member this.Add item = this.Add(item.Key, item.Value)
            member this.Add(key, value) = this.Add(key, value)
            member this.Contains item = this.ContainsKey(item.Key)
            member this.ContainsKey key = this.ContainsKey key
            member this.Remove(item: LanguagePair): bool =
                let count = this.get_Count()
                this.Remove(item) |> ignore
                count = this.get_Count()
            member this.Remove(key: ILanguageTag): bool =
                let count = this.get_Count()
                this.Remove(key) |> ignore
                count = this.get_Count()
            member this.TryGetValue(key, value) =
                match this.TryGetValue(key, value) with
                | null -> false
                | _ -> true
            member this.get_Item key = this.Item(key)
            member this.set_Item(key, value) = this.Item(key, value)
            member this.get_Keys() = this.Keys
            member this.get_Values() = this.Values
            member this.get_Count() = this.Count
            member this.get_IsReadOnly() = this.IsReadOnly
            member this.Clear() = notImplemented "Clear"
            member this.CopyTo(array, index) = notImplemented "CopyTo"
            member this.GetEnumerator(): IEnumerator<LanguagePair> = this.GetEnumerator()
            member this.GetEnumerator(): Collections.IEnumerator = this.GetEnumerator() :> Collections.IEnumerator

        static member EnglishUS value =
            LanguageMap(LanguageTag.EnglishUS, value)
    end
    