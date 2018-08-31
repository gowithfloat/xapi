// <copyright file="Agent.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actor

open System.Runtime.InteropServices
open Float.xAPI
open Float.xAPI.Actor.Identifier
open Float.xAPI.Interop

/// <summary>
/// An Agent (an individual) is a persona or system.
/// </summary>
type public IAgent =
    inherit IIdentifiedActor

[<CustomEquality;NoComparison>]
type public Agent =
    struct
        /// <inheritdoc />
        val Name: option<string>

        /// <inheritdoc />
        val IFI: IInverseFunctionalIdentifier

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Actor.IdentifiedGroup"/> class.
        /// </summary>
        /// <param name="ifi">An Inverse Functional Identifier unique to the Agent. Required.</param>
        /// <param name="display">Name of the Agent. Optional.</param>
        new (ifi, [<Optional;DefaultParameterValue(null)>] ?name) =
            nullArg ifi "ifi"
            { Name = name; IFI = ifi }

        override this.GetHashCode() = hash this.IFI
        override this.ToString() =
            match this.Name with
            | Some name -> sprintf "<%O: Name %A IFI %A>" (this.GetType().Name) name this.IFI
            | None -> sprintf "<%O: IFI %A>" (typeName this) this.IFI
        override this.Equals(other) = 
            match other with
            | :? IAgent as agent -> this.IFI = agent.IFI
            | _ -> false

        member this.ObjectType = (this :> IObject).ObjectType

        interface System.IEquatable<IAgent> with
            member this.Equals other =
                this.IFI = other.IFI

        interface IAgent with
            member this.ObjectType = this.GetType().Name
            member this.Name = this.Name
            member this.IFI = this.IFI
    end
