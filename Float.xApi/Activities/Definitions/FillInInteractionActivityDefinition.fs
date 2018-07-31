// <copyright file="FillInInteractionActivityDefinition.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System
open Float.xAPI
open Float.xAPI.Activities

/// <summary>
/// An interaction which requires the learner to supply a short response in the form of one or more strings of characters.
/// Typically, the correct response consists of part of a word, one word or a few words.
/// "Short" means that the correct responses pattern and learner response strings will normally be 250 characters or less. 
/// </summary>
[<NoEquality;NoComparison>]
type public FillInInteractionActivityDefinition =
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
        /// A list of responses delimited by [,]. If the response contains only one item, the delimiter MUST not be used.
        /// </summary>
        val CorrectResponsesPattern: seq<string>

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions."/> struct.
        /// </summary>
        /// <param name="name">The human readable/visual name of the Activity.</param>
        /// <param name="description"A description of the Activity.</param>
        /// <param name="thetype">The type of Activity.</param>
        /// <param name="correctResponsesPattern">A pattern representing the correct response to the interaction.</param>
        /// <param name="moreInfo">Resolves to a document with human-readable information about the Activity.</param>
        /// <param name="extensions">A map of other properties as needed.</param>
        new(name, description, thetype, correctResponsesPattern, ?moreInfo, ?extensions) =
            { Name = name; Description = description; Type = thetype; CorrectResponsesPattern = correctResponsesPattern; MoreInfo = moreInfo; Extensions = extensions }

        override this.ToString() = sprintf "%A %A %A %A %A %A" this.Name this.Description this.Type this.MoreInfo this.Extensions this.CorrectResponsesPattern

        member this.InteractionType = Interaction.FillIn

        interface IInteractionActivityDefinition with
            member this.Name = this.Name
            member this.Description = this.Description
            member this.Type = this.Type
            member this.MoreInfo = this.MoreInfo
            member this.Extensions = this.Extensions
            member this.InteractionType = this.InteractionType
            member this.CorrectResponsesPattern = this.CorrectResponsesPattern
    end
