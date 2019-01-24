// <copyright file="IAgentProfileResource.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Resources.Documents

open System
open System.Runtime.InteropServices
open Float.xAPI.Actor

/// <summary>
/// The Agent Profile Resource is much like the State Resource, allowing for arbitrary key / document pairs to be saved which are related to an Agent.
/// </summary>
type IAgentProfileResource =
    /// <summary>
    /// Stores or changes the specified Profile document in the context of the specified Agent.
    /// </summary>
    /// <param name="document">The document to be stored or updated.</param>
    abstract member PutProfileDocument: IDocument -> unit

    /// <summary>
    /// Deletes the specified Profile document in the context of the specified Agent.
    /// </summary>
    /// <param name="agent">The Agent associated with this Profile document.</param>
    /// <param name="profileId">The profile id associated with this Profile document.</param>
    abstract member DeleteProfileDocument: IAgent * ProfileId -> unit

    /// <summary>
    /// Fetches the specified Profile document in the context of the specified Agent.
    /// </summary>
    /// <returns>The Profile document, if found.</returns>
    /// <param name="agent">The Agent associated with this Profile document.</param>
    /// <param name="profileId">The profile id associated with this Profile document.</param>
    abstract member GetProfileDocument: IAgent * ProfileId -> IDocument option

    /// <summary>
    /// Fetches Profile ids of all Profile documents for an Agent.
    /// If "since" parameter is specified, this is limited to entries that have been stored or updated since the specified Timestamp (exclusive).
    /// </summary>
    /// <returns>Array of Profile id(s).</returns>
    /// <param name="agent">The Agent associated with these Profile documents.</param>
    /// <param name="since">Only ids of Profiles stored since the specified Timestamp (exclusive) are returned.</param>
    abstract member GetProfileDocuments: IAgent * [<Optional>] date: DateTime option -> ProfileId seq
