// <copyright file="ContextActivities.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities

open System.Runtime.InteropServices
open Float.xAPI.Interop

/// <summary>
/// A map of the types of learning activity context that this Statement is related to.
/// </summary>
type public IContextActivities =
    /// <summary>
    /// An Activity with a direct relation to the Activity which is the Object of the Statement.
    /// In almost all cases there is only one sensible parent or none, not multiple.
    /// For example: a Statement about a quiz question would have the quiz as its parent Activity.
    /// </summary>
    abstract member Parent: option<seq<IActivity>>

    /// <summary>
    /// An Activity with an indirect relation to the Activity which is the Object of the Statement.
    /// For example: a course that is part of a qualification. The course has several classes. The course relates to a class as the parent, the qualification relates to the class as the grouping.
    /// </summary>
    abstract member Grouping: option<seq<IActivity>>

    /// <summary>
    /// An Activity used to categorize the Statement. "Tags" would be a synonym. 
    /// Category SHOULD be used to indicate a profile of xAPI behaviors, as well as other categorizations.
    /// For example: Anna attempts a biology exam, and the Statement is tracked using the cmi5 profile. The Statement's Activity refers to the exam, and the category is the cmi5 profile.
    /// </summary>
    abstract member Category: option<seq<IActivity>>

    /// <summary>
    /// A contextActivity that doesn't fit one of the other properties.
    /// For example: Anna studies a textbook for a biology exam. The Statement's Activity refers to the textbook, and the exam is a contextActivity of type other.
    /// </summary>
    abstract member Other: option<seq<IActivity>>

[<NoEquality;NoComparison;Struct>]
type public ContextActivities =
    /// <inheritdoc />
    val Parent: option<seq<IActivity>> // todo: provide a constructor with one parent

    /// <inheritdoc />
    val Grouping: option<seq<IActivity>>

    /// <inheritdoc />
    val Category: option<seq<IActivity>>

    /// <inheritdoc />
    val Other: option<seq<IActivity>>

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activity.ContextActivities"/> struct.
    /// </summary>
    /// <param name="parent">An Activity with a direct relation to the Activity which is the Object of the Statement.</param>
    /// <param name="grouping">An Activity with an indirect relation to the Activity which is the Object of the Statement.</param>
    /// <param name="category">An Activity used to categorize the Statement.</param>
    /// <param name="other">A contextActivity that doesn't fit one of the other properties.</param>
    new ([<Optional;DefaultParameterValue(null)>] ?parent, [<Optional;DefaultParameterValue(null)>] ?grouping, [<Optional;DefaultParameterValue(null)>] ?category, [<Optional;DefaultParameterValue(null)>] ?other) =
        emptyOptionalSeqArg parent "parent"
        emptyOptionalSeqArg grouping "grouping"
        emptyOptionalSeqArg category "category"
        emptyOptionalSeqArg other "other"
        { Parent = parent; Grouping = grouping; Category = category; Other = other }

    override this.ToString() = 
        sprintf "<%O: %O %O %O %O>" (typeName this) (seqToStringOrNone this.Parent "Parent") (seqToStringOrNone this.Grouping "Grouping") (seqToStringOrNone this.Category "Category") (seqToStringOrNone this.Other "Other")

    interface IContextActivities with
        member this.Parent = this.Parent
        member this.Grouping = this.Grouping
        member this.Category = this.Category
        member this.Other = this.Other
