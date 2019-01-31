// <copyright file="ActivityId.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Resources.Documents

open System

/// <summary>
/// The Activity id associated with a state.
/// </summary>
[<CustomEquality;NoComparison;Struct>]
type ActivityId =
    val Value: Uri
    
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Resources.Documents.ActivityId"/> struct.
    /// </summary>
    /// <param name="value">Unique within the given context.</param>
    new(value) =
        { Value = value }

    /// <inheritdoc />
    override this.GetHashCode() = hash this.Value

    /// <inheritdoc />
    override this.Equals other = 
        match other with
        | :? ActivityId as id -> this.Value = id.Value
        | _ -> false

    static member op_Equality (lhs: ActivityId, rhs: ActivityId) = lhs.Equals(rhs)
    static member op_Inequality (lhs: ActivityId, rhs: ActivityId) = not(lhs.Equals(rhs))

    interface IEquatable<ActivityId> with
        member this.Equals other = this.Equals other
