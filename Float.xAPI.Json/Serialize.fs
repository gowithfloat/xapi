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
open Float.xAPI.Activities.Definitions
open Float.xAPI.Actors
open Float.xAPI.Actors.Identifier
open Float.xAPI.Languages
open Float.xAPI.Statements
open Newtonsoft.Json

/// <summary>
/// This module contains method for converting Float.xAPI objects to or from JSON strings.
/// </summary>
module Serialize =
    /// <summary>
    /// Convert a time span to a string in the expected xAPI format.
    /// </summary>
    let private durationString (d: TimeSpan) =
        XmlConvert.ToString(d)

    /// <summary>
    /// Wrap a string in quotes.
    /// </summary>
    let private quoteWrap s =
        sprintf "\"%s\"" s

    /// <summary>
    /// Escape backslashes in a string
    /// </summary>
    let private escape s = 
        s |> String.collect (fun c -> match c with
                                      | '\\' -> "\\\\"
                                      | _ -> sprintf "%c" c)

    /// <summary>
    /// An F#-friendly wrapper for the C# string join method.
    /// </summary>
    let private commaJoinSeq (s: seq<_>) =
        String.Join(",", s)

    /// <summary>
    /// Convert key/value pairs into a JSON string, e.g. "{\"key\":value}".
    /// </summary>
    let private dictToJson (m: IDictionary<_, _>) =
        m
        |> Seq.map (|KeyValue|)  
        |> Seq.map (fun (k,v) -> sprintf "\"%s\":%O" k v)
        |> commaJoinSeq
        |> sprintf "{%s}"
    
    /// <summary>
    /// Convert an activity to a JSON string, but without the object type identifier.
    /// </summary>
    let private ShortActivity (act: IActivity) =
        let output = new Dictionary<string, obj>()
        output.Add("id", act.Id.ToString() |> quoteWrap)
        output |> dictToJson

    /// <summary>
    /// Convert an array of activities to a JSON string.
    /// </summary>
    let private Activities (activities: IActivity seq) =
        activities
        |> Seq.map (fun (a) -> (ShortActivity a))
        |> String.concat ","
        |> sprintf "[%s]"

    /// <summary>
    /// Convert a verb to a JSON string.
    /// </summary>
    let Verb (verb: IVerb) =
        let output = new Dictionary<string, obj>()
        output.Add("id", verb.Id.ToString() |> quoteWrap)
        output.Add("display", verb.Display |> JsonConvert.SerializeObject)
        output |> dictToJson

    /// <summary>
    /// Convert an inverse functional identifier to a JSON string.
    /// </summary>
    let IFI (ifi: IInverseFunctionalIdentifier) =
        match ifi with
        | :? IAccount as acc -> sprintf "{\"homePage\":\"%s\",\"name\":\"%s\"}" acc.HomePage.AbsoluteUri acc.Name
        | :? IMailbox as mbox -> sprintf "\"%s\"" (mbox.ToString())
        | :? IMailboxSha1Sum as sha -> sprintf "\"%s\"" (sha.MboxSha1Sum.ToString())
        | :? IOpenID as id -> sprintf "\"%s\"" id.OpenID.AbsoluteUri
        | _ -> invalidArg "ifi" "Not a valid IFI" // todo: make an IFI union to avoid this case

    /// <summary>
    /// Convert a language map to a JSON string.
    /// </summary>
    let LanguageMap (map: ILanguageMap) =
        map 
        |> Seq.map (|KeyValue|) 
        |> Seq.map (fun (k,v) -> k.ToString(), v |> quoteWrap) 
        |> Map.ofSeq 
        |> dictToJson

    let ActivityDefinition (def: IActivityDefinition) =
        let output = new Dictionary<string, obj>()

        match def.Name with
        | Some name -> output.Add("name", name |> LanguageMap)
        | None -> ()

        match def.Description with
        | Some desc -> output.Add("description", desc |> LanguageMap)
        | None -> ()

        output |> dictToJson


    /// <summary>
    /// Convert an activity to a JSON string.
    /// </summary>
    let Activity (act: IActivity) =
        let output = new Dictionary<string, obj>()
        output.Add("objectType", "Activity" |> quoteWrap)
        output.Add("id", act.Id.ToString() |> quoteWrap)

        match act.Definition with
        | Some def -> output.Add("definition", def |> ActivityDefinition)
        | None -> ()

        output |> dictToJson

    /// <summary>
    /// Convert an actor to a JSON string.
    /// </summary>
    let Actor (actor: Actor) =
        let output = new Dictionary<string, obj>()

        match actor.Item.Name with
        | Some name -> output.Add("name", name |> quoteWrap)
        | _ -> ()

        match actor with
        | Agent agent -> output.Add("objectType", "Agent" |> quoteWrap)
        | IdentifiedGroup group -> output.Add("objectType", "Group" |> quoteWrap)
        | AnonymousGroup group -> output.Add("objectType", "Group" |> quoteWrap)

        match actor.Item with
        | :? IIdentifiedActor as idActor ->
            match idActor.IFI with
            | Mailbox mbox -> output.Add("mbox", mbox |> IFI)
            | MailboxSha1Sum sha -> output.Add("mbox_sha1sum", sha |> IFI)
            | OpenID id -> output.Add("openid", id |> IFI)
            | Account account -> output.Add("account", account |> IFI)
        | _ -> ()

        output |> dictToJson

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
        let output = new Dictionary<string, obj>()
        output.Add("scaled", score.Scaled)

        match score.Raw with
        | Some raw -> output.Add("raw", raw)
        | _ -> ()

        match score.Min with
        | Some min -> output.Add("min", min)
        | _ -> ()

        match score.Max with
        | Some max -> output.Add("max", max)
        | _ -> ()

        output |> dictToJson

    /// <summary>
    /// Convert extensions to a JSON string.
    /// </summary>
    let Extensions (extensions: IExtensions) =
        extensions 
        |> Seq.map (|KeyValue|) 
        |> Seq.map (fun (k,v) -> k.AbsoluteUri, (sprintf "%A" v) |> escape)
        |> Map.ofSeq 
        |> dictToJson

    /// <summary>
    /// Convert a result to a JSON string.
    /// </summary>
    let Result (result: IResult) =
        let output = new Dictionary<string, obj>()

        match result.Score with
        | Some score -> output.Add("score", score |> Score)
        | _ -> ()

        match result.Success with
        | Some false -> output.Add("success", "false")
        | Some true -> output.Add("success", "true")
        | _ -> ()

        match result.Completion with
        | Some false -> output.Add("completion", "false")
        | Some true -> output.Add("completion", "true")
        | _ -> ()

        match result.Duration with
        | Some duration -> output.Add("duration", duration |> durationString |> quoteWrap)
        | _ -> ()

        match result.Extensions with
        | Some extensions -> output.Add("extensions", extensions |> Extensions)
        | _ -> ()

        output |> dictToJson
    
    /// <summary>
    /// Convert context activities to a JSON string.
    /// </summary>
    let ContextActivities (activities: IContextActivities) =
        let output = new Dictionary<string, obj>()

        match activities.Parent with
        | Some parent -> output.Add("parent", parent |> Activities)
        | _ -> ()

        match activities.Grouping with
        | Some grouping -> output.Add("grouping", grouping |> Activities)
        | _ -> ()

        match activities.Category with
        | Some category -> output.Add("category", category |> Activities)
        | _ -> ()

        match activities.Other with
        | Some other -> output.Add("other", other |> Activities)
        | _ -> ()

        output |> dictToJson

    /// <summary>
    /// Convert a context to a JSON string.
    /// </summary>
    let Context (context: IContext) =
        let output = new Dictionary<string, obj>()

        match context.Registration with
        | Some registration -> output.Add("registration", registration.ToString() |> quoteWrap)
        | _ -> ()

        match context.Instructor with
        | Some instructor -> output.Add("instructor", instructor |> Actor)
        | _ -> ()

        match context.Team with
        | Some team -> output.Add("team", team |> Actors.Actor.From |> Actor)
        | _ -> ()

        match context.ContextActivities with
        | Some activities -> output.Add("contextActivities", activities |> ContextActivities)
        | _ -> ()

        match context.Extensions with
        | Some extensions -> output.Add("extensions", extensions |> Extensions)
        | _ -> ()

        output |> dictToJson

    /// <summary>
    /// Convert a statement to a JSON string.
    /// </summary>
    let Statement (statement: IStatement) =
        let output = new Dictionary<string, obj>()
        output.Add("id", statement.Id.ToString() |> quoteWrap)
        output.Add("actor", statement.Actor |> Actor)
        output.Add("verb", statement.Verb |> Verb)
        output.Add("object", statement.Object |> Object)

        match statement.Result with
        | Some result -> output.Add("result", result |> Result)
        | _ -> ()

        match statement.Context with
        | Some context -> output.Add("context", context |> Context)
        | _ -> ()

        match statement.Timestamp with
        | Some timestamp -> output.Add("timestamp", timestamp.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffK") |> quoteWrap)
        | _ -> ()

        output |> dictToJson
