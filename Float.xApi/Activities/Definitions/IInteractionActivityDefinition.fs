// <copyright file="IInteractionActivityDefinition.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open Float.xAPI.Activities

/// <summary>
/// Traditional e-learning has included structures for interactions or assessments.
/// As a way to allow these practices and structures to extend Experience API's utility, this specification includes built-in definitions for interactions, which borrows from the SCORM 2004 4th Edition Data Model.
/// These definitions are intended to provide a simple and familiar utility for recording interaction data.
/// </summary>
type public IInteractionActivityDefinition =
    /// <summary>
    /// The type of interaction.
    /// </summary>
    abstract member InteractionType: Interaction

    /// <summary>
    /// A pattern representing the correct response to the interaction.
    /// The structure of this pattern varies depending on the InteractionType.
    /// </summary>
    abstract member CorrectResponsesPattern: seq<string>

    inherit IActivityDefinition
