// <copyright file="IdentifiedGroup.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actor

open Float.xAPI
open Float.xAPI.Actor.Identifier

/// <summary>
/// An Identified Group is used to uniquely identify a cluster of Agents.
/// </summary>
type public IIdentifiedGroup =
    /// <summary>
    /// An Inverse Functional Identifier unique to the Group.
    /// </summary>
    abstract member IFI: IInverseFunctionalIdentifier

    /// <summary>
    /// The members of an anonymous group are an optional list of agents.
    /// </summary>
    inherit IGroup<option<seq<IAgent>>>

[<CustomEquality;NoComparison>]
type public IdentifiedGroup =
    struct
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
        new (ifi, ?members, ?name) =
            { Name = name; IFI = ifi; Member = members }

        override this.GetHashCode() = hash this.IFI
        override this.ToString() = sprintf "<%A: Name %A Member %A IFI %A>" (this.GetType().Name) this.Name this.Member this.IFI
        override this.Equals(other) =
            match other with
            | :? IIdentifiedGroup as group -> this.IFI = group.IFI
            | _ -> false

        member this.ObjectType = (this :> IObject).ObjectType

        interface System.IEquatable<IIdentifiedGroup> with
            member this.Equals other =
                this.IFI = other.IFI

        interface IIdentifiedGroup with
            member this.ObjectType = "Group"
            member this.Member = this.Member
            member this.Name = this.Name
            member this.IFI = this.IFI
    end
