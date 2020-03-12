// <copyright file="IContext.fs" company="(c) Float">
// Copyright (c) 2018 (c) Float, LLC, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Statements

open System
open Float.xAPI
open Float.xAPI.Actors
open Float.xAPI.Activities
open Float.xAPI.Languages

/// <summary>
/// An optional property that provides a place to add contextual information to a Statement.
/// </summary>
type public IContext =
    /// <summary>
    /// The registration that the Statement is associated with.
    /// </summary>
    abstract member Registration: Guid option

    /// <summary>
    /// Instructor that the Statement relates to, if not included as the Actor of the Statement.
    /// </summary>
    abstract member Instructor: Actor option

    /// <summary>
    /// Team that this Statement relates to, if not included as the Actor of the Statement.
    /// </summary>
    abstract member Team: IGroup option

    /// <summary>
    /// A map of the types of learning activity context that this Statement is related to.
    /// </summary>
    abstract member ContextActivities: IContextActivities option

    /// <summary>
    /// Revision of the learning activity associated with this Statement. Format is free.
    /// </summary>
    abstract member Revision: string option

    /// <summary>
    /// Platform used in the experience of this learning activity.
    /// </summary>
    abstract member Platform: string option

    /// <summary>
    /// Code representing the language in which the experience being recorded in this Statement (mainly) occurred in, if applicable and known.
    /// </summary>
    abstract member Language: ILanguageTag option

    /// <summary>
    /// Another Statement to be considered as context for this Statement.
    /// </summary>
    abstract member Statement: IStatementReference option

    /// <summary>
    /// A map of any other domain-specific context relevant to this Statement.
    /// </summary>
    abstract member Extensions: IExtensions option
