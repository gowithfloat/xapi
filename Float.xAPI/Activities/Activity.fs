// <copyright file="Activity.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities

open System
open System.Runtime.InteropServices
open Float.xAPI
open Float.xAPI.Activities.Definitions
open Float.Interop

/// <summary>
/// A Statement can represent an Activity as the Object of the Statement.
/// </summary>
type public IActivity =
    /// <summary>
    /// An identifier for a single unique Activity.
    /// </summary>
    abstract member Id: ActivityId

    /// <summary>
    /// Metadata related to this activity.
    /// </summary>
    abstract member Definition: IActivityDefinition option

    inherit IEquatable<IActivity>
    inherit IObject

[<CustomEquality;NoComparison;Struct>]
type public Activity =
    /// <inheritdoc />
    val Id: ActivityId

    /// <inheritdoc />
    val Definition: IActivityDefinition option

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Activity"/> struct.
    /// </summary>
    /// <param name="id">An identifier for a single unique Activity.</param>
    /// <param name="definition">Metadata related to the activity.</param>
    new (id, [<Optional;DefaultParameterValue(null)>] ?definition) =
        nullArg id "id"
        { Id = id; Definition = definition }

    /// <inheritdoc />
    member this.ObjectType = ObjectType.Activity

    /// <inheritdoc />
    override this.GetHashCode() = hash this.Id

    /// <inheritdoc />
    override this.Equals other = 
        match other with
        | :? IActivity as activity -> this.Id = activity.Id
        | _ -> false
        
    static member op_Equality (lhs: IActivity, rhs: IActivity) = lhs.Equals(rhs)
    static member op_Inequality (lhs: IActivity, rhs: IActivity) = not(lhs.Equals(rhs))

    interface IActivity with
        member this.ObjectType = this.ObjectType
        member this.Id = this.Id
        member this.Definition = this.Definition
        member this.Equals other = this.Equals other
