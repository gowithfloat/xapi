// <copyright file="IActor.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actors

open Float.xAPI

/// <summary>
/// The Actor defines who performed the action. The Actor of a Statement can be an Agent or a Group.
/// </summary>
type public IActor =
    /// <summary>
    /// Name of the actor.
    /// </summary>
    abstract member Name: string option

    inherit IObject
