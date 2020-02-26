// <copyright file="Json.cs" company="Float">
// Copyright (c) 2020 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Json

open Float.xAPI
open Float.xAPI.Languages
open Newtonsoft.Json

/// <summary>
/// This module contains method for converting Float.xAPI objects to or from JSON strings.
/// </summary>
module Json =
    /// <summary>
    /// Convert a verb to a JSON string.
    /// </summary>
    let Serialize (verb: Verb) =
        sprintf "{\"id\":\"%s\",\"display\":%s}" verb.Id.Iri.AbsoluteUri (JsonConvert.SerializeObject verb.Display)

    /// <summary>
    /// Convert a pair of strings to a pair of language tag and string.
    /// </summary>
    let DeserializeLanguagePair strPair =
        match LanguageTag.FromString(fst(strPair)) with
        | Some x -> x :> ILanguageTag, snd(strPair)
        | None -> invalidArg "str1" (sprintf "Unable to convert language %O" strPair)

    /// <summary>
    /// Convert a string to a LanguageMap.
    /// </summary>
    let DeserializeLanguageMap str =
        JsonConvert.DeserializeObject<Map<string, string>>(str)
        |> Map.toSeq
        |> Seq.map DeserializeLanguagePair
        |> Map.ofSeq
        |> LanguageMap

    /// <summary>
    /// Convert a string to a Verb.
    /// </summary>
    let DeserializeVerb str =
        let jsonVerb = JsonConvert.DeserializeObject<Map<string, obj>>(str)
        Verb(VerbId(jsonVerb.["id"] |> string), jsonVerb.["display"] |> string |> DeserializeLanguageMap)
