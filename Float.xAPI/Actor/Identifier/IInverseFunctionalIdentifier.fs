// <copyright file="IInverseFunctionalIdentifier.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actor.Identifier

open System

/// <summary>
/// An Inverse Functional Identifier (IFI) is a value of an Agent or Identified Group that is guaranteed to only ever refer to that Agent or Identified Group.
/// </summary>
type public IInverseFunctionalIdentifier =
    inherit IEquatable<IInverseFunctionalIdentifier>
