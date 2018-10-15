// <copyright file="CharacterStringPair.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System.Collections.Generic
open System.Runtime.InteropServices
open Float.xAPI.Interop
open Float.xAPI.Languages

// todo: the spec says responses can be a string or number range; should `Items` here be (string * ICharacterString) seq ?

/// <summary>
/// A list of matching pairs.
/// For matching interaction types, each pair consists of a source item ID followed by a target item ID.
/// For performance interaction types, this is a list of steps containing a step ID and the response to that step.
/// </summary>
[<NoEquality;NoComparison;Struct>]
type CharacterStringPair =
    /// <inheritdoc />
    val Items: (string * string) seq

    /// <inheritdoc />
    val Language: ILanguageTag option

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.CharacterStringPair"/> struct.
    /// </summary>
    /// <param name="itemSeq">A sequence of string item and response tuples.</param>
    /// <param name="language">The language used within the item.</param>
    new (itemSeq: (string * string) seq, [<Optional;DefaultParameterValue(null)>] ?language: ILanguageTag) =
        nullArg itemSeq "itemSeq"
        emptySeqArg itemSeq "itemSeq"
        invalidStringSeqArg (itemSeq |> Seq.map fst) "itemSeq"
        invalidStringSeqArg (itemSeq |> Seq.map snd) "itemSeq"
        { Items = itemSeq; Language = language }
        
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.CharacterStringPair"/> struct.
    /// </summary>
    /// <param name="itemPairs">A sequence of string item and response pairs.</param>
    /// <param name="language">The language used within the item.</param>
    new (itemPairs: KeyValuePair<string, string> seq, [<Optional;DefaultParameterValue(null)>] ?language: ILanguageTag) =
        nullArg itemPairs "itemPairs"
        emptySeqArg itemPairs "itemPairs"
        invalidStringSeqArg (itemPairs |> Seq.map (|KeyValue|) |> Seq.map fst) "itemSeq"
        invalidStringSeqArg (itemPairs |> Seq.map (|KeyValue|) |> Seq.map snd) "itemSeq"
        { Items = itemPairs |> Seq.map (|KeyValue|); Language = language }

    /// <inheritdoc />
    member this.Match(str: string): string option =
        this.Items |> Map.ofSeq |> Map.tryFind str

    /// <inheritdoc />
    member this.Match(pairs: (string * string) seq): bool = 
        (Seq.sort this.Items, Seq.sort pairs) ||> Seq.forall2 (=)

    /// <inheritdoc />
    member this.Match(pairs: KeyValuePair<string, string> seq): bool =
        pairs |> Seq.map (|KeyValue|) |> Seq.except this.Items |> Seq.isEmpty

    /// <inheritdoc />
    override this.ToString() = 
        match this.Language with
        | Some lang -> sprintf "{lang=%O}%O" lang (this.Items |> Seq.map(fun(x) -> sprintf "%O[.]%O" (fst x) (snd x)) |> String.concat "[,]")
        | None -> this.Items |> Seq.map(fun(x) -> sprintf "%O[.]%O" (fst x) (snd x)) |> String.concat "[,]"

    interface ICharacterStringPair with
        member this.Items = this.Items
        member this.Language = this.Language
        member this.Match(str: string) = this.Match str
        member this.Match(pairs: (string * string) seq) = this.Match pairs
        