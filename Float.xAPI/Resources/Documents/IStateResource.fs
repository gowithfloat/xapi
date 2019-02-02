// <copyright file="IStateResource.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Resources.Documents

open System
open System.Runtime.InteropServices
open Float.xAPI.Activities
open Float.xAPI.Actor

/// <summary>
/// Generally, this is a scratch area for Learning Record Providers that do not have their own internal storage, or need to persist state across devices.
/// </summary>
type IStateResource =
    /// <summary>
    /// Stores the document specified.
    /// </summary>
    /// <param name="stateDocument">The document to be stored or updated.</param>
    /// <param name="stateId">The id for this state, within the given context.</param>
    /// <param name="activityId">The Activity id associated with this state.</param>
    /// <param name="agent">The Agent associated with this state.</param>
    /// <param name="registration">The registration associated with this state.</param>
    abstract member PutStateDocument: 
        IDocument * 
        StateId * 
        ActivityId * 
        IAgent *
        [<Optional>] registration: Guid option 
            -> unit

    /// <summary>
    /// Deletes the document specified by the given "stateId" that exists in the context of the specified Activity, Agent, and registration (if specified).
    /// </summary>
    /// <param name="stateId">The id for this state, within the given context.</param>
    /// <param name="activityId">The Activity id associated with this state.</param>
    /// <param name="agent">The Agent associated with this state.</param>
    /// <param name="registration">The registration associated with this state.</param>
    abstract member DeleteStateDocument: 
        StateId * 
        ActivityId * 
        IAgent *
        [<Optional>] registration: Guid option 
            -> unit

    /// <summary>
    /// Deletes all state data for this context (Activity + Agent [+ registration if specified]).
    /// </summary>
    /// <param name="activityId">The Activity id associated with these states.</param>
    /// <param name="agent">The Agent associated with these states.</param>
    /// <param name="registration">The Registration associated with these states.</param>
    abstract member DeleteStateDocuments: 
        ActivityId * 
        IAgent * 
        [<Optional>] registration: Guid option 
            -> unit

    /// <summary>
    /// Fetches the document specified by the given "stateId" that exists in the context of the specified Activity, Agent, and registration (if specified).
    /// </summary>
    /// <returns>The State document, if found.</returns>
    /// <param name="stateId">The id for this state, within the given context.</param>
    /// <param name="activityId">The Activity id associated with this state.</param>
    /// <param name="agent">The Agent associated with this state.</param>
    /// <param name="registration">The registration associated with this state.</param>
    abstract member GetStateDocument: 
        StateId * 
        ActivityId * 
        IAgent * 
        [<Optional>] registration: Guid option 
            -> IDocument option

    /// <summary>
    /// Fetches State ids of all state data for this context (Activity + Agent [ + registration if specified]).
    /// If "since" parameter is specified, this is limited to entries that have been stored or updated since the specified timestamp (exclusive).
    /// </summary>
    /// <returns>Array of State id(s).</returns>
    /// <param name="activityId">The Activity id associated with these states.</param>
    /// <param name="agent">The Agent associated with these states.</param>
    /// <param name="registration">The Registration associated with these states.</param>
    /// <param name="since">Only ids of states stored since the specified Timestamp (exclusive) are returned.</param>
    abstract member GetStateDocuments: 
        ActivityId *
        IAgent * 
        [<Optional>] registration: Guid option * 
        [<Optional>] since: DateTime option 
            -> StateId seq
