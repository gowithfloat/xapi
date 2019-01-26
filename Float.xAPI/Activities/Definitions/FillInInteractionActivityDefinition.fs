// <copyright file="FillInInteractionActivityDefinition.fs" company="Float">
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
/// An interaction which requires the learner to supply a short response in the form of one or more strings of characters.
/// Typically, the correct response consists of part of a word, one word or a few words.
/// "Short" means that the correct responses pattern and learner response strings will normally be 250 characters or less. 
/// </summary>
[<NoEquality;NoComparison;Struct>]
type public FillInInteractionActivityDefinition =
    /// <inheritdoc />
    val Name: ILanguageMap

    /// <inheritdoc />
    val Description: ILanguageMap

    /// <inheritdoc />
    val MoreInfo: Uri option

    /// <inheritdoc />
    val Extensions: IExtensions option

    /// <summary>
    /// A list of responses delimited by [,]. If the response contains only one item, the delimiter MUST not be used.
    /// </summary>
    val CorrectResponsesPattern: IResponsePattern

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.FillInInteractionActivityDefinition"/> struct.
    /// </summary>
    /// <param name="name">The human readable/visual name of the Activity.</param>
    /// <param name="description">A description of the Activity.</param>
    /// <param name="correctResponsesPattern">A pattern representing the correct response to the interaction.</param>
    /// <param name="moreInfo">Resolves to a document with human-readable information about the Activity.</param>
    /// <param name="extensions">A map of other properties as needed.</param>
    new(name, description, correctResponsesPattern, [<Optional;DefaultParameterValue(null)>] ?moreInfo, [<Optional;DefaultParameterValue(null)>] ?extensions) =
        nullArg name "name"
        emptySeqArg name "name"
        nullArg description "description"
        emptySeqArg description "description"
        nullArg correctResponsesPattern "correctResponsesPattern"
        { Name = name; Description = description; CorrectResponsesPattern = correctResponsesPattern; MoreInfo = moreInfo; Extensions = extensions }

    /// <inheritdoc />
    member this.Type = Definition.InteractionUri

    /// <inheritdoc />
    member this.InteractionType = FillIn

    interface IInteractionActivityDefinition with
        member this.Name = this.Name
        member this.Description = this.Description
        member this.Type = this.Type
        member this.MoreInfo = this.MoreInfo
        member this.Extensions = this.Extensions
        member this.InteractionType = this.InteractionType
        member this.CorrectResponsesPattern = this.CorrectResponsesPattern
