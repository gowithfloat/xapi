// <copyright file="StateResourceKey.fs" company="${CopyrightHolder}">
// Copyright (c) 2019 ${CopyrightHolder}, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Resources.Documents

open System
open Float.Interop
open Float.xAPI.Actor

/// <summary>
/// State resources often need to store keys for documents, so this struct is provided for that purpose.
/// </summary>
[<CustomEquality;NoComparison;Struct>]
type public StateResourceKey =
    val StateId: StateId
    val ActivityId: ActivityId
    val Agent: IAgent
    
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Resources.Documents.StateResourceKey"/> struct.
    /// </summary>
    /// <param name="sid">The id for this state, within the given context.</param>
    /// <param name="aid">The Activity id associated with this state.</param>
    /// <param name="agent">The Agent associated with this state.</param>
    new(sid, aid, agent) =
        nullArg sid "sid"
        nullArg aid "aid"
        nullArg agent "agent"
        { StateId = sid; ActivityId = aid; Agent = agent }

    /// <inheritdoc />
    override this.GetHashCode() = hash (this.StateId, this.ActivityId, this.Agent)

    /// <inheritdoc />
    override this.Equals other = 
        match other with
        | :? StateResourceKey as key -> this.StateId = key.StateId && this.ActivityId = key.ActivityId && this.Agent = key.Agent
        | _ -> false

    static member op_Equality (lhs: StateResourceKey, rhs: StateResourceKey) = lhs.Equals(rhs)
    static member op_Inequality (lhs: StateResourceKey, rhs: StateResourceKey) = not(lhs.Equals(rhs))

    interface IEquatable<StateResourceKey> with
        member this.Equals other = this.Equals other