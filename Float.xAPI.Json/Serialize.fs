// <copyright file="Serialize.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Json

open System
open System.Collections.Generic
open System.Runtime.InteropServices
open System.Xml
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
        let output = new List<string>()
        output.Add(sprintf "\"id\":\"%s\"" act.Id.Iri.AbsoluteUri)
        output.Add("\"objectType\":\"Activity\"")
        sprintf "{%s}" (String.Join(",", output))

    let ShortActivity (act: IActivity) =
        let output = new List<string>()
        output.Add(sprintf "\"id\":\"%s\"" act.Id.Iri.AbsoluteUri)
        sprintf "{%s}" (String.Join(",", output))

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
        | _ -> raise (NotImplementedException "test") // todo: make an object union

    /// <summary>
    /// Convert a score to a JSON string.
    /// </summary>
    let Score (score: IScore) =
        match score.Raw, score.Min, score.Max with
        | Some raw, Some min, Some max -> sprintf "{\"scaled\":%A,\"raw\":%A,\"min\":%A,\"max\":%A}" score.Scaled raw min max
        | _ -> sprintf "{scaled:\"%f\"}" score.Scaled

    /// <summary>
    /// Convert extensions to a JSON string.
    /// </summary>
    let Extensions (extensions: IExtensions) =
        extensions 
        |> Seq.map (fun (pair) -> sprintf "{\"%O\":%A}" pair.Key pair.Value)
        |> String.concat ","

    /// <summary>
    /// Convert a result to a JSON string.
    /// </summary>
    let Result (result: IResult) =
        let output = new List<string>()

        match result.Score with
        | Some score -> output.Add(sprintf "\"score\":%s" (Score score))
        | _ -> ()

        match result.Success with
        | Some false -> output.Add("\"success\":false")
        | Some true -> output.Add("\"success\":true")
        | _ -> ()

        match result.Duration with
        | Some duration -> output.Add(sprintf "\"duration\":\"%s\"" (XmlConvert.ToString(duration)))
        | _ -> ()

        match result.Extensions with
        | Some extensions -> output.Add(sprintf "\"extensions\":%s" (Extensions extensions))
        | _ -> ()

        sprintf "{%s}" (String.Join(",", output))

    let private Activities (activities: IActivity seq) =
        activities
        |> Seq.map (fun (a) -> (ShortActivity a))
        |> String.concat ","
        |> sprintf "[%s]"

    let ContextActivities (activities: IContextActivities) =
        let output = new List<string>()

        match activities.Parent with
        | Some parent -> output.Add(sprintf "\"parent\":%s" (Activities parent))
        | _ -> ()

        match activities.Grouping with
        | Some grouping -> output.Add(sprintf "\"grouping\":%s" (Activities grouping))
        | _ -> ()

        match activities.Category with
        | Some category -> output.Add(sprintf "\"category\":%s" (Activities category))
        | _ -> ()

        match activities.Other with
        | Some other -> output.Add(sprintf "\"other\":%A" (Activities other))
        | _ -> ()

        sprintf "{%s}" (String.Join(",", output))

    /// <summary>
    /// Convert a context to a JSON string.
    /// </summary>
    let Context (context: IContext) =
        let output = new List<string>()

        match context.Registration with
        | Some registration -> output.Add(sprintf "\"registration\":\"%s\"" (registration.ToString()))
        | _ -> ()

        match context.Instructor with
        | Some instructor -> output.Add(sprintf "\"instructor\":%s" (Actor instructor))
        | _ -> ()

        match context.Team with
        | Some team -> output.Add(sprintf "\"team\":%s" (Actor team))
        | _ -> ()

        match context.ContextActivities with
        | Some activities -> output.Add(sprintf "\"contextActivities\":%s" (ContextActivities activities))
        | _ -> ()

        match context.Extensions with
        | Some extensions -> output.Add(sprintf "\"extensions\":%s" (Extensions extensions))
        | _ -> ()

        sprintf "{%s}" (String.Join(",", output))

    /// <summary>
    /// Convert a statement to a JSON string.
    /// </summary>
    let Statement (statement: IStatement) =
        let output = new List<string>()
        output.Add(sprintf "\"id\":\"%s\"" (statement.Id.ToString()))
        output.Add(sprintf "\"actor\":%s" (Actor statement.Actor))
        output.Add(sprintf "\"verb\":%s" (Verb statement.Verb))
        output.Add(sprintf "\"object\":%s" (Object statement.Object))

        match statement.Result with
        | Some result -> output.Add(sprintf "\"result\":%s" (Result result))
        | _ -> ()

        match statement.Context with
        | Some context -> output.Add(sprintf "\"context\":%s" (Context context))
        | _ -> ()

        match statement.Timestamp with
        | Some timestamp -> output.Add(sprintf "\"timestamp\":%A" (timestamp.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffK")))
        | _ -> ()

        sprintf "{%s}" (String.Join(",", output))

    /// <summary>
    /// Convert a language map to a JSON string.
    /// </summary>
    let LanguageMap (map: ILanguageMap) =
        map 
        |> Seq.map (fun (pair) -> sprintf "{\"%O\":\"%O\"}" pair.Key pair.Value)
        |> String.concat ","
