// <copyright file="IIdentifiedActor.fs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actor

open Float.xAPI.Actor.Identifier

/// <summary>
/// Agents and identified groups have unique identifiers.
/// </summary>
type public IIdentifiedActor =
    /// <summary>
    /// An Inverse Functional Identifier unique to the Agent.
    /// </summary>
    abstract member IFI: IInverseFunctionalIdentifier

    inherit IActor
