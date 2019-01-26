// <copyright file="AnonymousGroup.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actor

open System.Runtime.InteropServices
open Float.Interop
open Float.xAPI

/// <summary>
/// An Anonymous Group is used to describe a cluster of people where there is no ready identifier for this cluster, e.g. an ad hoc team.
/// </summary>
type public IAnonymousGroup =
    inherit IGroup

[<NoEquality;NoComparison;Struct>]
type public AnonymousGroup =
    /// <inheritdoc />
    val Name: string option

    /// <inheritdoc />
    val Member: IAgent seq

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Actor.AnonymousGroup"/> class.
    /// </summary>
    /// <param name="members">The members of this Group. Required.</param>
    /// <param name="display">Name of the Group. Optional.</param>
    new (members, [<Optional;DefaultParameterValue(null)>] ?name) =
        nullArg members "members"
        emptySeqArg members "members"
        invalidOptionalStringArg name "name"
        { Name = name; Member = members }

    /// <inheritdoc />
    member this.ObjectType = ObjectType.Group

    interface IAnonymousGroup with
        member this.ObjectType = this.ObjectType
        member this.Member = this.Member
        member this.Name = this.Name
