// <copyright file="Serialize.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Json

open System
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
module Serialize =
    /// <summary>
    /// Convert a verb to a JSON string.
    /// </summary>
    let Verb (verb: IVerb) =
        sprintf "{\"id\":\"%s\",\"display\":%s}" verb.Id.Iri.AbsoluteUri (JsonConvert.SerializeObject verb.Display)

    /// <summary>
    /// Convert an inverse functional identifier to a JSON string.
    /// </summary>
    let IFI (ifi: IInverseFunctionalIdentifier) =
        match ifi with
        | :? IAccount as acc -> sprintf "{\"homePage\":\"%s\",\"name\":\"%s\"}" acc.HomePage.AbsoluteUri acc.Name
        | :? IMailbox as mbox -> sprintf "{\"mbox\":\"%s\"}" (mbox.Address.ToString())
        | :? IMailboxSha1Sum as sha -> sprintf "{\"mbox_sha1sum\":\"%s\"}" (sha.MboxSha1Sum.ToString())
        | :? IOpenID as id -> sprintf "{\"openid\":\"%s\"}" id.OpenID.AbsoluteUri
        | _ -> invalidArg "ifi" "Not a valid IFI" // todo: make an IFI union to avoid this case

    /// <summary>
    /// Convert an activity to a JSON string.
    /// </summary>
    let Activity (act: IActivity) =
        // todo: make a more generic method of serializing objects
        sprintf "{\"id\":\"%s\",\"objectType\":\"Activity\"}" act.Id.Iri.AbsoluteUri

    /// <summary>
    /// Convert an actor to a JSON string.
    /// </summary>
    let Actor (actor: IActor) =
        match actor, actor.Name with
        | :? IIdentifiedActor as idActor, Some name -> sprintf "{\"objectType\":\"%s\",\"name\":\"%s\",\"account\":%s}" (actor.ObjectType.ToString()) name (IFI idActor.IFI)
        | :? IIdentifiedActor as idActor, _ -> sprintf "{\"objectType\":\"%s\",\"account\":%s}" (actor.ObjectType.ToString()) (IFI idActor.IFI)
        | _, Some name -> sprintf "{\"objectType\":\"%s\",\"name\":\"%s\"}" (actor.ObjectType.ToString()) name
        | _, _ -> sprintf "{\"objectType\":\"%s\"}" (actor.ObjectType.ToString())

    /// <summary>
    /// Convert an object to a JSON string.
    /// </summary>
    let Object (object: IObject) =
        match object with
        | :? IActivity as activity -> Activity activity
        | _ -> raise (NotImplementedException "test")

    /// <summary>
    /// Convert a score to a JSON string.
    /// </summary>
    let Score (score: IScore) =
        match score.Raw, score.Min, score.Max with
        | Some raw, Some min, Some max -> sprintf "{\"scaled\":%.2f,\"raw\":%.2f,\"min\":%.2f,\"max\":%.2f}" score.Scaled raw min max
        | _ -> sprintf "{scaled:\"%f\"}" score.Scaled

    /// <summary>
    /// Convert a result to a JSON string.
    /// </summary>
    let Result (result: IResult) =
        let mutable out = ""

        out <- match result.Score with
               | Some score -> out + sprintf "{\"score\":%s}," (Score score)
               | _ -> out

        out <- match result.Success with
               | Some false -> out + "\"success\":false,"
               | Some true -> out + "\"success\":true,"
               | _ -> out

        out <- match result.Duration with
               | Some duration -> out + sprintf "\"duration\":\"%s\"" (duration.ToString())
               | _ -> out

        out

    /// <summary>
    /// Convert a context to a JSON string.
    /// </summary>
    let Context (context: IContext) =
        "context"

    /// <summary>
    /// Convert a statement to a JSON string.
    /// </summary>
    let Statement (statement: IStatement) =
        let actor = Actor statement.Actor
        let verb = Verb statement.Verb
        let object = Object statement.Object
        let mutable output = sprintf "\"id\":\"%s\",\"actor\":%s,\"verb\":%s,\"object\":%s" (statement.Id.ToString()) actor verb object

        output <- match statement.Result with
                  | Some result -> output + sprintf ",\"result\":%s" (Result result)
                  | _ -> output

        output <- match statement.Context with
                  | Some context -> output + sprintf ",\"context\":%s" (Context context)
                  | _ -> output

        sprintf "{%s}" output

    /// <summary>
    /// Convert a language map to a JSON string.
    /// </summary>
    let LanguageMap (map: ILanguageMap) =
        map 
        |> Seq.map (fun (pair) -> sprintf "{\"%O\":\"%O\"}" pair.Key pair.Value)
        |> String.concat ","
