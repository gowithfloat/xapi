// <copyright file="IIdentifiedActor.fs"company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actor

open System
open Float.xAPI.Actor.Identifier

/// <summary>
/// Agents and identified groups have unique identifiers and can be checked for equality.
/// </summary>
type public IIdentifiedActor =
    /// <summary>
    /// An Inverse Functional Identifier unique to the Agent.
    /// </summary>
    abstract member IFI: InverseFunctionalIdentifier

    inherit IEquatable<IIdentifiedActor>
    inherit IActor
