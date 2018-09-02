// <copyright file="Agent.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actor

open System.Runtime.InteropServices
open Float.xAPI.Actor.Identifier
open Float.xAPI.Interop

/// <summary>
/// An Agent (an individual) is a persona or system.
/// </summary>
type public IAgent =
    inherit IIdentifiedActor

[<CustomEquality;NoComparison;Struct>]
type public Agent =
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

    /// <inheritdoc />
    member this.ObjectType = typeName this

    /// <inheritdoc />
    override this.GetHashCode() = hash this.IFI

    /// <inheritdoc />
    override this.ToString() =
        match this.Name with
        | Some name -> sprintf "<%O: Name %A IFI %A>" (this.GetType().Name) name this.IFI
        | None -> sprintf "<%O: IFI %A>" (typeName this) this.IFI

    /// <inheritdoc />
    override this.Equals(other) = 
        match other with
        | :? IAgent as agent -> this.IFI = agent.IFI
        | _ -> false

    static member op_Equality (lhs: Agent, rhs: IAgent) = lhs.Equals(rhs)
    static member op_Inequality (lhs: Agent, rhs: IAgent) = not(lhs.Equals(rhs))

    interface System.IEquatable<IAgent> with
        member this.Equals other = this.Equals other

    interface IAgent with
        member this.ObjectType = this.ObjectType
        member this.Name = this.Name
        member this.IFI = this.IFI
