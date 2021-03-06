﻿// <copyright file="ActivityId.fs" company="${CopyrightHolder}">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities

open System
open Float.Interop

/// <summary>
/// The id for a state, within the given context.
/// </summary>
[<CustomEquality;NoComparison;Struct>]
type ActivityId =
    val Iri: Uri
    
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.ActivityId"/> struct.
    /// </summary>
    /// <param name="iri">Unique within the given context.</param>
    new(iri) =
        invalidAbsoluteUri iri "iri"
        { Iri = iri }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.ActivityId"/> struct.
    /// </summary>
    /// <param name="iri">Unique within the given context.</param>
    new(iri) = ActivityId(Uri(iri))

    /// <inheritdoc />
    override this.GetHashCode() = hash this.Iri

    /// <inheritdoc />
    override this.ToString() = this.Iri.AbsoluteUri

    /// <inheritdoc />
    override this.Equals other = 
        match other with
        | :? ActivityId as id -> this.Iri = id.Iri
        | _ -> false

    static member op_Equality (lhs: ActivityId, rhs: ActivityId) = lhs.Equals(rhs)
    static member op_Inequality (lhs: ActivityId, rhs: ActivityId) = not(lhs.Equals(rhs))

    interface IEquatable<ActivityId> with
        member this.Equals other = this.Equals other
