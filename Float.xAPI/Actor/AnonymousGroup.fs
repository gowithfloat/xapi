// <copyright file="AnonymousGroup.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actor

open Float.xAPI

/// <summary>
/// An Anonymous Group is used to describe a cluster of people where there is no ready identifier for this cluster, e.g. an ad hoc team.
/// </summary>
type public IAnonymousGroup =
    /// <summary>
    /// The members of an anonymous group are a list of agents.
    /// </summary>
    inherit IGroup<seq<IAgent>>

[<NoEquality;NoComparison>]
type public AnonymousGroup =
    struct
        /// <inheritdoc />
        val Name: option<string>

        /// <inheritdoc />
        val Member: seq<IAgent>

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Actor.AnonymousGroup"/> class.
        /// </summary>
        /// <param name="members">The members of this Group. Required.</param>
        /// <param name="display">Name of the Group. Optional.</param>
        new (members, ?name) =
            { Name = name; Member = members }

        override this.ToString() = sprintf "<%A: Name %A Member %A>" (this.GetType().Name) this.Name this.Member

        member this.ObjectType = (this :> IObject).ObjectType

        interface IAnonymousGroup with
            member this.ObjectType = "Group"
            member this.Member = this.Member
            member this.Name = this.Name
    end
