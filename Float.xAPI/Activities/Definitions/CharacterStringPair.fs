// <copyright file="CharacterStringPair.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System.Collections.Generic
open System.Runtime.InteropServices
open Float.Interop
open Float.xAPI.Languages

/// <summary>
/// A list of matching pairs.
/// For matching interaction types, each pair consists of a source item ID followed by a target item ID.
/// For performance interaction types, this is a list of steps containing a step ID and the response to that step.
/// </summary>
[<NoEquality;NoComparison;Struct>]
type CharacterStringPair =
    /// <inheritdoc />
    val Items: (string * ICharacterString) seq

    /// <inheritdoc />
    val Language: ILanguageTag option

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.CharacterStringPair"/> struct.
    /// </summary>
    /// <param name="itemSeq">A sequence of string item and response tuples.</param>
    /// <param name="language">The language used within the item.</param>
    new (itemSeq: (string * ICharacterString) seq, [<Optional;DefaultParameterValue(null)>] ?language: ILanguageTag) =
        nullArg itemSeq "itemSeq"
        emptySeqArg itemSeq "itemSeq"
        invalidStringSeqArg (itemSeq |> Seq.map fst) "itemSeq"
        { Items = itemSeq; Language = language }
        
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.CharacterStringPair"/> struct.
    /// </summary>
    /// <param name="itemPairs">A sequence of string item and response pairs.</param>
    /// <param name="language">The language used within the item.</param>
    new (itemPairs: KeyValuePair<string, ICharacterString> seq, [<Optional;DefaultParameterValue(null)>] ?language: ILanguageTag) =
        nullArg itemPairs "itemPairs"
        emptySeqArg itemPairs "itemPairs"
        invalidStringSeqArg (itemPairs |> Seq.map (|KeyValue|) |> Seq.map fst) "itemSeq"
        { Items = itemPairs |> Seq.map (|KeyValue|); Language = language }

    /// <inheritdoc />
    member this.Match(str: string): ICharacterString option =
        this.Items |> Map.ofSeq |> Map.tryFind str

    /// <inheritdoc />
    member this.Match(pairs: (string * ICharacterString) seq): bool =
        (Map.ofSeq this.Items, Map.ofSeq pairs) ||> (=)
        
    /// <inheritdoc />
    member this.Match(pairs: KeyValuePair<string, ICharacterString> seq): bool =
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
        member this.Match(pairs: (string * ICharacterString) seq) = this.Match pairs
        