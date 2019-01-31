// <copyright file="StateId.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Resources.Documents

open System
open Float.Interop

/// <summary>
/// The id for a state, within the given context.
/// </summary>
[<CustomEquality;NoComparison;Struct>]
type StateId =
    val Value: string
    
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Resources.Documents.StateId"/> struct.
    /// </summary>
    /// <param name="value">Unique within the given context.</param>
    new(value) =
        invalidStringArg value "value"
        { Value = value }

    /// <inheritdoc />
    override this.GetHashCode() = hash this.Value

    /// <inheritdoc />
    override this.Equals other = 
        match other with
        | :? StateId as id -> this.Value = id.Value
        | _ -> false

    static member op_Equality (lhs: StateId, rhs: StateId) = lhs.Equals(rhs)
    static member op_Inequality (lhs: StateId, rhs: StateId) = not(lhs.Equals(rhs))

    interface IEquatable<StateId> with
        member this.Equals other = this.Equals other
