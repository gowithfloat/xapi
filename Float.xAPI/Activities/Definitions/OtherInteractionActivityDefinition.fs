// <copyright file="OtherInteractionActivityDefinition.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System
open System.Runtime.InteropServices
open Float.xAPI
open Float.xAPI.Activities
open Float.xAPI.Interop
open Float.xAPI.Languages

/// <summary>
/// Another type of interaction that does not fit into those defined above.
/// </summary>
[<NoEquality;NoComparison;Struct>]
type public OtherInteractionActivityDefinition =
    /// <inheritdoc />
    val Name: ILanguageMap

    /// <inheritdoc />
    val Description: ILanguageMap

    /// <inheritdoc />
    val MoreInfo: Uri option

    /// <inheritdoc />
    val Extensions: IExtensions option

    /// <summary>
    /// Any format is valid within this string as appropriate for the type of interaction.
    /// </summary>
    val CorrectResponsesPattern: string seq

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.OtherInteractionActivityDefinition"/> struct.
    /// </summary>
    /// <param name="name">The human readable/visual name of the Activity.</param>
    /// <param name="description"A description of the Activity.</param>
    /// <param name="correctResponsesPattern">A pattern representing the correct response to the interaction.</param>
    /// <param name="moreInfo">Resolves to a document with human-readable information about the Activity.</param>
    /// <param name="extensions">A map of other properties as needed.</param>
    new(name, description, correctResponsesPattern, [<Optional;DefaultParameterValue(null)>] ?moreInfo, [<Optional;DefaultParameterValue(null)>] ?extensions) =
        nullArg name "name"
        emptySeqArg name "name"
        nullArg description "description"
        emptySeqArg description "description"
        { Name = name; Description = description; CorrectResponsesPattern = correctResponsesPattern; MoreInfo = moreInfo; Extensions = extensions }

    /// <inheritdoc />
    member this.Type = Uri("http://adlnet.gov/expapi/activities/cmi.interaction")

    /// <inheritdoc />
    member this.InteractionType = Other

    interface IInteractionActivityDefinition with
        member this.Name = this.Name
        member this.Description = this.Description
        member this.Type = this.Type
        member this.MoreInfo = this.MoreInfo
        member this.Extensions = this.Extensions
        member this.InteractionType = this.InteractionType
        member this.CorrectResponsesPattern = this.CorrectResponsesPattern
