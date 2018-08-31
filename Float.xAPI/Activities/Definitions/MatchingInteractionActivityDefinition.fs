// <copyright file="MatchingInteractionActivityDefinition.fs" company="Float">
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
/// An interaction where the learner is asked to match items in one set (the source set) to items in another set (the target set).
/// Items do not have to pair off exactly and it is possible for multiple or zero source items to be matched to a given target and vice versa.
/// </summary>
type public IMatchingInteractionActivityDefinition =
    /// <summary>
    /// Items in the first set to match.
    /// </summary>
    abstract member Source: seq<IInteractionComponent>

    /// <summary>
    /// Items in the second set to match.
    /// </summary>
    abstract member Target: seq<IInteractionComponent>

    inherit IInteractionActivityDefinition

[<NoEquality;NoComparison>]
type public MatchingInteractionActivityDefinition =
    struct
        /// <inheritdoc />
        val Name: ILanguageMap

        /// <inheritdoc />
        val Description: ILanguageMap

        /// <inheritdoc />
        val Type: Uri

        /// <inheritdoc />
        val MoreInfo: option<Uri>

        /// <inheritdoc />
        val Extensions: option<IExtensions>

        /// <summary>
        /// A list of matching pairs, where each pair consists of a source item id followed by a target item id.
        /// Items can appear in multiple (or zero) pairs. Items within a pair are delimited by [.].
        /// Pairs are delimited by [,]. 
        /// </summary>
        val CorrectResponsesPattern: seq<string>

        /// <inheritdoc />
        val Source: seq<IInteractionComponent>

        /// <inheritdoc />
        val Target: seq<IInteractionComponent>

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.MatchingInteractionActivityDefinition"/> struct.
        /// </summary>
        /// <param name="name">The human readable/visual name of the Activity.</param>
        /// <param name="description"A description of the Activity.</param>
        /// <param name="thetype">The type of Activity.</param>
        /// <param name="correctResponsesPattern">A pattern representing the correct response to the interaction.</param>
        /// <param name="source">Items in the first set to match.</param>
        /// <param name="target">Items in the second set to match.</param>
        /// <param name="moreInfo">Resolves to a document with human-readable information about the Activity.</param>
        /// <param name="extensions">A map of other properties as needed.</param>
        new(name, description, thetype, correctResponsesPattern, source, target, [<Optional;DefaultParameterValue(null)>] ?moreInfo, [<Optional;DefaultParameterValue(null)>] ?extensions) =
            nullArg name "name"
            emptySeqArg name "name"
            nullArg description "description"
            emptySeqArg description "description"
            nullArg thetype "thetype"
            { Name = name; Description = description; Type = thetype; CorrectResponsesPattern = correctResponsesPattern; Source = source; Target = target; MoreInfo = moreInfo; Extensions = extensions }

        override this.ToString() = sprintf "<%A: Name %A Description %A Type %A MoreInfo %A Extensions %A CorrectResponsesPattern %A Source %A Target %A>" (this.GetType().Name) this.Name this.Description this.Type this.MoreInfo this.Extensions this.CorrectResponsesPattern this.Source this.Target

        member this.InteractionType = Interaction.Matching

        interface IMatchingInteractionActivityDefinition with
            member this.Name = this.Name
            member this.Description = this.Description
            member this.Type = this.Type
            member this.MoreInfo = this.MoreInfo
            member this.Extensions = this.Extensions
            member this.InteractionType = this.InteractionType
            member this.CorrectResponsesPattern = this.CorrectResponsesPattern
            member this.Source = this.Source
            member this.Target = this.Target
    end
