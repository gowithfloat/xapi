// <copyright file="IdentifiedGroup.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actor

open System.Runtime.InteropServices
open Float.xAPI.Actor.Identifier
open Float.xAPI.Interop

/// <summary>
/// An Identified Group is used to uniquely identify a cluster of Agents.
/// </summary>
type public IIdentifiedGroup =
    inherit IGroup<option<seq<IAgent>>>
    inherit IIdentifiedActor

[<CustomEquality;NoComparison;Struct>]
type public IdentifiedGroup =
    /// <inheritdoc />
    val Name: option<string>

    /// <inheritdoc />
    val Member: option<seq<IAgent>>

    /// <inheritdoc />
    val IFI: IInverseFunctionalIdentifier

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Actor.IdentifiedGroup"/> class.
    /// </summary>
    /// <param name="ifi">An Inverse Functional Identifier unique to the Group. Required.</param>
    /// <param name="members">The members of this Group. Optional.</param>
    /// <param name="display">Name of the Group. Optional.</param>
    new (ifi, [<Optional;DefaultParameterValue(null)>] ?members, [<Optional;DefaultParameterValue(null)>] ?name) =
        nullArg ifi "ifi"
        emptyOptionalSeqArg members "members"
        invalidOptionalStringArg name "name"
        { Name = name; IFI = ifi; Member = members }

    /// <inheritdoc />
    member this.ObjectType = "Group"

    /// <inheritdoc />
    override this.GetHashCode() = hash this.IFI

    /// <inheritdoc />
    override this.ToString() = 
        sprintf "<%O: %O %O IFI %O>" (typeName this) (toStringOrNone this.Name "Name") (seqToStringOrNone this.Member "Member") this.IFI

    /// <inheritdoc />
    override this.Equals(other) =
        match other with
        | :? IIdentifiedGroup as group -> this.IFI = group.IFI
        | _ -> false

    static member op_Equality (lhs: IdentifiedGroup, rhs: IIdentifiedGroup) = lhs.Equals(rhs)
    static member op_Inequality (lhs: IdentifiedGroup, rhs: IIdentifiedGroup) = not(lhs.Equals(rhs))

    interface IIdentifiedGroup with
        member this.ObjectType = this.ObjectType
        member this.Member = this.Member
        member this.Name = this.Name
        member this.IFI = this.IFI
