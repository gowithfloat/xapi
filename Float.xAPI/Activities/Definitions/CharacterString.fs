// <copyright file="CharacterString.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System.Runtime.InteropServices
open Float.Common.Interop
open Float.xAPI.Languages

/// <summary>
/// The basic character string is a list of item identifiers.
/// This is used for true-false, choice, fill-in, long-fill-in, sequencing, likert, and "other" interaction types.
/// </summary>
[<NoEquality;NoComparison;Struct>]
type CharacterString =
    /// <inheritdoc />
    val Items: string seq

    /// <inheritdoc />
    val Language: ILanguageTag option 

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.CharacterString"/> struct.
    /// </summary>
    /// <param name="items">A list of string items.</param>
    /// <param name="language">The language used within the item.</param>
    new (items: string seq, [<Optional;DefaultParameterValue(null)>] ?language: ILanguageTag) =
        nullArg items "items"
        emptySeqArg items "items"
        invalidStringSeqArg items "items"
        { Items = items; Language = language }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.CharacterString"/> struct.
    /// </summary>
    /// <param name="item">A single string item.</param>
    /// <param name="language">The language used within the item.</param>
    new (item: string, [<Optional;DefaultParameterValue(null)>] ?language: ILanguageTag) =
        nullArg item "items"
        invalidStringArg item "item"
        { Items = [ item ] ; Language = language }

    /// <inheritdoc />
    member this.Match(str: string): bool =
        nullArg str "str"
        invalidStringArg str "str"
        match this.Items |> Seq.length with
        | 1 -> this.Items |> Seq.contains str
        | _ -> false

    /// <inheritdoc />
    member this.Match(strseq: string seq): bool =
        nullArg strseq "strseq"
        emptySeqArg strseq "strseq"
        invalidStringSeqArg strseq "strseq"
        this.Items |> Seq.exists(fun (str) -> strseq |> Seq.contains str)

    /// <inheritdoc />
    override this.ToString() = 
        match this.Language with
        | Some lang -> sprintf "{lang=%O}%O" lang (this.Items |> String.concat "[,]")
        | None -> this.Items |> String.concat "[,]"

    interface ICharacterStringSingle with
        member this.Items = this.Items
        member this.Language = this.Language
        member this.Match(str: string) = this.Match str
        member this.Match(strseq: string seq) = this.Match strseq
