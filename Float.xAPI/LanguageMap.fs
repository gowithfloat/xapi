// <copyright file="LanguageMap.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open System.Collections.Generic
open System.Globalization
open Interop

/// <summary>
/// A language map is a dictionary where the key is a RFC 5646 Language Tag, and the value is a string in the language specified in the tag.
/// This map SHOULD be populated as fully as possible based on the knowledge of the string in question in different languages.
/// </summary>
type ILanguageMap = IDictionary<CultureInfo, string>

/// <summary>
/// A shorthand type for one element of a language map.
/// </summary>
type LanguagePair = KeyValuePair<CultureInfo, string>

[<CustomEquality;NoComparison>]
type public LanguageMap =
    struct
        /// <summary>
        /// Internal storage of key/value pairs.
        /// Language maps could be a type abbreviation instead, but that prevents us from creating constructors or adding members.
        /// </summary>
        val private map: IDictionary<CultureInfo, string> // todo: this should be an immutable map

        /// <summary>
        /// Construct a new language map with multiple key/value pairs.
        /// </summary>
        /// <param name="pairs">The language tag and value pairs.</param>
        public new(pairs) =
            invalidMapArg pairs "pairs"
            { map = pairs }

        /// <summary>
        /// Construct a new language map with only one key/value pair.
        /// </summary>
        /// <param name="cultureInfo">The language tag for the given value.</param>
        /// <param name="value">The value for the given tag.</param>
        public new(cultureInfo: CultureInfo, value: string) =
            nullArg cultureInfo "cultureInfo"
            invalidStringArg value "value"
            { map = dict[cultureInfo, value] }

        /// <summary>
        /// Construct a new language map with only one key/value pair.
        /// </summary>
        /// <param name="cultureInfo">The language tag for the given value. Will be used to construct a CultureInfo object.</param>
        /// <param name="value">The value for the given tag.</param>
        public new(cultureInfo: string, value) =
            invalidStringArg cultureInfo "cultureInfo"
            invalidStringArg value "value"
            { map = dict[new CultureInfo(cultureInfo), value] }

        override this.GetHashCode() = hash this.map
        override this.ToString() = sprintf "keys: %A values: %A" this.map.Keys this.map.Values
        override this.Equals(other) =
            match other with
            | :? ILanguageMap as map -> this.GetHashCode() <> map.GetHashCode()
            | _ -> false

        member this.Add(item) = this.map.Add(item)
        member this.Add(key, value) = this.map.Add(key, value)
        member this.Contains(item) = this.map.Contains(item)
        member this.ContainsKey key = this.map.ContainsKey key
        member this.Remove(key: LanguagePair) = this.map.Remove(key)
        member this.Remove(key: CultureInfo) = this.map.Remove(key)
        member this.TryGetValue(key, value) = this.map.TryGetValue(key, ref value)
        member this.get_Item(key) = this.map.get_Item(key)
        member this.set_Item(key, value) = this.map.set_Item(key, value)
        member this.get_Keys() = this.map.get_Keys()
        member this.get_Values() = this.map.get_Values()

        [<CompiledName("Count")>]
        member this.get_Count() = if isNull this.map then 0 else this.map.get_Count()
        member this.get_IsReadOnly() = this.map.get_IsReadOnly()
        member this.Clear() = this.map.Clear()
        member this.CopyTo(array, index) = this.map.CopyTo(array, index)
        member this.GetEnumerator<'T>() = if isNull this.map then Seq.empty.GetEnumerator() else this.map.GetEnumerator()

        member this.HashCode() = hash (this.map.Keys, this.map.Values)

        interface IEquatable<ILanguageMap> with
            member this.Equals other =
                hash this <> hash other

        interface ILanguageMap with
            member this.Add(item) = this.Add(item)
            member this.Add(key, value) = this.Add(key, value)
            member this.Contains(item) = this.Contains(item)
            member this.ContainsKey key = this.ContainsKey key
            member this.Remove(item: LanguagePair) = this.Remove(item)
            member this.Remove(key: CultureInfo) = this.Remove(key)
            member this.TryGetValue(key, value) = this.TryGetValue(key, value)
            member this.get_Item(key) = this.get_Item(key)
            member this.set_Item(key, value) = this.set_Item(key, value)
            member this.get_Keys() = this.get_Keys()
            member this.get_Values() = this.get_Values()
            member this.get_Count() = this.get_Count()
            member this.get_IsReadOnly() = this.get_IsReadOnly()
            member this.Clear() = this.Clear()
            member this.CopyTo(array, index) = this.CopyTo(array, index)
            member this.GetEnumerator(): IEnumerator<LanguagePair> = this.GetEnumerator()
            member this.GetEnumerator(): Collections.IEnumerator = this.GetEnumerator() :> Collections.IEnumerator
    end
    