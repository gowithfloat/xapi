// <copyright file="IActivityProfileResource.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Resources.Documents

open System

/// The Activity Profile Resource is much like the State Resource, allowing for arbitrary key / document pairs to be saved which are related to an Activity.
type IActivityProfileResource =
    /// <summary>
    /// Stores or changes the specified Profile document in the context of the specified Activity.
    /// </summary>
    /// <param name="document">The document to be stored or updated.</param>
    abstract member PutActivityProfileDocument: IDocument -> unit

    /// <summary>
    /// Deletes the specified Profile document in the context of the specified Activity.
    /// </summary>
    /// <param name="activityId">The Activity id associated with this Profile document.</param>
    /// <param name="profileId">The profile id associated with this Profile document.</param>
    abstract member DeleteActivityProfileDocument: ActivityId * string -> unit

    /// <summary>
    /// Fetches the specified Profile document in the context of the specified Activity.
    /// </summary>
    /// <returns>The Profile document.</returns>
    /// <param name="activityId">The Activity id associated with this Profile document.</param>
    /// <param name="profileId">The profile id associated with this Profile document.</param>
    abstract member GetActivityProfileDocument: ActivityId * string -> IDocument

    /// <summary>
    /// Fetches the specified Profile document in the context of the specified Activity.
    /// If "since" parameter is specified, this is limited to entries that have been stored or updated since the specified Timestamp (exclusive).
    /// </summary>
    /// <returns>Array of Profile id(s).</returns>
    /// <param name="activityId">The Activity id associated with these Profile documents.</param>
    /// <param name="since">Only ids of Profile documents stored since the specified Timestamp (exclusive) are returned.</param>
    abstract member GetActivityProfileDocuments: ActivityId * DateTime -> ProfileId seq
