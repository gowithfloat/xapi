﻿// <copyright file="LongFillInInteractionActivityDefinition.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System
open System.Runtime.InteropServices
open Float.xAPI
open Float.xAPI.Activities
open Float.Interop
open Float.xAPI.Languages

/// <summary>
/// An interaction which requires the learner to supply a response in the form of a long string of characters.
/// "Long" means that the correct responses pattern and learner response strings will normally be more than 250 characters. 
/// </summary>
[<NoEquality;NoComparison;Struct>]
type public LongFillInInteractionActivityDefinition =
    /// <inheritdoc />
    val Name: ILanguageMap option

    /// <inheritdoc />
    val Description: ILanguageMap option

    /// <inheritdoc />
    val MoreInfo: Uri option

    /// <inheritdoc />
    val Extensions: IExtensions option

    /// <summary>
    /// A list of responses delimited by [,]. If the response contains only one item, the delimiter MUST not be used.
    /// </summary>
    val CorrectResponsesPattern: IResponsePattern

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.LongFillInInteractionActivityDefinition"/> struct.
    /// </summary>
    /// <param name="correctResponsesPattern">A pattern representing the correct response to the interaction.</param>
    /// <param name="name">The human readable/visual name of the Activity.</param>
    /// <param name="description">A description of the Activity.</param>
    /// <param name="moreInfo">Resolves to a document with human-readable information about the Activity.</param>
    /// <param name="extensions">A map of other properties as needed.</param>
    new(correctResponsesPattern, [<Optional;DefaultParameterValue(null)>] ?name, [<Optional;DefaultParameterValue(null)>] ?description, [<Optional;DefaultParameterValue(null)>] ?moreInfo, [<Optional;DefaultParameterValue(null)>] ?extensions) =
        nullArg correctResponsesPattern "correctResponsesPattern"
        emptyOptionalSeqArg extensions "extensions"
        { Name = name; Description = description; CorrectResponsesPattern = correctResponsesPattern; MoreInfo = moreInfo; Extensions = extensions }

    /// <inheritdoc />
    member this.Type = Definition.InteractionUri

    /// <inheritdoc />
    member this.InteractionType = LongFillIn

    interface IInteractionActivityDefinition with
        member this.Name = this.Name
        member this.Description = this.Description
        member this.Type = this.Type |> Some
        member this.MoreInfo = this.MoreInfo
        member this.Extensions = this.Extensions
        member this.InteractionType = this.InteractionType
        member this.CorrectResponsesPattern = this.CorrectResponsesPattern
