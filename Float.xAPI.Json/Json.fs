// <copyright file="Json.cs" company="Float">
// Copyright (c) 2020 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Json

open System
open System.Collections.Generic
open Float.xAPI
open Float.xAPI.Activities
open Float.xAPI.Actor
open Float.xAPI.Actor.Identifier
open Float.xAPI.Languages
open Float.xAPI.Statements
open Newtonsoft.Json

/// <summary>
/// This module contains method for converting Float.xAPI objects to or from JSON strings.
/// </summary>
module Json =
    /// <summary>
    /// Convert a verb to a JSON string.
    /// </summary>
    let SerializeVerb (verb: IVerb) =
        sprintf "{\"id\":\"%s\",\"display\":%s}" verb.Id.Iri.AbsoluteUri (JsonConvert.SerializeObject verb.Display)

    let SerializeActor (actor: IActor) =
        sprintf "actor"

    let SerializeObject (object: IObject) =
        sprintf "object"

    let SerializeStatement (statement: IStatement) =
        let actor = SerializeActor(statement.Actor)
        let verb = SerializeVerb(statement.Verb)
        let object = SerializeObject(statement.Object)
        sprintf "{\"id\":\"%s\",\"actor\":\"%s\",\"verb\":\"%s\",\"object\":\"%s\"}" (statement.Id.ToString()) actor verb object

    /// <summary>
    /// Convert a language map to a JSON string.
    /// </summary>
    let SerializeLanguageMap (map: ILanguageMap) =
        map 
        |> Seq.map (fun (pair) -> sprintf "{\"%O\":\"%O\"}" pair.Key pair.Value)
        |> String.concat ","

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

    let DeserializeAccount str =
        let jsonAccount = JsonConvert.DeserializeObject<Map<string, string>>(str)
        Account(jsonAccount.["name"], Uri(jsonAccount.["homePage"]))

    let DeserializeActor str =
        let jsonActor = JsonConvert.DeserializeObject<Map<string, obj>>(str)
        let objstr = jsonActor.["objectType"] |> string
        let name = jsonActor.["name"] |> string
        let account = DeserializeAccount(jsonActor.["account"] |> string)

        match objstr with
        | "Agent" -> Agent(account, name) :> IActor
        | "Group" -> AnonymousGroup(Seq.empty, name) :> IActor
        | _ -> invalidArg "str" "Unable to convert JSON string to actor"

    let DeserializeObject str =
        let jsonObject = JsonConvert.DeserializeObject<Map<string, string>>(str)

        match jsonObject.["objectType"] |> string |> ObjectType.FromString with
        | Some Activity -> Activity(ActivityId(Uri(jsonObject.["id"])))
        | Some Agent -> invalidArg "todo" "todo"
        | Some Group -> invalidArg "todo" "todo"
        | Some SubStatement -> invalidArg "todo" "todo"
        | Some StatementReference -> invalidArg "todo" "todo"
        | None -> invalidArg "str" "Unable to convert JSON string to object"

    let private parseFloat (any: obj) =
        any |> string |> float |> Some

    let DeserializeScore str =
        let jsonScore = JsonConvert.DeserializeObject<Map<string, obj>>(str)
        let scaled = jsonScore.["scaled"] |> string |> float

        let raw = match jsonScore.ContainsKey "raw" with
                    | true -> jsonScore.["raw"] |> string |> float |> Some
                    | _ -> None

        let min = match jsonScore.ContainsKey "score" with
                  | true -> jsonScore.["score"] |> string |> float |> Some
                  | _ -> None

        let max = match jsonScore.ContainsKey "score" with
                  | true -> jsonScore.["score"] |> string |> float |> Some
                  | _ -> None

        match raw, min, max with
        | Some x, Some y, Some z -> Score(x, y, z) :> IScore
        | _ -> Score(scaled):> IScore

    let DeserializeResult str =
        let jsonResult = JsonConvert.DeserializeObject<Map<string, obj>>(str)

        let score = match jsonResult.ContainsKey "score" with
                    | true -> DeserializeScore(jsonResult.["score"] |> string) |> Some
                    | _ -> None

        let success = match jsonResult.ContainsKey "success" with
                      | true -> JsonConvert.DeserializeObject<bool>(jsonResult.["success"] |> string) |> Some
                      | _ -> None

        let completion = match jsonResult.ContainsKey "completion" with
                         | true -> JsonConvert.DeserializeObject<bool>(jsonResult.["completion"]|> string) |> Some
                         | _ -> None

        let response = match jsonResult.ContainsKey "response" with
                       | true -> jsonResult.["response"] |> string |> Some
                       | _ -> None

        let duration = match jsonResult.ContainsKey "duration" with
                       | true -> JsonConvert.DeserializeObject<TimeSpan>(jsonResult.["duration"]|> string) |> Some
                       | _ -> None

        let extensions = match jsonResult.ContainsKey "extensions" with
                         | true -> JsonConvert.DeserializeObject<IExtensions>(jsonResult.["extensions"]|> string) |> Some
                         | _ -> None

        Result(?score=score) :> IResult//, success, completion, response, duration, extensions)


    let DeserializeStatement str =
        let jsonStatement = JsonConvert.DeserializeObject<Map<string, obj>>(str)

        let id = match jsonStatement.ContainsKey "id" with
                 | true -> jsonStatement.["id"] |> string |> Guid
                 | _ -> invalidArg "id" "No ID for statement"

        let actor = match jsonStatement.ContainsKey "actor" with
                    | true -> DeserializeActor(jsonStatement.["actor"] |> string)
                    | _ -> invalidArg "actor" "No actor for statement"

        let verb = match jsonStatement.ContainsKey "verb" with
                   | true -> DeserializeVerb(jsonStatement.["verb"] |> string)
                   | _ -> invalidArg "verb" "No verb for statement"

        let target = match jsonStatement.ContainsKey "object" with
                     | true -> DeserializeObject(jsonStatement.["object"] |> string)
                     | _ -> invalidArg "object" "No object for statement"

        let result = match jsonStatement.ContainsKey "result" with
                     | true -> DeserializeResult(jsonStatement.["result"] |> string) |> Some
                     | _ -> None

        Statement(actor, verb, target, id, ?result=result)
        